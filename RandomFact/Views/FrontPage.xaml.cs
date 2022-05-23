using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using RandomFact.ViewModels;

namespace RandomFact.Views
{
    public sealed partial class FrontPage : Page
    {
        public FrontViewModel ViewModel { get; }

        public FrontPage()
        {
            ViewModel = Ioc.Default.GetService<FrontViewModel>();
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
