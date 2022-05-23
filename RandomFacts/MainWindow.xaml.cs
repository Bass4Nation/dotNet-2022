using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

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
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // When it starts it will load in data from Wiki DB.
            GetFact();
        }





        private void NextBtn_OnClick(object sender, RoutedEventArgs e)
        {
            GetFact();
        }

        private void SourceBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Helper helper = new Helper();
                helper.DeleteDBDataAsync(2);
                sourceBtn.Content = "Source Btn pressed";
                string title = factTitle.Text;

                helper.PutDBDataAsync(1, "hshs", "OOOh modfmosdmfo");

                string url = "https://en.wikipedia.org/wiki/" + title;

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                throw;
            }

        }


        private void MenuBtn_OnClick(object sender, RoutedEventArgs e)
        {
            frontPage.NavigateToType(typeof(MenuPage),null,null);
        }




        public void GetFact()
        {
            Helper helper = new Helper();
            var doc = helper.GetDBDataAsync(2);
        }


        public ArrayList GetWikiDataRest(string command, int returnValues)
        {
            ArrayList arr = new ArrayList();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = @"donau.hiof.no",
                    InitialCatalog = "kristoss",
                    IntegratedSecurity = false,
                    UserID = "kristoss",
                    Password = "Z1E3Q5qVbj"
                };

                using (SqlConnection conn = new SqlConnection(builder.ToString()))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = command;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    for (int i = 0; i < returnValues; i++)
                                    {
                                        arr.Add(reader.GetString(i));
                                    }
                                }
                            }
                        }
                    }
                }



            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return arr;
        }
    }
}
