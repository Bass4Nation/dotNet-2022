using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using RF2022.Contracts.Services;
using RF2022.ViewModels;

namespace RF2022.Views
{
    public sealed partial class AllDocumentsDetailPage : Page
    {
        public AllDocumentsDetailViewModel ViewModel { get; }

        public AllDocumentsDetailPage()
        {
            ViewModel = Ioc.Default.GetService<AllDocumentsDetailViewModel>();
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                var navigationService = Ioc.Default.GetService<INavigationService>();
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
