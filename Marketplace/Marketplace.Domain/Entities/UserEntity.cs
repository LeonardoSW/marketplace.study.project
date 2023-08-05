namespace Marketplace.Domain.Entities
{
    public class UserEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
    }
}
