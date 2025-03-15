namespace simple_pag_usuario_test;

public class ControllerUsuarioTeste
{
    private readonly UsuarioController _usuarioController;
    private readonly Mock<Imediator> _mediator;
    public ControllerUsuarioTeste (UsuarioController usuarioController, Mock<Imediator> mediator) {

        _usuarioController = usuarioController;
        _mediator = mediator;
    }

    [Fact]
    public async Task CreateUsuarioTest () {

        //Arrange
        var commandUsuario = new CommandUsuario();
        var response = new Response();
        _mediator.Setup(x => x.Send(commandUsuario)).ReturnsAsync(response);

        //Act
        var result = await _usuarioController.CreateUsuario(commandUsuario);

        //Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(201, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task GetAllUsuariosTest () {

        //Arrange
        var response = new List<Usuario>();
        _mediator.Setup(x => x.Send(null)).ReturnsAsync(response);

        //Act
        var result = await _usuarioController.GetAllUsuarios();

        //Assert
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, ((OkObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task CreateUsuarioTest_ModelInvalido () {

        //Arrange
        var commandUsuario = new CommandUsuario();
        _usuarioController.ModelState.AddModelError("Nome", "Nome é obrigatório");

        //Act
        var result = await _usuarioController.CreateUsuario(commandUsuario);

        //Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, ((BadRequestObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task GetAllUsuariosTest_DadosNaoEncontrados () {

        //Arrange
        List<Usuario> response = null;
        _mediator.Setup(x => x.Send(null)).ReturnsAsync(response);

        //Act
        var result = await _usuarioController.GetAllUsuarios();

        //Assert
        Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, ((NotFoundObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task FindUsuarioTest () {

        //Arrange
        var commandUsuario = new CommandUsuario();
        var response = new Response();
        _mediator.Setup(x => x.Send(commandUsuario)).ReturnsAsync(response);

        //Act
        var result = await _usuarioController.FindUsuario(commandUsuario);

        //Assert
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, ((OkObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task FindUsuarioTest_DadosNaoEncontrados () {

        //Arrange
        var commandUsuario = new CommandUsuario();
        Response response = null;
        _mediator.Setup(x => x.Send(commandUsuario)).ReturnsAsync(response);

        //Act
        var result = await _usuarioController.FindUsuario(commandUsuario);

        //Assert
        Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, ((NotFoundObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task FindUsuarioTest_Exception () {

        //Arrange
        var commandUsuario = new CommandUsuario();
        var response = new Response();
        _mediator.Setup(x => x.Send(commandUsuario)).Throws(new Exception());

        //Act
        var result = await _usuarioController.FindUsuario(commandUsuario);

        //Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(500, ((BadRequestObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task GetAllUsuariosTest_Exception () {

        //Arrange
        List<Usuario> response = null;
        _mediator.Setup(x => x.Send(null)).Throws(new Exception());

        //Act
        var result = await _usuarioController.GetAllUsuarios();

        //Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(500, ((BadRequestObjectResult)result).StatusCode);
    }
    [Fact]
    public async Task CreateUsuarioTest_Exception () {

        //Arrange
        var commandUsuario = new CommandUsuario();
        _mediator.Setup(x => x.Send(commandUsuario)).Throws(new Exception());

        //Act
        var result = await _usuarioController.CreateUsuario(commandUsuario);

        //Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(500, ((BadRequestObjectResult)result).StatusCode);
    }
  
}