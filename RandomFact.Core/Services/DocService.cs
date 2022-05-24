using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RandomFact.Core.Contracts.Services;
using RandomFact.Core.Models;
using RandomFact.Core.Helpers;

namespace RandomFact.Core.Services
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
        private Helper helper = new Helper();


        public DocService()
        {
        }

        private  IEnumerable<Doc> AllOrders()
        {
            // The following is order summary data
            var docRepo = DocRepo();
            foreach (var doc in docRepo)
            {
                helper.PostDBDataAsync((int) doc.Id, doc.Title, doc.Content);
            }

            return docRepo;
        }

        private static IEnumerable<Doc> DocRepo()
        {
            return new List<Doc>()
            {
                new Doc()
                {
                    Id = 1,
                    Title = "Company A",
                    Content = "Maria Andhbadhadhsajabsobasjlcbasljbcaljsbcljasbcljasbjlcasbjlcbasjlers"
                },
                new Doc()
                {
                    Id = 2,
                    Title = "Company B",
                    Content = "HAHAH"
                }
            };
        }

        public async Task<IEnumerable<Doc>> GetContentGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = await helper.GetAllDBDataAsync();
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
