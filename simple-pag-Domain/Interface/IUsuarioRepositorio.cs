using simple_pag_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Interface
{
    public interface IUsuarioRepositorio
    {
        Task AddUsuario(Usuario usuario);
        bool ExisteUsuario(string email);
        Task<IList<Usuario>> GetAllUsuarios();
        Task<Usuario?> FindUsuarioById(string id);
        Task InativarUsuario(string id);
        Task UpdateAsync(Usuario dados);
    }
}
