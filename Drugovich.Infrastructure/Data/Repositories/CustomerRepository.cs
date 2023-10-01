using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DrugovichDbContext context): base(context)
        {
        }
    }
}
