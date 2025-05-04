namespace simple_pag_Domain.Entity
{
    public class FormaPagamento
    {
        public FormaPagamento(string nome, int codFinalizadora, string sigla)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Nome = nome;
            CodFinalizadora = codFinalizadora;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            Sigla = sigla;
            Status = true;
        }

        public FormaPagamento(string id, string nome, int codFinalizadora, string sigla)
        {
            Id = id;
            Nome = nome;
            CodFinalizadora = codFinalizadora;
            Sigla = sigla;
        }
        public void InativarFormaPagamento()
        {
            Status = false;
        }

        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public int CodFinalizadora { get; protected set; }
        public string Registro { get; protected set; }
        public string Sigla { get; protected set; }
        public bool Status { get; protected set; }
     
    }
}
