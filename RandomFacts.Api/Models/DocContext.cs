using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RandomFacts.Api.Models
{
    public class DocContext : DbContext
    {
        public DocContext(DbContextOptions<DocContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "Donau.hiof.no",
                InitialCatalog = "kristoss",
                UserID = "kristoss",
                Password = "Z1E3Q5qVbj"
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
    }

        public DbSet<Doc> DocItems { get; set; }
        //DocItems.add( { new Doc { Id = 1, Title = "fwefe", Content = "COntetn" });

        //public void GetDocDbDonau()
        //{
        //    Debug.WriteLine("---------------------- KJØRER DENNE? --------------------------------");
        //    string command = "select dbo.Documents.id, dbo.Documents.Title, dbo.Documents.Text from dbo.Documents";
        //    //List<Doc> arr = new List<Doc>();
        //    try
        //    {

        //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        //        {
        //            DataSource = @"donau.hiof.no",
        //            InitialCatalog = "kristoss",
        //            IntegratedSecurity = false,
        //            UserID = "kristoss",
        //            Password = "Z1E3Q5qVbj"
        //        };

        //        using (SqlConnection conn = new SqlConnection(builder.ToString()))
        //        {
        //            conn.Open();
        //            if (conn.State == System.Data.ConnectionState.Open)
        //            {
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = command;
        //                    using (SqlDataReader reader = cmd.ExecuteReader())
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            DocItems.Add(new Doc { Id = reader.GetInt32(0), Title = reader.GetString(1), Content = reader.GetString(2) });
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //    //return arr;
        //}


    }


}