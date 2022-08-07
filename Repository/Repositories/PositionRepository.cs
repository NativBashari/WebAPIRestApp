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
    internal class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(APIDbContext context) : base(context)
        {

        }
    }
}
