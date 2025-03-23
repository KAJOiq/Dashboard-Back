using projects.Models;

namespace Ticket.Interfaces;
public interface ITokenService
{
    string CreateToken(User user);
}
