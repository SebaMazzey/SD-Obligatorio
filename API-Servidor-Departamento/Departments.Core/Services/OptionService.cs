using Departments_Core.Interfaces.Repositories;
using Departments_Core.Interfaces.Services;
using Departments_Core.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Services
{
    public class OptionService: IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        public OptionService(IOptionRepository optionRepository)
        {
            this._optionRepository = optionRepository;
        }

        public List<Option> VotingOptions()
        {
            var options = _optionRepository.ListAllAsync().GetAwaiter().GetResult();
            return options.Select(o => new Option
            {
                Name = o.Name
            }).ToList();
        }
    }
}
