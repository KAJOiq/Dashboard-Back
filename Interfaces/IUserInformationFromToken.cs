using project.Dtos.Account;

namespace DashboardBackend.Interfaces;
public interface IUserInformationFromToken
{
    Task<project.Dtos.Account.UserInfoDto> GetUserIdFromDatabase();
}
