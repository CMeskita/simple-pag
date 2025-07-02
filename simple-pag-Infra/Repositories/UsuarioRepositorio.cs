using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
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
        public async Task AddContatoUsuario(Contato conato)
        {
            await _context.Contatos.AddAsync(conato);
            _context.SaveChanges();
        }
        public async Task<Usuario?> FindUsuarioById(string id)
        {
            var result = await _context.Usuarios.FindAsync(id);
            return result;
        }
        public async Task UpdateAsync(Usuario dados)
        {
            _context.Usuarios.Update(dados);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario?> GetUsuariobyEmail(string email)
        {           
            var data = await _context.Usuarios.FirstOrDefaultAsync(i => i.Id == email);
            if (data == null)
            {
                data = new Usuario();
                data.Notification.Add("Usuário não encontrado");
            }
           return data;
        }
        public async Task<bool> CheckIfEmailExist(string value)
        {
            var data = await _context.Usuarios.FirstOrDefaultAsync(i => i.Id == value);
            if (data == null)
            {
                return false;
            }
            return true;

        }

        public Task<IList<Usuario>> GetUsuariosPaginadas(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.Where(a => a.Status.Equals(true)).ToListAsync();
        }
    }
}
