using Microsoft.EntityFrameworkCore;
using POSM.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSM.EntityFramework
{
	public class POSMContextFactory
	{
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public POSMContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public POSMContext CreateDbContext()
        {
            DbContextOptionsBuilder<POSMContext> options = new DbContextOptionsBuilder<POSMContext>();

            _configureDbContext(options);

            return new POSMContext(options.Options);
        }
    }
}
