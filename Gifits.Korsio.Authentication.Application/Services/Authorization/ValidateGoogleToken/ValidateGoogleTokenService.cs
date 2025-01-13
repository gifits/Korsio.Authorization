using Google.Apis.Auth;

namespace Gifits.Korsio.Authorization.Application.Services.Authorization.ValidateGoogleToken
{
    public class ValidateGoogleTokenService
    {
        public async Task<string> Validate(string token)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(token);
                if (payload != null)
                    return payload.Email;

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
