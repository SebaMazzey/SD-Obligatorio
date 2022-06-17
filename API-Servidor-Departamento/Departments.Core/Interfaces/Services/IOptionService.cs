using Departments_Core.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Interfaces.Services
{
    public interface IOptionService
    {
        List<Option> VotingOptions();
    }
}
