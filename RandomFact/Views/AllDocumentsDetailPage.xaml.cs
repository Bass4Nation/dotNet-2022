using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using RandomFact.Contracts.Services;
using RandomFact.ViewModels;
using RandomFact.Helpers;

namespace RandomFact.Views
{
    public sealed partial class AllDocumentsDetailPage : Page
    {
        public AllDocumentsDetailViewModel ViewModel { get; }
        private Helper helper = new Helper();

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

        private void delBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {

            int id = (int)ViewModel.Item.Id;
            helper.DeleteDBDataAsync(id);
        }

        private void editBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            changeVisibility();
        }
        private void svBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            changeVisibility();
            int id = (int)ViewModel.Item.Id;

            helper.PutDBDataAsync(id, TitleField.Text, ContentField.Text);
        }


        private void retBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            changeVisibility();
        }

        private void changeVisibility()
        {
            if (editTitle.Visibility.Equals(Microsoft.UI.Xaml.Visibility.Visible))
            {
                editTitle.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                editContent.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                TitleField.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                ContentField.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                svBtn.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                retBtn.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                //------------------------------------------------------------------
                editBtn.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                delBtn.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                content.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                title.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
            else
            {
                //------------------------------------------------------------
                editTitle.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                editContent.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                TitleField.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                ContentField.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                svBtn.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                retBtn.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                //----------------------------------------------------------------
                editBtn.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                delBtn.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                title.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                content.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }

        }
    }
}
