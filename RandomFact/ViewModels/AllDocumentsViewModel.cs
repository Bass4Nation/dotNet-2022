using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using RandomFact.Contracts.Services;
using RandomFact.Contracts.ViewModels;
using RandomFact.Core.Contracts.Services;
using RandomFact.Core.Models;
using RandomFact.ViewModels;

namespace RandomFact.ViewModels
{
    public class AllDocumentsViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ISampleDataService _sampleDataService;
        private Helper helper = new Helper();
       
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Doc>(OnItemClick));

        public ObservableCollection<Doc> Source { get; } = new ObservableCollection<Doc>();

        public AllDocumentsViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            _navigationService = navigationService;
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // Replace this with your actual data
            //var data = await _sampleDataService.GetContentGridDataAsync();
            var data = await helper.GetAllDBDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnItemClick(Doc clickedItem)
        {
            if (clickedItem != null)
            {
                _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
                _navigationService.NavigateTo(typeof(AllDocumentsDetailViewModel).FullName, clickedItem.Id);
            }
        }
    }
}
