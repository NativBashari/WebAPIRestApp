using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Contracts;
using Entities;
using Repository.Repositories;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private APIDbContext _context;
        private IDepartmentRepository? _departmentRepository;
        private IPersonRepository? _personRepository;
        private IPositionRepository? _positionRepository;
        private ISalaryRepository? _salaryRepository;

        public UnitOfWork(APIDbContext context)
        {
            this._context = context;
        }

        public void Save() => _context.SaveChanges();

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository == null) _departmentRepository = new DepartmentRepository(_context);
                return
                      _departmentRepository;
            }
        }

        public IPersonRepository Persons
        {
            get
            {
                if (_personRepository == null) _personRepository = new PersonRepository(_context);
                return _personRepository;
            }
        }

        public IPositionRepository Positions
        {
            get
            {
                if (_positionRepository == null) _positionRepository = new PositionRepository(_context);
                return _positionRepository;
            }
        }

        public ISalaryRepository Salaries
        {
            get
            {
                if (_salaryRepository == null) _salaryRepository = new SalaryRepository(_context);
                return _salaryRepository;
            }
        }
    }
}
