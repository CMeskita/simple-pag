using simple_pag_Domain.Shared.Models;

namespace simple_pag_Domain.Shared.Interface
{ 
    public interface ILogInformacaoRepositorio
    {
        //Task AddLogInformation(LogInformation logInformation);
        Task<IEnumerable<LogInformation>> GetAllAsync();
        Task<LogInformation> GetByIdAsync(string id);
        Task AddAsync(LogInformation entity);
        Task UpdateAsync(string id, LogInformation entity);
        Task DeleteAsync(string id);
    }
}
