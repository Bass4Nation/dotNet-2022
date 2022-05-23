using System;
using System.Collections.ObjectModel;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using RandomFact.Contracts.ViewModels;
using RandomFact.Core.Contracts.Services;
using RandomFact.Core.Models;

namespace RandomFact.ViewModels
{
    public class DocumentViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private Doc _selected;
        private Helper helper = new Helper();


        public Doc Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ObservableCollection<Doc> SampleItems { get; private set; } = new ObservableCollection<Doc>();

        public DocumentViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            SampleItems.Clear();

            // Replace this with your actual data
            //var data = await _sampleDataService.GetListDetailsDataAsync();
            var data = await helper.GetAllDBDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        public void EnsureItemSelected()
        {
            if (Selected == null)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
