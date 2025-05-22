using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;


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

 
        public async Task<Usuario?> FindUsuarioById(string id)
        {
            var result = await _context.Usuarios.FindAsync(id);
            return result;
        }

        public async Task<IList<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<IList<Usuario>> GetUsuariosPaginadas(int pageNumber, int pageSize)
        {
            return await _context.Usuarios
                .Where(x => x.Status == true)
                .OrderBy(x => x.Registro) // Ordena por Valor
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task UpdateAsync(Usuario dados)
        {
            _context.Usuarios.Update(dados);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario?> GetUsuariobyEmail(string email)
        {
            var result = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            return result;
        }


    }
}
