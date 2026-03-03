using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
public class ScreenSoundContext: DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    public ScreenSoundContext(DbContextOptions options) : base(options)
    {

    }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Musica>()
			.HasOne(m => m.Artista)
			.WithMany(a => a.Musicas)
			.HasForeignKey(m => m.ArtistaId);

		modelBuilder.Entity<Musica>()
			.HasOne(m => m.Genero)
			.WithMany(a => a.Musicas)
			.HasForeignKey(m => m.GeneroId);

		// =========================
		// GÊNEROS
		// =========================
		modelBuilder.Entity<Genero>().HasData(
			new Genero { Id = 1, Nome = "Rock", Descricao = "Gênero musical que se desenvolveu a partir do rock and roll nas décadas de 1950 e 1960." },
			new Genero { Id = 2, Nome = "Pop", Descricao = "Gênero de música popular que se originou em sua forma moderna em meados da década de 1950 nos Estados Unidos e Reino Unido." },
			new Genero { Id = 3, Nome = "MPB", Descricao = "A Música Popular Brasileira é um gênero musical que surgiu no Brasil em meados dos anos 1960." }
		);

		// =========================
		// ARTISTAS
		// =========================
		modelBuilder.Entity<Artista>().HasData(
			new Artista { Id = 1, Nome = "Foo Fighters", Bio = "Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.", FotoPerfil = "Foto_001.png" },
			new Artista { Id = 2, Nome = "Queen", Bio = "Queen foi uma banda de rock britânica formada em Londres em 1970.", FotoPerfil = "Foto_002.png" },
			new Artista { Id = 3, Nome = "Led Zeppelin", Bio = "Led Zeppelin foi uma banda de rock britânica formada em Londres em 1968.", FotoPerfil = "Foto_003.png" },
			new Artista { Id = 4, Nome = "Taylor Swift", Bio = "Taylor Alison Swift é uma cantora e compositora americana.", FotoPerfil = "Foto_004.png" },
			new Artista { Id = 5, Nome = "Michael Jackson", Bio = "Michael Joseph Jackson foi um cantor, compositor e dançarino americano.", FotoPerfil = "Foto_005.png" },
			new Artista { Id = 6, Nome = "Madonna", Bio = "Madonna Louise Ciccone é uma cantora, compositora, atriz e empresária americana.", FotoPerfil = "Foto_006.png" },
			new Artista { Id = 7, Nome = "Djavan", Bio = "Djavan Caetano Viana é um cantor, compositor, arranjador, produtor musical, empresário, violonista e ex-futebolista brasileiro.", FotoPerfil = "Foto_007.png" },
			new Artista { Id = 8, Nome = "Gilberto Gil", Bio = "Gilberto Passos Gil Moreira é um cantor, compositor, multi-instrumentista, produtor musical, político e escritor brasileiro.", FotoPerfil = "Foto_008.png" },
			new Artista { Id = 9, Nome = "Caetano Veloso", Bio = "Caetano Emanuel Viana Telles Veloso é um cantor, compositor, violonista, escritor e produtor musical brasileiro.", FotoPerfil = "Foto_009.png" }
		);

		// =========================
		// MÚSICAS
		// =========================
		modelBuilder.Entity<Musica>().HasData(
			// Foo Fighters - Rock
			new Musica { Id = 1, Nome = "Everlong", AnoLancamento = 1997, ArtistaId = 1, GeneroId = 1 },
			new Musica { Id = 2, Nome = "The Pretender", AnoLancamento = 2007, ArtistaId = 1, GeneroId = 1 },
			new Musica { Id = 3, Nome = "Learn to Fly", AnoLancamento = 1999, ArtistaId = 1, GeneroId = 1 },

			// Queen - Rock
			new Musica { Id = 4, Nome = "Bohemian Rhapsody", AnoLancamento = 1975, ArtistaId = 2, GeneroId = 1 },
			new Musica { Id = 5, Nome = "Don't Stop Me Now", AnoLancamento = 1978, ArtistaId = 2, GeneroId = 1 },
			new Musica { Id = 6, Nome = "We Will Rock You", AnoLancamento = 1977, ArtistaId = 2, GeneroId = 1 },

			// Led Zeppelin - Rock
			new Musica { Id = 7, Nome = "Stairway to Heaven", AnoLancamento = 1971, ArtistaId = 3, GeneroId = 1 },
			new Musica { Id = 8, Nome = "Whole Lotta Love", AnoLancamento = 1969, ArtistaId = 3, GeneroId = 1 },
			new Musica { Id = 9, Nome = "Black Dog", AnoLancamento = 1971, ArtistaId = 3, GeneroId = 1 },

			// Taylor Swift - Pop
			new Musica { Id = 10, Nome = "Blank Space", AnoLancamento = 2014, ArtistaId = 4, GeneroId = 2 },
			new Musica { Id = 11, Nome = "Shake It Off", AnoLancamento = 2014, ArtistaId = 4, GeneroId = 2 },
			new Musica { Id = 12, Nome = "Love Story", AnoLancamento = 2008, ArtistaId = 4, GeneroId = 2 },

			// Michael Jackson - Pop
			new Musica { Id = 13, Nome = "Billie Jean", AnoLancamento = 1982, ArtistaId = 5, GeneroId = 2 },
			new Musica { Id = 14, Nome = "Thriller", AnoLancamento = 1982, ArtistaId = 5, GeneroId = 2 },
			new Musica { Id = 15, Nome = "Beat It", AnoLancamento = 1982, ArtistaId = 5, GeneroId = 2 },

			// Madonna - Pop
			new Musica { Id = 16, Nome = "Like a Virgin", AnoLancamento = 1984, ArtistaId = 6, GeneroId = 2 },
			new Musica { Id = 17, Nome = "Material Girl", AnoLancamento = 1984, ArtistaId = 6, GeneroId = 2 },
			new Musica { Id = 18, Nome = "Vogue", AnoLancamento = 1990, ArtistaId = 6, GeneroId = 2 },

			// MPB
			new Musica { Id = 19, Nome = "Oceano", AnoLancamento = 1989, ArtistaId = 7, GeneroId = 3 },
			new Musica { Id = 20, Nome = "Flor de Lis", AnoLancamento = 1976, ArtistaId = 7, GeneroId = 3 },
			new Musica { Id = 21, Nome = "Samurai", AnoLancamento = 1982, ArtistaId = 7, GeneroId = 3 },

			new Musica { Id = 22, Nome = "Andar com Fé", AnoLancamento = 1982, ArtistaId = 8, GeneroId = 3 },
			new Musica { Id = 23, Nome = "Drão", AnoLancamento = 1982, ArtistaId = 8, GeneroId = 3 },
			new Musica { Id = 24, Nome = "Expresso 2222", AnoLancamento = 1972, ArtistaId = 8, GeneroId = 3 },

			new Musica { Id = 25, Nome = "O Leãozinho", AnoLancamento = 1977, ArtistaId = 9, GeneroId = 3 },
			new Musica { Id = 26, Nome = "Sampa", AnoLancamento = 1978, ArtistaId = 9, GeneroId = 3 },
			new Musica { Id = 27, Nome = "Cajuína", AnoLancamento = 1979, ArtistaId = 9, GeneroId = 3 }
		);
	}

}
