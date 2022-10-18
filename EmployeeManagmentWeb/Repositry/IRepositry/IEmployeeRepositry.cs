using EmployeeManagmentWeb.Models;

namespace EmployeeManagmentWeb.Repositry.IRepositry
{
    public interface IEmployeeRepositry
    {
        Employee GetEmployee(int id);
    }
}
