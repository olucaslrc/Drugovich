using Drugovich.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IManagerRepository ManagerRepository { get; }
        public ICustomerGroupRepository CustomerGroupRepository { get; }
    }
}
