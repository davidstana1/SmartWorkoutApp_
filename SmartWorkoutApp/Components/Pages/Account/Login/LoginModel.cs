using System.ComponentModel.DataAnnotations;

namespace SmartWorkoutApp.Components.Pages.Account.Login;

public class LoginModel
{
    [Required(AllowEmptyStrings = false,ErrorMessage = "Please provide Username")]
    public string? Email { get; set; }
    [Required(AllowEmptyStrings = false,ErrorMessage = "Please provide password")]
    public string? Password { get; set; }
}