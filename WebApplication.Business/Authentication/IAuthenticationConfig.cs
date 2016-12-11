namespace WebApplication.Business.Authentication
{
    public interface IAuthenticationConfig
    {
        string Username { get; }
        string Password { get; }
        string AuthorizationCode { get; }
    }
}