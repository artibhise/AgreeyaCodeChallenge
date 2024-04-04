using System.Security.Cryptography;
using System.Text;

namespace Shared.Helpers
{
    public class SHA1Crypto
    {
        private static readonly string _salt = "pa2023l2024cus$none$$";

        /// <summary>
        /// Get Salt for the encryption.
        /// </summary>
        /// <returns>Returns byte array version of salt</returns>
        private static byte[] GetSaltByte()
        {
            try
            {
                return Encoding.ASCII.GetBytes(_salt);
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Appends two byte arrays
        /// </summary>
        /// <param name="byteArray1"></param>
        /// <param name="byteArray2"></param>
        /// <returns></returns>
        private static byte[] AppendByteArray(byte[] byteArray1, byte[] byteArray2)
        {
            try
            {
                byte[] byteArrayResult = new byte[byteArray1.Length + byteArray2.Length];

                for (int i = 0; i < byteArray1.Length; i++)
                {
                    byteArrayResult[i] = byteArray1[i];
                }

                for (int i = 0; i < byteArray2.Length; i++)
                {
                    byteArrayResult[byteArray1.Length + i] = byteArray2[i];
                }

                return byteArrayResult;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Encrypt password using SHA1 mechanism.
        /// </summary>
        /// <param name="textToEncrypt">The string automatic encrypt.</param>
        /// <returns></returns>
        public static string Encrypt(string textToEncrypt)
        {
            if (string.IsNullOrEmpty(textToEncrypt))
            {
                return string.Empty;
            }

            try
            {
                using var sha1 = SHA1.Create();
                byte[] b_ToHash = Encoding.ASCII.GetBytes(textToEncrypt);
                byte[] appendedSHA1BytesWithSalt = AppendByteArray(GetSaltByte(), b_ToHash);

                b_ToHash = sha1.ComputeHash(appendedSHA1BytesWithSalt);
                string hashedString = string.Empty;

                foreach (byte b in b_ToHash)
                {
                    hashedString += b.ToString("x2");
                }

                return hashedString;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
