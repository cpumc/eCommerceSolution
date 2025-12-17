using ecommerce.Core;
using ecommerce.Core.Mappers;
using ecommerce.Infra;
using eCommerce.API.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//adding the json searlizer
builder.Services.AddControllers().AddJsonOptions
    (options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
//adding the automapper
builder.Services.AddAutoMapper(typeof(AutpMappings));
//fluent validation
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();
app.UseExceptionHandlingMiddleWare();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
