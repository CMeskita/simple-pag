using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Registro = DateTime.UtcNow;
            Status = true;
        }

        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string ChavePrivada { get; protected set; }
        public DateTime Registro { get; protected set; }
        public bool Status { get; protected set; }

    }
}
