using Contract.Contracts;
using Entities;
using Entities.Models;

namespace Repository.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(APIDbContext context) : base(context)
        {

        }
    }
}
