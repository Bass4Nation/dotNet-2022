using System;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using RF2022.Contracts.ViewModels;
using RF2022.Core.Contracts.Services;
using RF2022.Core.Models;

namespace RF2022.ViewModels
{
    public class DocumentsDBViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IDocDataService _sampleDataService;

        public ObservableCollection<Doc> Source { get; } = new ObservableCollection<Doc>();

        public DocumentsDBViewModel(IDocDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
