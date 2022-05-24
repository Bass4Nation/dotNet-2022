using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using RandomFact.Core.Models;

namespace RandomFact.Views
{
    public sealed partial class RandomFactDetailControl : UserControl
    {
        public Fact ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as Fact; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(Fact), typeof(RandomFactDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public RandomFactDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RandomFactDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
