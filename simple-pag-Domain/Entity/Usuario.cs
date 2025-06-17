using simple_pag_Domain.Shared.Models;
using simple_pag_Domain.Shared.Notificacao;

namespace simple_pag_Domain.Entity
{
    public class Usuario
    {
        private readonly Notify _notify;

        public Usuario()
        {
            _notify = new Notify();
        }
        public Usuario(string nome, string email, string chavePrivada)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Nome = nome;
            Email = email;
            ChavePrivada = chavePrivada;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            Status = true;

            ValidationRules(false);
        }
        public Usuario(string id, string nome, string email, string chavePrivada,string registro,bool status)
        {
            Id = id;
            Nome = nome;
            Email = email;
            ChavePrivada = chavePrivada;
            Registro = registro;
            Status = status;

            ValidationRules(true);
        }
        
        public void InativarUsuario()
        {
            Status = false;
        }
        public void HashChavePrimaria(string chaveprimaria) 
        {
            ChavePrivada=chaveprimaria.HashPassword();
        }
        

        public Notify Notification => _notify;
        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string ChavePrivada { get; protected set; }
        public string Registro { get; protected set; }
        public bool Status { get; protected set; }

        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (string.IsNullOrEmpty(Nome))
            {
                _notify.Add("Nome não informado");
            }
            if (string.IsNullOrEmpty(Email))
            {
                _notify.Add("Email não informado");
            }
          
        }
    }
}
