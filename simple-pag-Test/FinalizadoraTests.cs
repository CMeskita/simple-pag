using simple_pag_Domain.Entity;

public class FinalizadoraTests
{
    [Fact]
    public void Finalizadora_Constructor_ShouldInitializeProperties()
    {
        // Arrange
        decimal valor = 100.50m;
        int qtdParcelas = 5;
        string modalidade = "Crédito";
        string vencimento = "2023-12-31";
        string formaPagamento = "Cartão";

        // Act
        var finalizadora = new Finalizadora(valor, qtdParcelas, modalidade, vencimento, formaPagamento);

        // Assert
        Assert.NotNull(finalizadora.Id);
        Assert.Equal(valor, finalizadora.Valor);
        Assert.Equal(qtdParcelas, finalizadora.QtdParcelas);
        Assert.Equal(modalidade.ToUpper(), finalizadora.Modalidade);
        Assert.Equal(vencimento, finalizadora.Vencimento);
        Assert.Equal(formaPagamento, finalizadora.FormaPagamento);
    }

    [Fact]
    public void Finalizadora_ConstructorWithId_ShouldInitializeProperties()
    {
        // Arrange
        string id = Guid.NewGuid().ToString().ToUpper();
        decimal valor = 200.75m;
        int qtdParcelas = 10;
        string modalidade = "Débito";
        string vencimento = "2024-01-15";
        string formaPagamento = "Boleto";

        // Act
        var finalizadora = new Finalizadora(id, valor, qtdParcelas, modalidade, vencimento, formaPagamento);

        // Assert
        Assert.Equal(id, finalizadora.Id);
        Assert.Equal(valor, finalizadora.Valor);
        Assert.Equal(qtdParcelas, finalizadora.QtdParcelas);
        Assert.Equal(modalidade, finalizadora.Modalidade);
        Assert.Equal(vencimento, finalizadora.Vencimento);
        Assert.Equal(formaPagamento, finalizadora.FormaPagamento);
    }
}