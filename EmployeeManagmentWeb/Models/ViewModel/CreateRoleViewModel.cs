using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentWeb.Models.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
