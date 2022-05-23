using System;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using RF2022.Contracts.ViewModels;
using RF2022.Core.Contracts.Services;
using RF2022.Core.Models;

namespace RF2022.ViewModels
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
