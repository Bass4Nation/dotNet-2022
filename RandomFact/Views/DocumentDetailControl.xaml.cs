using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using RandomFact.Core.Models;

namespace RandomFact.Views
{
    public sealed partial class DocumentDetailControl : UserControl
    {
        public SampleOrder ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as SampleOrder; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(DocumentDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public DocumentDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DocumentDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
