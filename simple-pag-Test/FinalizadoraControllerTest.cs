using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using simple_pag.Controllers;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;


namespace simple_pag_Test
{
    public class FinalizadoraControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly FinalizadoraController _controller;

        public FinalizadoraControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new FinalizadoraController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateFinalizadora_ReturnsCreatedResponse()
        {
            // Arrange
            var command = new CommandFinalizadora
            {
                Valor = 100.0m,
                QtdParcelas = 2,
                Modalidade = "Crédito",
                Vencimento = "2023-12-31",
                FormaPagamento = "Cartão"
            };

            var response = new Response
            {
                StatusCode = 201,
                Message = "Finalizadora criada com sucesso"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CommandFinalizadora>(), default))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.CreateFinalizadora(command) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(response, result.Value);
        }

        [Fact]
        public async Task CreateFinalizadora_ReturnsBadRequestOnException()
        {
            // Arrange
            var command = new CommandFinalizadora
            {
                Valor = 100.0m,
                QtdParcelas = 2,
                Modalidade = "Crédito",
                Vencimento = "2023-12-31",
                FormaPagamento = "Cartão"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CommandFinalizadora>(), default))
                         .ThrowsAsync(new Exception("Erro ao criar finalizadora"));

            // Act
            var result = await _controller.CreateFinalizadora(command) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Erro ao criar finalizadora", ((Response)result.Value).Message);
        }
    }
}
