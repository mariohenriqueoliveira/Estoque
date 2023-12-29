using AutoFixture;
using AutoMapper;
using Estoque.Application.Interface;
using Estoque.Application.Service;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository.Interface;
using Estoque.Infra.CrossCutting.Dto;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Estoque.Tests.Service
{
    public class ProdutoServiceTestes
    {
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IProdutoService> _mockProdutoService;
        private readonly ProdutoService _service;
        private readonly Mock<IMapper> _mockMapper;

        private readonly Fixture _fixture;

        public ProdutoServiceTestes()
        {
            _fixture = new Fixture();
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _mockProdutoService = new Mock<IProdutoService>();

            _mockMapper = new Mock<IMapper>();
            _service = new ProdutoService(_mockProdutoRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task ObterProdutoPorId_RetornoComSucesso()
        {
            // Arrange
            var produto = _fixture.Create<Produto>();
            var dto = _fixture.Create<ProdutoDto>();

            _mockProdutoRepository.Setup(x => x.ObterProdutoPorId(produto.ProdutoId)).ReturnsAsync(produto);
            _mockMapper.Setup(x => x.Map<ProdutoDto>(produto)).Returns(dto);

            // Act
            var result = await _service.ObterProdutoPorId(produto.ProdutoId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ObterProdutoPorId_RetornoSemSucesso()
        {
            // Arrange
            var produto = _fixture.Create<Produto>();

            _mockProdutoRepository.Setup(x => x.ObterProdutoPorId(produto.ProdutoId));

            // Act
            var result = await _service.ObterProdutoPorId(produto.ProdutoId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ObterListaDeProdutos_RetornoComSucesso()
        {
            // Arrange
            var produto = _fixture.Create<List<Produto>>();

            _mockProdutoRepository.Setup(x => x.ObterListaDeProdutos(1, 1, produto.FirstOrDefault().DescricaoProduto)).ReturnsAsync(produto);

            // Act
            var result = await _service.ObterListaDeProdutos(1, 1, produto.FirstOrDefault().DescricaoProduto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ObterListaDeProdutos_RetornoSemSucesso()
        {
            // Arrange
            var produto = _fixture.Create<List<Produto>>();

            _mockProdutoRepository.Setup(x => x.ObterListaDeProdutos(1, 1, "xpto"));

            // Act
            var result = await _service.ObterListaDeProdutos(1, 1, "xpto");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task CriarProduto_RetornoComSucesso()
        {
            // Arrange
            var dto = _fixture.Create<ProdutoDto>();
            var produto = _fixture.Create<Produto>();

            _mockProdutoService.Setup(x => x.CriarProduto(dto)).ReturnsAsync(dto);

            // Act
            var result = await _service.CriarProduto(dto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CriarProduto_RetornoSemSucesso()
        {
            // Arrange
            var dto = _fixture.Create<ProdutoDto>();
            var produto = _fixture.Create<Produto>();

            _mockProdutoRepository.Setup(x => x.CriarProduto(produto));

            // Act
            var result = await _service.CriarProduto(null);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task AtualizarProduto_RetornoComSucesso()
        {
            // Arrange
            var dto = _fixture.Create<ProdutoDto>();
            var produto = _fixture.Create<Produto>();

            _mockProdutoService.Setup(x => x.AtualizarProduto(dto)).ReturnsAsync(dto);

            // Act
            var result = await _service.AtualizarProduto(dto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AtualizarProduto_RetornoSemSucesso()
        {
            // Arrange
            var dto = _fixture.Create<ProdutoDto>();
            var produto = _fixture.Create<Produto>();

            _mockProdutoRepository.Setup(x => x.AtualizarProduto(produto));

            // Act
            var result = await _service.AtualizarProduto(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeletarProduto_RetornoComSucesso()
        {
            // Arrange
            var dto = _fixture.Create<ProdutoDto>();
            var produto = _fixture.Create<Produto>();

            _mockProdutoService.Setup(x => x.DeletarProduto(dto.ProdutoId)).ReturnsAsync(dto.ProdutoId);

            // Act
            var result = await _service.DeletarProduto(dto.ProdutoId);

            // Assert
            Assert.NotEqual(default, result);
        }

        [Fact]
        public async Task DeletarProduto_RetornoSemSucesso()
        {
            // Arrange
            var dto = _fixture.Create<ProdutoDto>();
            var produto = _fixture.Create<Produto>();

            _mockProdutoRepository.Setup(x => x.DeletarProduto(produto.ProdutoId));

            // Act
            var result = await _service.DeletarProduto(default);

            // Assert
            Assert.Equal(default, result);
        }

    }
}
