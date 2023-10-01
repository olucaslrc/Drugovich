using Drugovich.Domain.Interfaces;
using Drugovich.Domain.Interfaces.Repositories;
using Drugovich.Infrastructure.Data.Repositories;

namespace Drugovich.Infrastructure
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DrugovichDbContext? _context;

        public UnityOfWork(DrugovichDbContext context)
        {
            _context = context;
        }

        private ICustomerRepository? _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                _customerRepository ??= new CustomerRepository(_context!);
                return _customerRepository;
            }
        }

        private IManagerRepository? _managerRepository;
        public IManagerRepository ManagerRepository
        {
            get
            {
                _managerRepository ??= new ManagerRepository(_context!);
                return _managerRepository;
            }
        }

        private ICustomerGroupRepository? _customerGroupRepository;
        public ICustomerGroupRepository CustomerGroupRepository
        {
            get
            {
                _customerGroupRepository ??= new CustomerGroupRepository(_context!);
                return _customerGroupRepository;
            }
        }
    }
}
