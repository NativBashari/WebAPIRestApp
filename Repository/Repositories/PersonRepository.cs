using Contract.Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(APIDbContext context) : base(context)
        {
        }
    }
}
