using CRUDOPS.DomainModels;
using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Infastructure.Database.Models.CRUDOPS.Models;

namespace CRUDOPS.Interfaces.Services
{
    public interface IRandomUserApiClientService
    {
        Task<List<UserResult>> GetRandomUsers(int page, int resultsPerPage);
        Task<UserResult> GetRandomUserById(string userId);
        Task<List<UserResult>> GetRandomUsers(int count);

    }
}
