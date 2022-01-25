using AdminEmployees.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdminEmployees.DataAcces
{
    public class EmployeeMemoryData : IEmployeesData
    {
        readonly List<Employee> employees;

        public EmployeeMemoryData()
        {
            employees = new List<Employee>()
            {
                new Employee(){Id = 1, Document = "12345", Name = "Employee 1", Area = new Area(){ Id = 1, Name = "Area 1" }, SubArea = new SubArea(){ ID  = 1, Name = "Sub - Area 1" } },
                new Employee(){Id = 2, Document = "123456", Name = "Employee 2", Area = new Area(){ Id = 1, Name = "Area 2" }, SubArea = new SubArea(){ ID  = 1, Name = "Sub - Area 2" } },
                new Employee(){Id = 3, Document = "1234567", Name = "Employee 3", Area = new Area(){ Id = 1, Name = "Area 3" }, SubArea = new SubArea(){ ID  = 1, Name = "Sub - Area 3" } },
            };
        }
        public Employee Add(Employee employee)
        {
            employees.Add(employee);
            employee.Id = employees.Max(r => r.Id) + 1;
            return employee;
        }

        public int Commit()
        {
            return 0;
        }

        public Employee Delete(int id)
        {
            var employee = employees.SingleOrDefault(r => r.Id == id);

            if (employee != null)
            {
                employees.Remove(employee);
            }

            return employee;
        }

        public Employee GetById(int id)
        {
            return employees.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Employee> GetEmployees(string parameter)
        {
            return from e in employees
                   where string.IsNullOrEmpty(parameter) || (e.Name.StartsWith(parameter) || e.Document.StartsWith(parameter))
                   orderby e.Document
                   select e;

        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = employees.SingleOrDefault(r => r.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Area = updatedEmployee.Area;
                employee.SubArea = updatedEmployee.SubArea;
            }

            return employee;
        }
    }
}