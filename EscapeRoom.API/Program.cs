using EscapeRoom.Application.EscapeRoom.Commands.CreateEscapeRoom;
using EscapeRoom.Domain.Interfaces;
using EscapeRoom.Infrastructure.Repositories;
using EscapeRoom.Infrastructure.Extensions;
using EscapeRoom.Infrastructure.Seeders;
using MediatR;
using EscapeRoom.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

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
