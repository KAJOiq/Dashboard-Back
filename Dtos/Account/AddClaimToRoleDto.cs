namespace projects.Dtos.Account;
public class AddClaimToRoleDto
{
    public string RoleName { get; set; } = string.Empty;
    public string ClaimType { get; set; } = string.Empty;
    public string ClaimValue { get; set; } = string.Empty;
}
