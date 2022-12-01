using Microsoft.EntityFrameworkCore;
using MoviesApi;
using MoviesApi.Interfaces;
using MoviesApi.Services;

var builder = WebApplication.CreateBuilder(args);

var am = builder.Configuration.GetValue<String>("Ambient");
var x = "Production";
if (am == "dev") x = "Development";

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<AppDbContext>(op => { op.UseSqlServer(builder.Configuration.GetValue<String>($"{x}:ConnectionStrings")); });

builder.Services.AddScoped<IGenre, GenreService>();

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
