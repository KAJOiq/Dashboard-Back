using Microsoft.AspNetCore.Identity;

namespace projects.Models;
public class User : IdentityUser
{
    public string Sex { set; get; } = string.Empty;
    public DateTime DOB { get; set; }
}
