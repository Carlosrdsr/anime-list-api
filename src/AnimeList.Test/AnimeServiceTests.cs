using AnimeList.Test.Helper;
using IdentityModel.OidcClient;

namespace AnimeList.Test.Tests
{
    public class AnimeServiceTests
    {       

        [Fact]
        public async Task InserirAnimeComSucesso()
        {
            //Arrange
            var nome = "Solo leveling";
            var diretor = "Shunsuke Nakashige";
            var resumo = @"É sobre um caçador de nível baixo que se depara com uma masmorra dupla e 
                            decide aceitar uma missão para subir de nível. ";
            //Act
            var tarefa = new Application.Features.AnimesList.CreateList.CreateListCommand(nome, diretor, resumo);

            //Assert
            Assert.Equal(tarefa.Nome, nome);
            Assert.Equal(tarefa.Diretor, diretor);
            Assert.Equal(tarefa.Resumo, resumo);
        }

        [Fact]
        public async Task ConsultarAnime()
        {
            // Arrange           
            int id = 1;
            var nome = "Solo leveling";
            var diretor = "Shunsuke Nakashige";

            // Act            
            var tarefa = new Application.Features.AnimesList.SearchList.SearchListQuery(id, nome, diretor);

            //Assert
            Assert.Equal(tarefa.Id, id);
            Assert.Equal(tarefa.Nome, nome);
            Assert.Equal(tarefa.Diretor, diretor);
        }

        [Fact]
        public async Task ConsultarAnimeNaoCastrado()
        {
            // Arrange           
            int id = 99;
            var repository = new AnimeRepositoryTest();

            // Act            
            var tarefa = repository.SearchAnime(id, null, null, 1, 10);

            //Assert
            Assert.Null(tarefa) ;
        }

        [Fact]
        public async Task ConsultarAnimeCastrado()
        {
            // Arrange           
            int id = 40;
            var repository = new AnimeRepositoryTest();

            // Act            
            var tarefa = repository.SearchAnime(id, null, null, 1, 10);

            //Assert
            Assert.NotNull(tarefa);
        }

        [Fact]
        public async Task ExistsAnimeByNome()
        {
            // Arrange           
            var nome = "No Game No Life";
            var repository = new AnimeRepositoryTest();

            // Act            
            var tarefa = repository.ExistsAnimeByNome(nome);

            //Assert
            Assert.True(tarefa);
        }

        [Fact]
        public async Task GetAnimeById()
        {
            // Arrange           
            var id = 5;
            var repository = new AnimeRepositoryTest();

            // Act            
            var tarefa = repository.GetAnimeById(id);

            //Assert
            Assert.NotNull(tarefa);
        }
    }
}
