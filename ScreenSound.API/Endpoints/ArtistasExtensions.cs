using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Requests;
using ScreenSound.Shared.Modelos.Response;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
	public static void AddEndPointsArtistas(this WebApplication app)
	{

		#region Endpoint Artistas
		app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
		{
			var listaDeArtistas = dal.Listar();
			if (listaDeArtistas is null)
			{
				return Results.NotFound();
			}
			var listaDeArtistaResponse = EntityListToResponseList(listaDeArtistas);
			return Results.Ok(listaDeArtistaResponse);
		});

		app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
		{
			var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
			if (artista is null)
			{
				return Results.NotFound();
			}
			return Results.Ok(EntityToResponse(artista));

		});

		app.MapPost("/Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
		{
			// Remove espaços em branco extras do nome do artista
			var nome = artistaRequest.Nome.Trim();

			// Gera um nome de arquivo "único" baseado na data/hora atual e no nome do artista
			// Ex: 250520241030.Alok.jpeg
			var imagemArtista = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

			// Define uma imagem padrão caso o usuário não envie nenhuma foto
			string fotoPerfil = $"Artista.jpeg";

			// Se o campo FotoPerfil não for nulo, significa que recebemos uma string Base64
			if (artistaRequest.FotoPerfil != null)
			{
				// Atualiza o nome da foto que será salva no banco de dados para o nome único gerado
				fotoPerfil = $"{imagemArtista}";

				// Define o caminho físico onde o arquivo será gravado no HD do servidor
				// 'ContentRootPath' pega a pasta raiz do projeto e combina com 'wwwroot/FotosPerfil'
				var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil", imagemArtista);

				// CONVERSÃO: Pega a string Base64 (texto) e transforma de volta em um array de bytes
				byte[] imageBytes = Convert.FromBase64String(artistaRequest.FotoPerfil!);

				// Cria um fluxo de memória para ler esses bytes...
				using var ms = new MemoryStream(imageBytes);

				// ...e cria um fluxo de arquivo para gravar esses bytes no caminho físico (HD)
				using var fs = new FileStream(path, FileMode.Create);

				// Copia os dados da memória para o arquivo físico de forma assíncrona
				await ms.CopyToAsync(fs);
			}

			// Instancia o objeto Artista com os dados recebidos e o caminho da foto
			var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio)
			{
				FotoPerfil = fotoPerfil
			};

			// Salva o objeto no banco de dados através da sua DAL
			dal.Adicionar(artista);

			return Results.Ok();
		});


		app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
		{
			var artista = dal.RecuperarPor(a => a.Id == id);
			if (artista is null)
			{
				return Results.NotFound();
			}
			dal.Deletar(artista);
			return Results.NoContent();

		});

		app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
		{
			var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.Id);
			if (artistaAAtualizar is null)
			{
				return Results.NotFound();
			}
			artistaAAtualizar.Nome = artistaRequestEdit.Nome;
			artistaAAtualizar.Bio = artistaRequestEdit.Bio;
			dal.Atualizar(artistaAAtualizar);
			return Results.Ok();
		});
		#endregion
	}

	private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
	{
		return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
	}

	private static ArtistaResponse EntityToResponse(Artista artista)
	{
		return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
	}


}
