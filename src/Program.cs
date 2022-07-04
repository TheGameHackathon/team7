using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.Domain;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMvc();
builder.Services.AddSingleton<IGameRepository, GameRepository>();
builder.Services.AddSingleton<IGame2048Handler, Game2048Handler>();
builder.Services.AddSingleton<IGame2048AI, PrettySmart2048Ai>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Use((context, next) =>
{
    context.Request.Path = "/index.html";
    return next();
});
app.UseStaticFiles();

app.Run();