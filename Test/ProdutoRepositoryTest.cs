using Microsoft.AspNetCore.Mvc;
using Moq;
using web_app_domain;
using web_app_repository;
using Xunit;
namespace Test
{
	public class ProdutoRepositoryTest
	{
        [Fact]
        public async Task ListarProdutos()
        {
            //Arrange
            var produtos = new List<Produto>()
            {
                new Produto()
                {
                    id = 2,
                    nome = "Mouse",
                    preco = "123",
                    quantidade_estoque = "321",
                    data_criacao = "13/10/24"

                },

                new Produto()
                {
                    id = 3,
                    nome = "Teclado",
                    preco = "2223",
                    quantidade_estoque = "222",
                    data_criacao = "13/10/24"

                }

            };

            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            produtoRepositoryMock.Setup(u => u.ListarProdutos()).ReturnsAsync(produtos);
            var produtoRepository = produtoRepositoryMock.Object;

            //Act
            var result = await produtoRepository.ListarProdutos();

            //Asserts
            Assert.Equal(produtos, result);

        }

        [Fact]
        public async Task SalvarProduto()
        {
            //Arrange
            var produto = new Produto
            {
                id = 2,
                nome = "MouseAtualizado",
                preco = "234",
                quantidade_estoque = "320",
                data_criacao = "13/10/24"

            };

            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            produtoRepositoryMock.Setup(u => u.SalvarProduto(It.IsAny<Produto>())).Returns(Task.CompletedTask);
            var produtoRepository = produtoRepositoryMock.Object;

            //Act
            await produtoRepository.SalvarProduto(produto);

            //Assets
            produtoRepositoryMock.Verify(u => u.SalvarProduto(It.IsAny<Produto>()), Times.Once);

        }
    }
}

