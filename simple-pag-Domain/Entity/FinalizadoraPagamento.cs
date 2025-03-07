using System;

public class FinalizadoraPagamento
{

    public FinalizadoraPagamento()
    {
    }

    public FinalizadoraPagamento(string finalizadoraId, string formaPagamentoId, string sigla, string modalidade, StatusPagamento statusPagamento)
    {
        Id =  Id = Guid.NewGuid().ToString().ToUpper();
        FinalizadoraId = finalizadoraId;
        FormaPagamentoId = formaPagamentoId;
        Sigla = sigla;
        Modalidade = modalidade;
        Registro = DateTime.UtcNow.ToString();
        StatusPagamento = statusPagamento;
    }

    public string Id { get; protected set; }
    public string FinalizadoraId { get; protected set; }
    public string FormaPagamentoId { get; protected set; }
    public string Sigla { get; protected set; }
    public string Modalidade { get; protected set; }
    public string Registro { get; protected set; }
    public StatusPagamento StatusPagamento { get; protected set; }

    public void AtualizarStatusPagamento(DateTime dataPagamento)
    {
      
    }
}
