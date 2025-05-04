namespace simple_pag_Domain.Entity
{
    public class Finalizadora
    {
        public Finalizadora(decimal valor, int qtdParcelas, string modalidade, string vencimento, string formaPagamento)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Valor = valor;
            QtdParcelas = qtdParcelas;
            Modalidade = modalidade.ToUpper();
            Vencimento = vencimento.ToString();
            FormaPagamento = formaPagamento;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public Finalizadora(string id, decimal valor, int qtdParcelas, string modalidade, string vencimento, string formaPagamento)
        {
            Id = id;
            Valor = valor;
            QtdParcelas = qtdParcelas;
            Modalidade = modalidade;
            Vencimento = vencimento;
            FormaPagamento = formaPagamento;
        }
    
        
        public string Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public int QtdParcelas { get; protected set; }
        public string Modalidade { get; protected set; }
        public string Vencimento { get; protected set; }
        public string FormaPagamento { get; protected set; }
        public string Registro { get; protected set; }
    }

}
