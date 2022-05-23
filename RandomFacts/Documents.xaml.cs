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

using RandomFacts.Models;

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
            GetAllDocs();
        }

        private Helper helper = new Helper();


        /// <summary>
        /// Get a single document from the Database
        /// </summary>
        public void GetDoc()
        {

        }

        /// <summary>
        /// Get all documents in a Database
        /// </summary>
        public void GetAllDocs()
        {
            var docs = helper.GetAllDBDataAsync();

            
        }

    }
}
