using System;

public class FinalizadoraPagamento
{

    public FinalizadoraPagamento()
    {
    }

    public FinalizadoraPagamento(string id, string finalizadoraId, string formaPagamentoId, string sigla, string modalidade, string registro, StatusPagamento statusPagamento)
    {
        Id = id;
        FinalizadoraId = finalizadoraId;
        FormaPagamentoId = formaPagamentoId;
        Sigla = sigla;
        Modalidade = modalidade;
        Registro = registro;
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
