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
        #region Usuarios
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
        public async Task UpdateAsync(Usuario dados)
        {
            _context.Usuarios.Update(dados);
            _context.Entry(dados).Property(p => p.Status).IsModified = false;
            _context.Entry(dados).Property(p => p.ChavePrivada).IsModified = false;
            _context.Entry(dados).Property(p => p.Registro).IsModified = false;
            await _context.SaveChangesAsync();

        }
        public async Task<Usuario?> GetUsuariobyEmail(string email)
        {
            var data = await _context.Usuarios.FirstOrDefaultAsync(i => i.Email == email);
            if (data == null)
            {
                data = new Usuario();
                data.Notification.Add("Usuário não encontrado");
            }
            return data;
        }
        public async Task<Usuario> FindContatoByUsuario(string id)
        {
            var result = await _context.Usuarios.Include(u => u.Contatos)
                .FirstOrDefaultAsync(u => u.Id == id);
            return result;

        }
        public async Task<bool> CheckIfEmailExist(string value)
        {
            var data = await _context.Usuarios.FirstOrDefaultAsync(i => i.Email == value);
            if (data == null)
            {
                return false;
            }
            return true;

        }
        public async Task<bool> CheckUserIdlExist(string id)
        {
            var data = await _context.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                return false;
            }
            return true;

        }
        public IList<Usuario> GetAllUsuarios()
        {
            return _context.Usuarios.Where(a => a.Status.Equals(true)).ToList();
        }
        #endregion

        #region Contatos
        public async Task AddContatoUsuario(Contato conato)
        {
            await _context.Contatos.AddAsync(conato);
            _context.SaveChanges();
        }     
        public async Task<Contato?> FindContatoById(string id)
        {
            var result = await _context.Contatos.FindAsync(id);
            return result;
        }            
        public async Task<bool> CheckIContatoExist(string id)
        {
            var data = await _context.Contatos.FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                return false;
            }
            return true;

        }
        public async Task UpdateAsync(Contato dados)
        {
            _context.Contatos.Update(dados);
            _context.Entry(dados).Property(p => p.Status).IsModified = false;
            _context.Entry(dados).Property(p => p.Registro).IsModified = false;
            _context.Entry(dados).Property(p => p.UsuarioId).IsModified = false;

            await _context.SaveChangesAsync();
        }


        #endregion
    }
}
