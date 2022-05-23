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
        public DocContext(DbContextOptions<DocContext> options)
            : base(options)
        {
        }

        public DbSet<Doc> DocItems { get; set; }

        public List<Doc> GetAllDocumentData()
        {
            List<Doc> arr = new List<Doc>();
            
            try
            {
                string sqlCmd = "select dbo.Documents.Id, dbo.Documents.Title, dbo.Documents.Text from dbo.Documents";

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
                            cmd.CommandText = sqlCmd;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    for (int i = 0; i < GetCountAllDocumentData(); i++)
                                    {

                                        Debug.WriteLine(reader);
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

        /// <summary>
        /// Count how many Item it is in this Document DB
        /// </summary>
        /// <returns></returns>
        public int GetCountAllDocumentData()
        {
            int count = 0;
            try
            {
                string sqlCmd = "select count(*) from dbo.Documents";

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
                            cmd.CommandText = sqlCmd;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    count = reader.GetInt32(0);
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

            return count;
        }

    }


}