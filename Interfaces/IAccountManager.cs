using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using projects.Dtos.Account;
using projects.Models;

namespace projects.Interfaces;
public interface IAccountManager
{
    Task<List<User>> GetUsers(string position);
    Task<bool> RoleExistsAsync(string roleName);
    Task<IdentityResult> CreateRoleAsync(CreateRoleDto role);
    Task<IdentityRole?> FindRoleByNameAsync(GetRoleDto dto);
    Task<IdentityResult> AddClaimToRoleAsync(CreateRoleDto dto, Claim claim);
}
