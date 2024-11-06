using AutoMapper;
using FirstAPI.Dao;
using FirstAPI.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(conf =>
{
    conf.AddPolicy("default",configurePolicy =>
    {
        configurePolicy.AllowAnyHeader();
        configurePolicy.AllowAnyMethod();
        configurePolicy.AllowAnyOrigin();
    });
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSingleton<PersonelManager>();
builder.Services.AddScoped<StudentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");
app.UseAuthorization();

app.MapControllers();

app.Run();
