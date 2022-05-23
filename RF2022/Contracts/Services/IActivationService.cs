using System.Threading.Tasks;

namespace RF2022.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
