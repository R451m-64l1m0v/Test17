using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Extensions;
using RegisterToDoctor.Infrastructure.Data;
using RegisterToDoctor.Infrastructure.Data.Context;
using RegisterToDoctor.Infrastructure.Data.Extensions;
using RegisterToDoctor.Infrastructure.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddApplicationDbContext(connectionString);

builder.Services.AddAttributedServices();

builder.Services.AddTransient<UnitOfWork>();
builder.Services.AddTransient<IUnitOfWork>(p => p.GetRequiredService<UnitOfWork>());
builder.Services.AddTransient(typeof(IDbRepository<>), typeof(DbRepository<>));

var app = builder.Build();

using var scope = app.Services.CreateAsyncScope();

var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
