using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ProcessoDigital.Client.Pages;
using ProcessoDigital.Components;
using ProcessoDigital.Data.Context;
using ProcessoDigital.Services.Implementations;
using ProcessoDigital.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionStrings));

builder.Services.AddMudServices();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProcessoService, ProcessoService>();
builder.Services.AddScoped<IAndamentoService, AndamentoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ProcessoDigital.Client._Imports).Assembly);

app.Run();
