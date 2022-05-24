using RandomFact.Core.Contracts.Services;
using RandomFact.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomFact.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: The following classes have been created to display sample data. Delete these files once your app is using real data.
    // 1. Contracts/Services/ISampleDataService.cs
    // 2. Services/SampleDataService.cs
    // 3. Models/SampleCompany.cs
    // 4. Models/SampleOrder.cs
    // 5. Models/SampleOrderDetail.cs
    public class FactService : IFactDataService
    {
        private List<Fact> _allOrders;

        public FactService()
        {
        }

        private static IEnumerable<Fact> AllOrders()
        {
            // The following is order summary data
            var companies = AllCompanies();
            return companies;
        }

        private static IEnumerable<Fact> AllCompanies()
        {
            return new List<Fact>()
            {
                new Fact()
                {
                    Id = 99,
                    Title = "Company A",
                    Content = "Maria Andhbadhadhsajabsobasjlcbasljbcaljsbcljasbcljasbjlcasbjlcbasjlers",
                    Url="http://"
                },
                new Fact()
                {
                    Id = 98,
                    Title = "Company B",
                    Content = "HAHAH",
                    Url="http://"
                }
            };
        }

        public async Task<IEnumerable<Fact>> GetContentGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<Fact>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }

        public async Task<IEnumerable<Fact>> GetGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<Fact>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }

        public async Task<IEnumerable<Fact>> GetListDetailsDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<Fact>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }
    }
}
