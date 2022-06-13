using Countify.Models;

namespace Countify.services
{
    public interface IAuthService
    {
        string Hash(string s);
        bool VerifyHash(string hash, string passwordProvided);
        string login(User user);
    }
}