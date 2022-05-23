using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using RandomFact.ViewModels;

namespace RandomFact.Views
{
    public sealed partial class AllDocumentsPage : Page
    {
        public AllDocumentsViewModel ViewModel { get; }

        public AllDocumentsPage()
        {
            ViewModel = Ioc.Default.GetService<AllDocumentsViewModel>();
            InitializeComponent();
        }
    }
}
