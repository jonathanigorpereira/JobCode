namespace JobCode.Core.Services
{
    public interface IAuthService
    {
        string GenerateToken(string email, string role);
    }
}
