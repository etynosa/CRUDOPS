using CRUDOPS.DomainModels;
using CRUDOPS.Infastructure.Database.Models;

namespace CRUDOPS.Interfaces.Services
{
    public interface IRandomUserApiClientService
    {
        Task<List<User>> GetRandomUsers(int page, int resultsPerPage);
        Task<User> GetRandomUserById(string userId);
        Task<List<User>> GetRandomUsers(int count);
    }
}
