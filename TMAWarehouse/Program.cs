using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMAWarehouse.ApplicationServices.API.Domain;
using TMAWarehouse.ApplicationServices.API.Mappings;
using TMAWarehouse.ApplicationServices.API.Validator;
using TMAWarehouse.DataAccess;
using TMAWarehouse.DataAccess.CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(ResponseBase<>).Assembly);
builder.Services.AddAutoMapper(typeof(ItemsProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddMvcCore().
    AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddUserRequestValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WarehouseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseConnection")));



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
