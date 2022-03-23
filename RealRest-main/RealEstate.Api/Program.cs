using System.Text.Json.Serialization;
using RealEstate.Application.App;
using RealEstate.Application.Interface;
using RealEstate.Domain.Interface;
using RealEstate.Domain.Interface.Generic;
using RealEstate.Infra.Repository;
using RealEstate.Infra.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;

//services.AddControllers()

builder.Services.AddScoped(typeof(InterfaceGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped<InterfaceOwner, RepositoryOwner>();
builder.Services.AddScoped<IAppOwner, AppOwner>();
builder.Services.AddScoped<InterfaceProperty, RepositoryProperty>();
builder.Services.AddScoped<IAppProperty, AppProperty>();

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
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

