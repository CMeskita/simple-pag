using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Infra.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Context _context;

        public UsuarioRepositorio(Context context)
        {
            _context = context;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            _context.SaveChanges();

        }

        public bool ExisteUsuario(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> FindUsuarioById(string id)
        {
            var result = await _context.Usuarios.FindAsync(id);
            return result;
        }

        public async Task<IList<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public Task InativarUsuario(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Usuario dados)
        {
            _context.Usuarios.Update(dados);
            await _context.SaveChangesAsync();
        }

      
    }
}
