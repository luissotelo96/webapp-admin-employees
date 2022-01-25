using AdminEmployees.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminEmployees.DataAcces
{
    public interface IEmployeesData

    {
        IEnumerable<Employee> GetEmployees(string parameter);
        Employee GetById(int id);
        Employee Add (Employee newEmployee);
        Employee Update (Employee updatedEmployee); 
        Employee Delete (int id);
        int Commit();

    }
}
