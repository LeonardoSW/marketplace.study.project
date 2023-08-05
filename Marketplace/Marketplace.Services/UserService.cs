using Marketplace.Domain.Interfaces.Services;

namespace Marketplace.Services
{
    public class UserService : IUserService
    {
        public UserService()
        { }

        public async Task<bool> QualquerCoisa(string mensagem)
        {
            Console.WriteLine("Manipular essa mensagem fazendo qualquer coisa");

            return true;
        }

        public Task SaveUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}