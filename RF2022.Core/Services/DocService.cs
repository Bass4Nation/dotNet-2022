using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RF2022.Core.Contracts.Services;
using RF2022.Core.Models;

namespace RF2022.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: The following classes have been created to display sample data. Delete these files once your app is using real data.
    // 1. Contracts/Services/ISampleDataService.cs
    // 2. Services/SampleDataService.cs
    // 3. Models/SampleCompany.cs
    // 4. Models/SampleOrder.cs
    // 5. Models/SampleOrderDetail.cs
    public class DocService : IDocDataService
    {
        private List<Doc> _allOrders;

        public DocService()
        {
        }

        private static IEnumerable<Doc> AllOrders()
        {
            // The following is order summary data
            var companies = AllCompanies();
            return companies;
        }

        private static IEnumerable<Doc> AllCompanies()
        {
            return new List<Doc>()
            {
                new Doc()
                {
                    Id = 99,
                    Title = "Company A",
                    Content = "Maria Andhbadhadhsajabsobasjlcbasljbcaljsbcljasbcljasbjlcasbjlcbasjlers"
                },
                new Doc()
                {
                    Id = 98,
                    Title = "Company B",
                    Content = "HAHAH"
                }
            };
        }

        public async Task<IEnumerable<Doc>> GetContentGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<Doc>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }

        public async Task<IEnumerable<Doc>> GetGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<Doc>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }

        public async Task<IEnumerable<Doc>> GetListDetailsDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = new List<Doc>(AllOrders());
            }

            await Task.CompletedTask;
            return _allOrders;
        }
    }
}
