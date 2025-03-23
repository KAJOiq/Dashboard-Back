using System.ComponentModel.DataAnnotations;

namespace projects.Dtos.Account;
public class RegisterDto
{
    [Required]
    public string UserName {get; set;} = string.Empty;
    [Required]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;
    [Required]
    public string PhoneNumber {get; set;} = string.Empty;
    [Required]
    public string Password {get; set;} = string.Empty;
    [Required]
    public string Sex {get; set;} = string.Empty;
    [Required]
    public DateTime DOB {get; set;} 
    [Required]
    public string RoleId {get; set;} = string.Empty;
}
