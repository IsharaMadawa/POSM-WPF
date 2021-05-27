using POSM.EntityFramework.Models;
using POSM.EntityFramework.Services.Common;
using System.Threading.Tasks;

namespace POSM.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<User> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}
