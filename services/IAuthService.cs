using Countify.Models;

namespace Countify.services
{
    public interface IAuthService
    {
        string Hash(string s);
        string login(User user);
    }
}