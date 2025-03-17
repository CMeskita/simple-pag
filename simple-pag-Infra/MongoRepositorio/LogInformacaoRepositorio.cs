using MongoDB.Driver;
using simple_pag_Domain.Interface;
using simple_pag_Domain.Models;


namespace simple_pag_Infra.MongoRepositorio
{
    public class LogInformacaoRepositorio : ILogInformacaoRepositorio
    {

        private readonly IMongoCollection<LogInformation> _information;
        private const string _collectionName = "LogsInformation";


        public LogInformacaoRepositorio(IMongoDatabase mongoContext)
        {
            _information = mongoContext.GetCollection<LogInformation>(_collectionName);
        }


        public Task<IEnumerable<LogInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LogInformation> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(LogInformation entity)
        {
            await _information.InsertOneAsync(entity);
        }

        public Task UpdateAsync(string id, LogInformation entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }


    }

}
