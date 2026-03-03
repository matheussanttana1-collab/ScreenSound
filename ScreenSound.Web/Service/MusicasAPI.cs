using ScreenSound.Shared.Modelos.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Service;

public class MusicasAPI
{
	private readonly HttpClient _httpClient;
	private readonly ILogger<MusicasAPI> _logger;

	public MusicasAPI(IHttpClientFactory factory, ILogger<MusicasAPI> logger)
	{
		_httpClient = factory.CreateClient("API");
		_logger = logger;
	}

	public async Task<ICollection<MusicaResponse>> GetMusicasAsync ()
	{
		try
		{
			_logger.LogInformation("Tentando buscas musica no endpoint de musicas");
			var result = await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("Musicas");
			_logger.LogInformation("Busca de musicas concluida");
			return result;
		}
		catch (Exception ex)
		{
			string message = "Erro ao buscar musicas da API";
			_logger.LogError(message, ex);
			throw new ApplicationException(message, ex);
		}
	}
}
