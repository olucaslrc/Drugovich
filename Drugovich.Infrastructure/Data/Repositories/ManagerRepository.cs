using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Infrastructure.Data.Repositories
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        public ManagerRepository(DrugovichDbContext context) : base(context)
        {
        }
    }
}
