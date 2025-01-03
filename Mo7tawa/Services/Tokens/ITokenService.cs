using Mo7tawa.DAL.Data.Models;

namespace Mo7tawa.Services.Tokens
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
