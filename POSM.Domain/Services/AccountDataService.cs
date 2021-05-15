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
    public class AccountDataService : IAccountService
    {
        private readonly POSMContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(POSMContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(Account entity)
        {
            return await _nonQueryDataService.Delete(entity);
        }

		public IList<Account> GetAll(params Expression<Func<Account, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetByEmail(string email)
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

		public IList<Account> GetList(Func<Account, bool> where, params Expression<Func<Account, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public Account GetSingle(Func<Account, bool> where, params Expression<Func<Account, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public async Task<Account> Update(Account entity)
        {
            return await _nonQueryDataService.Update(entity);
        }
    }
}
