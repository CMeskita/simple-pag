using simple_pag_Domain.Models;

namespace simple_pag_Domain.Entity
{
    public class Usuario
    {
        public Usuario(string nome, string email, string chavePrivada)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Nome = nome;
            Email = email;
            ChavePrivada = chavePrivada;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            Status = true;

           
        }
        public Usuario(string id, string nome, string email, string chavePrivada,string registro,bool status)
        {
            Id = id;
            Nome = nome;
            Email = email;
            ChavePrivada = chavePrivada;
            Registro = registro;
            Status = status;
        }
        
        public void InativarUsuario()
        {
            Status = false;
        }
        public void HashChavePrimaria(string chaveprimaria) 
        {
            ChavePrivada=chaveprimaria.HashPassword();
        }

        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string ChavePrivada { get; protected set; }
        public string Registro { get; protected set; }
        public bool Status { get; protected set; } 
    }
}
