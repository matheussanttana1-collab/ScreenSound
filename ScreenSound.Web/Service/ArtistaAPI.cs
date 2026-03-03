using ScreenSound.Shared.Modelos.Requests;
using ScreenSound.Shared.Modelos.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Service;

public class ArtistaAPI
{
	private readonly HttpClient _httpClient;

	public ArtistaAPI(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("API");
	}

	public async Task<ICollection<ArtistaResponse>> GetArtistasAsync ()
	{
		return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("Artistas");
	}

	public async Task AddArtistaAsync (ArtistaRequest artista)
	{
		await _httpClient.PostAsJsonAsync("Artistas", artista);
	}
}
