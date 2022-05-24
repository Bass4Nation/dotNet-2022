using System.Collections.Generic;
using System.Threading.Tasks;

using RandomFact.Core.Models;

namespace RandomFact.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface IDocDataService
    {
        Task<IEnumerable<Doc>> GetContentGridDataAsync();

        Task<IEnumerable<Doc>> GetGridDataAsync();

        Task<IEnumerable<Doc>> GetListDetailsDataAsync();
    }
}
