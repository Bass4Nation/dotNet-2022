using System.Collections.Generic;
using System.Threading.Tasks;

using RF2022.Core.Models;

namespace RF2022.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface IFactDataService { 

        Task<IEnumerable<Fact>> GetContentGridDataAsync();

        Task<IEnumerable<Fact>> GetGridDataAsync();

        Task<IEnumerable<Fact>> GetListDetailsDataAsync();
    }
}
