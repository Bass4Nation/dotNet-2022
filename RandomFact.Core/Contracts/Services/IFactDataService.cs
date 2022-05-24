using RandomFact.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomFact.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface IFactDataService
    {

        Task<IEnumerable<Fact>> GetContentGridDataAsync();

        Task<IEnumerable<Fact>> GetGridDataAsync();

        Task<IEnumerable<Fact>> GetListDetailsDataAsync();
    }
}
