using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using ScreenSound.Web;
using ScreenSound.Web.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
 // Injeção de Dependencia dos services da Api
builder.Services.AddTransient<ArtistaAPI>();
builder.Services.AddTransient<MusicasAPI>();


// Registra no container de Injeção de Dependência um HttpClient nomeado
// com o nome "API"
builder.Services.AddHttpClient("API", client =>
{
	// Define a URL base que será usada em todas as requisições feitas
	// por esse HttpClient.
	// Exemplo: https://api.meuservico.com
	client.BaseAddress = new Uri(
		builder.Configuration["APIServer"]
	);

	// Adiciona um header padrão que será enviado em TODAS as requisições
	// feitas por esse HttpClient.
	// Aqui estamos dizendo que o cliente espera receber JSON como resposta.
	client.DefaultRequestHeaders.Add(
		"Accept",
		"application/json"
	);
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();

// Tratamento de redirecionamento para SPA no GitHub Pages
var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();

// Redireciona se vem do 404.html
await jsRuntime.InvokeVoidAsync("eval", 
	@"if (window.sessionStorage.redirect) {
		var redirect = window.sessionStorage.redirect;
		delete window.sessionStorage.redirect;
		window.history.replaceState(null, null, redirect);
	}");

await host.RunAsync();
