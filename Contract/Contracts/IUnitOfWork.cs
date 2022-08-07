using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Contracts
{
    public interface IUnitOfWork
    {
            IDepartmentRepository Departments { get; }
            IPersonRepository Persons { get; }
            IPositionRepository Positions { get; }
            ISalaryRepository Salaries { get; }
            void Save();

    }
}
