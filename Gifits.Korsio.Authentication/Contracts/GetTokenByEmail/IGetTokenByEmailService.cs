namespace Gifits.Korsio.Authorization.Contracts.GetTokenByEmail
{
    public interface IGetTokenByEmailService
    {
        Task<string> GetTokenByEmail(string email);
    }
}
