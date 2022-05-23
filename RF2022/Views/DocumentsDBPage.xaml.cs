using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using RF2022.ViewModels;

namespace RF2022.Views
{
    // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on DataGridPage.xaml.
    // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
    public sealed partial class DocumentsDBPage : Page
    {
        public DocumentsDBViewModel ViewModel { get; }

        public DocumentsDBPage()
        {
            ViewModel = Ioc.Default.GetService<DocumentsDBViewModel>();
            InitializeComponent();
        }
    }
}
