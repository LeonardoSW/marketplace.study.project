namespace Marketplace.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> QualquerCoisa(string mensagem);
        Task SaveUserAsync();
    }
}
