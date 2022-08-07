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
    internal class SalaryRepository : RepositoryBase<Salary>, ISalaryRepository
    {
        public SalaryRepository(APIDbContext context) : base(context)
        {
        }

    }
}
