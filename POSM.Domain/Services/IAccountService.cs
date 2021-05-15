using POSM.EntityFramework.Models;
using System.Threading.Tasks;

namespace POSM.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}
