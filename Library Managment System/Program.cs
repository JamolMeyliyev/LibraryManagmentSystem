using Library_Managment_System.Extensions;
using LibraryManagmentSystem.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<LibraryDbContext>(options =>
//{
//    //options.UseInMemoryDatabase("TestDb");
//    //options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
//});
builder.Services.AddDbContexts(builder.Configuration)
    .AddServices()
    .AddRepositories();

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
