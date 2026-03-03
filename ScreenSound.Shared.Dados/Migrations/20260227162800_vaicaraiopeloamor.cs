using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScreenSound.Shared.Dados.Migrations
{
    /// <inheritdoc />
    public partial class vaicaraiopeloamor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artistas",
                columns: new[] { "Id", "Bio", "FotoPerfil", "Nome" },
                values: new object[,]
                {
                    { 1, "Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.", "Foto_001.png", "Foo Fighters" },
                    { 2, "Queen foi uma banda de rock britânica formada em Londres em 1970.", "Foto_002.png", "Queen" },
                    { 3, "Led Zeppelin foi uma banda de rock britânica formada em Londres em 1968.", "Foto_003.png", "Led Zeppelin" },
                    { 4, "Taylor Alison Swift é uma cantora e compositora americana.", "Foto_004.png", "Taylor Swift" },
                    { 5, "Michael Joseph Jackson foi um cantor, compositor e dançarino americano.", "Foto_005.png", "Michael Jackson" },
                    { 6, "Madonna Louise Ciccone é uma cantora, compositora, atriz e empresária americana.", "Foto_006.png", "Madonna" },
                    { 7, "Djavan Caetano Viana é um cantor, compositor, arranjador, produtor musical, empresário, violonista e ex-futebolista brasileiro.", "Foto_007.png", "Djavan" },
                    { 8, "Gilberto Passos Gil Moreira é um cantor, compositor, multi-instrumentista, produtor musical, político e escritor brasileiro.", "Foto_008.png", "Gilberto Gil" },
                    { 9, "Caetano Emanuel Viana Telles Veloso é um cantor, compositor, violonista, escritor e produtor musical brasileiro.", "Foto_009.png", "Caetano Veloso" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Gênero musical que se desenvolveu a partir do rock and roll nas décadas de 1950 e 1960.", "Rock" },
                    { 2, "Gênero de música popular que se originou em sua forma moderna em meados da década de 1950 nos Estados Unidos e Reino Unido.", "Pop" },
                    { 3, "A Música Popular Brasileira é um gênero musical que surgiu no Brasil em meados dos anos 1960.", "MPB" }
                });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "AnoLancamento", "ArtistaId", "GeneroId", "Nome" },
                values: new object[,]
                {
                    { 1, 1997, 1, 1, "Everlong" },
                    { 2, 2007, 1, 1, "The Pretender" },
                    { 3, 1999, 1, 1, "Learn to Fly" },
                    { 4, 1975, 2, 1, "Bohemian Rhapsody" },
                    { 5, 1978, 2, 1, "Don't Stop Me Now" },
                    { 6, 1977, 2, 1, "We Will Rock You" },
                    { 7, 1971, 3, 1, "Stairway to Heaven" },
                    { 8, 1969, 3, 1, "Whole Lotta Love" },
                    { 9, 1971, 3, 1, "Black Dog" },
                    { 10, 2014, 4, 2, "Blank Space" },
                    { 11, 2014, 4, 2, "Shake It Off" },
                    { 12, 2008, 4, 2, "Love Story" },
                    { 13, 1982, 5, 2, "Billie Jean" },
                    { 14, 1982, 5, 2, "Thriller" },
                    { 15, 1982, 5, 2, "Beat It" },
                    { 16, 1984, 6, 2, "Like a Virgin" },
                    { 17, 1984, 6, 2, "Material Girl" },
                    { 18, 1990, 6, 2, "Vogue" },
                    { 19, 1989, 7, 3, "Oceano" },
                    { 20, 1976, 7, 3, "Flor de Lis" },
                    { 21, 1982, 7, 3, "Samurai" },
                    { 22, 1982, 8, 3, "Andar com Fé" },
                    { 23, 1982, 8, 3, "Drão" },
                    { 24, 1972, 8, 3, "Expresso 2222" },
                    { 25, 1977, 9, 3, "O Leãozinho" },
                    { 26, 1978, 9, 3, "Sampa" },
                    { 27, 1979, 9, 3, "Cajuína" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
