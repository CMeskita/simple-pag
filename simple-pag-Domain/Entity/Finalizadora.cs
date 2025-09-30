using simple_pag_Domain.Shared.Notificacao;
using static simple_pag_Domain.Shared.Enums.Enums;


namespace simple_pag_Domain.Entity
{
    public class Finalizadora
    {
        private readonly Notify _notify;
        public Finalizadora()
        {
           
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
            Registro = DateTime.UtcNow;
            ValidationRules(false);
        }
        public void TotalPagamento(decimal valor) {Valor = valor;}
        public void SetStatus(PagamentoStatus status) { Status = status; }
      
        public Notify Notification => _notify;
    
        public string Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public DateTime Registro { get; protected set; }
        public string UsuarioId { get; protected set; }
        public PagamentoStatus Status { get; protected set; }
        public bool IsDeleted { get; protected set; } = false;
        public DateTime? DeletedAt { get; protected set; }=null;
        public virtual ICollection<FinalizadoraPagamento> FinalizadoraPagamentos { get; set; }


        public void Delete()
        {
            if (IsDeleted)
            {
                _notify.Add("Esta conta já está excluída.");
                return;
            }

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
        public void Restore()
        {
            if (!IsDeleted)
            {
                _notify.Add("Esta conta não está excluída.");
                return;
            }

            IsDeleted = false;
            DeletedAt = null;
        }

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
  

    }
}
