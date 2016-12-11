namespace WebApplication.Business.Authentication
{
    public interface IAuthenticationManager
    {
        bool ValidateCredentials(string username, string password, string authenticationCode);
        void SignIn(string username);
        void SignOut();
    }
}