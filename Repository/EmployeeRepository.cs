using CoreMongoDBCrud.IRepository;
using CoreMongoDBCrud.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CoreMongoDBCrud.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Employee> _employeeTable = null;

        public EmployeeRepository()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _mongoClient.GetDatabase("OfficeDB");
            _employeeTable = _database.GetCollection<Employee>("Employees");
        }

        public string Delete(string employeeId)
        {
            var result = _employeeTable.DeleteOne(x => x.Id == employeeId);
            return result.DeletedCount > 0 ? "Deleted" : "Not Found";
        }

        public Employee Get(string employeeId)
        {
            return _employeeTable.Find(x => x.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> Gets()
        {
            return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList();
        }

        public Employee Save(Employee employee)
        {
            var existingEmployee = _employeeTable.Find(x => x.Id == employee.Id).FirstOrDefault();
            if (existingEmployee == null)
            {
                _employeeTable.InsertOne(employee);
            }
            else
            {
                _employeeTable.ReplaceOne(x => x.Id == employee.Id, employee);
            }
            return employee;
        }
    }
}

