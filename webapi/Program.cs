using Microsoft.EntityFrameworkCore;
using alunoapi.Database;
using alunoapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionMySql = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AlunoDbContext>(
   options =>options.UseMySql(connectionMySql,ServerVersion.Parse("8.0.30-mysql"))
);
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
