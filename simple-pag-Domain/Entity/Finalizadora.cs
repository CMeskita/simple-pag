
using simple_pag_Domain.Shared.Notificacao;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


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

        public Finalizadora(decimal valor)
        {
            _notify = new Notify();
            Id = Guid.NewGuid().ToString().ToUpper();
            Valor = valor;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            ValidationRules(false);
        }

        public Notify Notification => _notify;
    
        public string Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public string Registro { get; protected set; }


    
        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (Valor <= 0)
            {
                _notify.Add("Valor não pode ser menor ou igual a zero.");
            }          
            if (_notify.HasNotifications)
            {
                throw new BusinessException("Ocorreram erros na tentativa de criação do registro !!!", _notify);
            }
        }
        
       
    }
}
