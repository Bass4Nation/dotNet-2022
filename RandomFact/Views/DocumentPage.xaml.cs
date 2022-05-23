using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using RandomFact.ViewModels;

namespace RandomFact.Views
{
    public sealed partial class DocumentPage : Page
    {
        public DocumentViewModel ViewModel { get; }

        public DocumentPage()
        {
            ViewModel = Ioc.Default.GetService<DocumentViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {
            if (e == ListDetailsViewState.Both)
            {
                ViewModel.EnsureItemSelected();
            }
        }
    }
}
