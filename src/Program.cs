using api_cadastro.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGlobalExtensions(builder.Configuration);

var app = builder.Build();
app.UseGlobalExtensions();
app.Run();