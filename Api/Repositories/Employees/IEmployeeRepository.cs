using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Api
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<bool> MyCustomRepositoryMethodExampleAsync();
    }
}
