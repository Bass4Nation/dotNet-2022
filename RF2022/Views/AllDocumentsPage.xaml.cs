using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using RF2022.ViewModels;

namespace RF2022.Views
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
