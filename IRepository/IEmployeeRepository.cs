using CoreMongoDBCrud.Models;
using System.Collections.Generic;

namespace CoreMongoDBCrud.IRepository
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee employee);
        Employee Get(string employeeId);
        List<Employee> Gets();
        string Delete(string employeeId);
    }
}




