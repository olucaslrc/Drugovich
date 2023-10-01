using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.DTOs.App
{
    public class AddCustomerDTO
    {
        public string? Name { get; set; }
        public string? CNPJ { get; set; }
        public Guid? FK_CustomerGroup { get; set; }
    }
}
