using projects.Dtos.Account;
using projects.Models;

namespace projects.Mappers;
public static class AccountMapper
{
    public static NewUserDto ToUserDto(this User userModel,string token)
    {
        return new NewUserDto(
            userModel.Email??"",
            userModel.UserName??"",
            token
        );
    }
    public static User ToUserFormCreateDTO(this RegisterDto register, string imagePath)
    {
        return new User
        {
            UserName = register.UserName,
            Email = register.Email,
            Sex = register.Sex,
            PhoneNumber = register.PhoneNumber,
            DOB = register.DOB.ToUniversalTime(),
        };
    }
}
