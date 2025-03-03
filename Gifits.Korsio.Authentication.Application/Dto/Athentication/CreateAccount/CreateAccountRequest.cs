namespace Gifits.Korsio.Authorization.Application.Dto.Athentication.CreateAccount
{
    public class CreateAccountRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}