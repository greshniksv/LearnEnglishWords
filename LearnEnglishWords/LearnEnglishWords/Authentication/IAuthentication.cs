
using System.Security.Principal;
using System.Web;
using LearnEnglishWords.Database.Entities;

namespace LearnEnglishWords.Authentication
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool isPersistent);
        
        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}