using AdminEmployees.DataAcces;
using AdminEmployees.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AdminEmployees2.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly IEmployeesData employeesData;
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public ListModel(IEmployeesData employeesData)
        {
            this.employeesData = employeesData;
        }

        public void OnGet()
        {
            Employees = employeesData.GetEmployees(SearchTerm);
        }
    }
}
