using simple_pag_Domain.Shared.Notificacao;


namespace simple_pag_Domain.Entity
{
    public class Finalizadora
    {
        private readonly Notify _notify;
        public Finalizadora()
        {
            _notify = new Notify();
        }


        public Finalizadora(string id, decimal valor)
        {
            _notify = new Notify();

            Id = id;
            Valor = valor;

     
            ValidationRules(true);
        }

        public Finalizadora(string usuario)
        {
            _notify = new Notify();
            Id = Guid.NewGuid().ToString().ToUpper();
            UsuarioId = usuario;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            ValidationRules(false);
        }
        public void TotalPagamento(decimal valor)
        {
          
            Valor = valor;

        }
        public void SetStatus(PagamentoStatus status)
        {

            Status = status;

        }
        public Notify Notification => _notify;
    
        public string Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public string Registro { get; protected set; }
        public string UsuarioId { get; protected set; }
        public PagamentoStatus Status { get; protected set; }



        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (string.IsNullOrEmpty(UsuarioId) )
            {
                _notify.Add("Usuário não informado.");
            }          
            if (_notify.HasNotifications)
            {
                throw new BusinessException("Ocorreram erros na tentativa de criação do registro !!!", _notify);
            }
        }
        public enum PagamentoStatus
        {
          
            Pendente,//0
         
            Confirmado,//1
        
            Cancelado//2
        }

    }
}
