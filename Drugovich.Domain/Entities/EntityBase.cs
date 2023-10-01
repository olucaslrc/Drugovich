using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugovich.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime Registered {  get; set; }
        public DateTime LastUpdate { get; set; }
    }
}