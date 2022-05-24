using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using RandomFact.ViewModels;
using RandomFact.Helpers;

namespace RandomFact.Views
{
    public sealed partial class AllDocumentsPage : Page
    {
        private Helper helper = new Helper();
        public AllDocumentsViewModel ViewModel { get; }

        public AllDocumentsPage()
        {
            ViewModel = Ioc.Default.GetService<AllDocumentsViewModel>();
            InitializeComponent();
        }

        private void newDocBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            changeVisibility();

        }

        private void svBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            changeVisibility();
            helper.PostDBDataAsync(TitleField.Text, ContentField.Text);
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
                newDocBtn.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                docItems.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                //content.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                //title.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
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
                newDocBtn.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                docItems.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                //title.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                //content.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }

        }

    }
}
