using Microsoft.EntityFrameworkCore;
using Repository.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Agreeya_DataContextConnection") ?? throw new InvalidOperationException("Connection string 'Agreeya_DataContextConnection' not found.");
builder.Services.AddDbContext<Agreeya_CodeContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Repository.IoC.Setup(builder.Services);
Service.IoC.Setup(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
