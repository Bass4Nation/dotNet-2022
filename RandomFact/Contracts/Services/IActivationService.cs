using System.Threading.Tasks;

namespace RandomFact.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
