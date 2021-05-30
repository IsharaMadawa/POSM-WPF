using POSM.EntityFramework.Models;
using POSM.EntityFramework.Services.Common;
using System.Threading.Tasks;

namespace POSM.Domain.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
    }
}
