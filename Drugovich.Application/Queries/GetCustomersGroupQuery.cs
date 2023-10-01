using Drugovich.Application.DTOs.App;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Queries
{
    public class GetCustomersGroupQuery : IRequest<List<CustomerGroupDTO>>
    {
    }
}
