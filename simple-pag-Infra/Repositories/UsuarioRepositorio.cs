using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;


namespace simple_pag_Infra.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public async Task AddUsuario (Usuario usuario) {

            _usuarios.Add(usuario);
            await Task.CompletedTask;

        }

        public bool ExisteUsuario(string email) {

           var results = _usuarios.FirstOrDefault(u => u.Email == email);

           if (results != null)
           {   
                return true;
           }
           else
           {
                return false;
           }
        }

        public IList<Usuario> GetAllUsuarios () {

            var results = _usuarios.ToList();

            return results;

        }

        public async Task<Usuario> FindUsuarioById (string id) {

         /*Infezlimente não foi possível realizar a Find pois o id 
         é anulável, ao menos é o que diz a IDE         */   
         var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
         return await Task.FromResult(usuario);

        }

        public async Task InativarUsuario (string id) {

           var usuario = _usuarios.FirstOrDefault(u => u.Id == id);

           if (usuario != null)
           {
              usuario.GetType().GetProperty("Status")?.SetValue(usuario, false);

           }
            
           await Task.CompletedTask;
        }

        public async Task UpdateAsync(Usuario dados) {

            var usuario = _usuarios.FirstOrDefault(u => u.Id == dados.Id);

            if (usuario != null)
            {
                usuario.GetType().GetProperty("Nome")?.SetValue(usuario, dados.Nome);
                usuario.GetType().GetProperty("Email")?.SetValue(usuario, dados.Email);
                usuario.GetType().GetProperty("ChavePrivada")?.SetValue(usuario, dados.ChavePrivada);
                usuario.GetType().GetProperty("Registro")?.SetValue(usuario, dados.Registro);

                await Task.CompletedTask;
            }
            else
            {
                await Task.CompletedTask;
            }
        }
    }
}
