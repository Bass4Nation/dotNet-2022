using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RandomFacts
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Documents : Window
    {
        public Documents()
        {
            this.InitializeComponent();
            GetCountDocuments();
        }

        private Helper helper = new Helper();

        private void GetCountDocuments()
        {


            string cmdDoc = "select dbo.Documents.title, dbo.Documents.text from dbo.Documents";
            //ArrayList arr = helper.GetAllDBData(cmdDoc, count);

            //Debug.WriteLine(arr[0]);






        }

        public void GetDoc()
        {
            Helper helper = new Helper();
            helper.GetDBDataAsync(2);
        }

        public void GetAllDocs()
        {
            Helper helper = new Helper();
            helper.GetAllDBDataAsync();
        }

    }
}
