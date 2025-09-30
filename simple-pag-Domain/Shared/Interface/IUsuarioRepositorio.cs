using simple_pag_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Shared.Interface
{
    public interface IUsuarioRepositorio
    {
        #region Usuarios
        Task AddUsuario(Usuario usuario);
        IList<Usuario> GetAllUsuarios();
        Task<Usuario?> FindUsuarioById(string id);      
        Task UpdateAsync(Usuario dados);
        Task<Usuario?> GetUsuariobyEmail(string email);
        Task<bool> CheckIfEmailExist(string value);
        Task<bool> CheckUserIdlExist(string id);
        Task<Usuario> FindContatoByUsuario(string id);
        #endregion

        #region Contatos
        Task AddContatoUsuario(Contato conato);
        Task<bool> CheckIContatoExist(string id);
        Task<Contato?> FindContatoById(string id);
        Task UpdateAsync(Contato dados);
        //Task<IList<Contato>> FindContatoByUsuarioId(string id);

        #endregion
    }
}
