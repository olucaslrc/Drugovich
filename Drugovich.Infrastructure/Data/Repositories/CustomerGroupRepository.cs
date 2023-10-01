using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Infrastructure.Data.Repositories
{
    public class CustomerGroupRepository : Repository<CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository(DrugovichDbContext context) : base(context)
        {
        }
    }
}
