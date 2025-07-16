using MarketWatch.Application.UseCases;
using MarketWatch.Domain.Interfaces;
using MarketWatch.Infrastructure.Models;
using MarketWatch.Persistence;
using MarketWatch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketWatchDbContext>(options => options.UseInMemoryDatabase("MarketWatchDb"));


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BinanceSymbolService>();
builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();
builder.Services.AddScoped<SymbolService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
}

app.UseHttpsRedirection();
app.Run();
