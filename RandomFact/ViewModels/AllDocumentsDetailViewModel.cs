using System;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using RandomFact.Contracts.ViewModels;
using RandomFact.Core.Contracts.Services;
using RandomFact.Core.Models;

namespace RandomFact.ViewModels
{
    public class AllDocumentsDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IDocDataService _sampleDataService;
        private Doc _item;

        public Doc Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public AllDocumentsDetailViewModel(IDocDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is long orderID)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First(i => i.Id == orderID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
