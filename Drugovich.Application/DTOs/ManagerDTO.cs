using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.DTOs
{
    public class ManagerDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
    }
}
