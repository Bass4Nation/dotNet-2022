using System.Collections.Generic;
using System.Threading.Tasks;

using RF2022.Core.Models;

namespace RF2022.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface IDocDataService
    {
        Task<IEnumerable<Doc>> GetContentGridDataAsync();

        Task<IEnumerable<Doc>> GetGridDataAsync();

        Task<IEnumerable<Doc>> GetListDetailsDataAsync();
    }
}
