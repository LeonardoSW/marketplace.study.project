using Marketplace.Domain.Models.Input;

namespace Marketplace.Domain.Entities
{
    public class UserEntity
    {
        public long? Id { get; private set; }
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }

        public UserEntity()
        { }
        public UserEntity(NewUserInputModel input)
        {
            Cpf = input.Cpf;
            Name = input.Name;
            Email = input.Email;
            Telephone = input.Telephone;
        }
    }
}
