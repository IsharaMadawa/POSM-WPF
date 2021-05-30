using Microsoft.EntityFrameworkCore;
using POSM.EntityFramework;
using POSM.EntityFramework.Models;
using POSM.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POSM.Domain.Services
{
    public class UserDataService : IUserService
    {
        private readonly POSMContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public UserDataService(POSMContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }

        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(User entity)
        {
            return await _nonQueryDataService.Delete(entity);
        }

		public IList<User> GetAll(params Expression<Func<User, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetByEmail(string email)
		{
			throw new System.NotImplementedException();
		}

		public async Task<User> GetByUsername(string username)
		{
            using (POSMContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(a => a.Username == username);
            }
        }

		public IList<User> GetList(Func<User, bool> where, params Expression<Func<User, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public User GetSingle(Func<User, bool> where, params Expression<Func<User, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public async Task<User> Update(User entity)
        {
            return await _nonQueryDataService.Update(entity);
        }
    }
}
