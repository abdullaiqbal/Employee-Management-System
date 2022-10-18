using EmployeeManagmentWeb.Models;
using EmployeeManagmentWeb.Repositry.IRepositry;

namespace EmployeeManagmentWeb.Repositry
{
    public class MockEmployeeRepositry : IEmployeeRepositry
    {
        private List<Employee> _employees;
        public MockEmployeeRepositry()
        {
            _employees = new List<Employee>
            {
                new Employee(){Id=1,Name="Abdullah",Email="abdullahiqbal@2gmail.com",Department="Computer"},
                new Employee(){Id=1,Name="Ali",Email="ali@2gmail.com",Department="Computer"},
                new Employee(){Id=1,Name="faizan",Email="faizan@2gmail.com",Department="math"}
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(u=>u.Id==id);
        }
    }
}
