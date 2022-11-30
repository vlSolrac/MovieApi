using Microsoft.EntityFrameworkCore;
using MoviesApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var am = builder.Configuration.GetValue<String>("Ambient");
var x = "";
if (am == "dev") x = "Development";

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetValue<String>($"{x}:ConnectionStrings"));
});
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
