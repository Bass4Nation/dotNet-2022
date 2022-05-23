using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using RF2022.ViewModels;

namespace RF2022.Views
{
    public sealed partial class RandomFactPage : Page
    {
        public RandomFactViewModel ViewModel { get; }

        public RandomFactPage()
        {
            ViewModel = Ioc.Default.GetService<RandomFactViewModel>();
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
