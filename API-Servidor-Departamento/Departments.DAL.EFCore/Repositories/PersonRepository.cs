using Departments.DAL.EFCore.Core;
using Departments_Core.Entities;
using Departments_Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments.DAL.EFCore.Repositories
{
    public class PersonRepository: EfRepository<Person>, IPersonRepository
    {
        public PersonRepository(DepartmentContext context): base(context)
        {

        }

        public int GetPersonByCI(string CI)
        {
            return this._dbContext.Persons.Count(p => p.CI == CI);
        }
    }
}
