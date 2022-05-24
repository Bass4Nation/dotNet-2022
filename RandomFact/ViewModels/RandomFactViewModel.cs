using CommunityToolkit.Mvvm.ComponentModel;
using RandomFact.Contracts.ViewModels;
using RandomFact.Core.Contracts.Services;
using RandomFact.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace RandomFact.ViewModels
{
    public class RandomFactViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IFactDataService _sampleDataService;
        private Fact _selected;

        public Fact Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ObservableCollection<Fact> SampleItems { get; private set; } = new ObservableCollection<Fact>();

        public RandomFactViewModel(IFactDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            SampleItems.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetListDetailsDataAsync();

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
