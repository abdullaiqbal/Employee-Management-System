using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentWeb.Models.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
