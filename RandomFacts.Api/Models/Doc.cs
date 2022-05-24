using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomFacts.Api.Models
{
    public class Doc
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //public List<Doc> GetDocList(string connectionString)
        //{
        //    List<Doc> docList = new List<Doc>();
        //    SqlConnection con = new SqlConnection(connectionString);

        //    string sqlQuery = "select dbo.Documents.Id, dbo.Documents.Title, dbo.Documents.Text from dbo.Documents";

        //    con.Open();

        //    SqlCommand cmd = new SqlCommand(sqlQuery, con);

        //    SqlDataReader dr = cmd.ExecuteReader();

        //    if(dr != null)
        //    {
        //        while(dr.Read())
        //        {
        //            Doc doc = new Doc();
        //            doc.Id = Convert.ToInt32(dr["Id"]);
        //            doc.Title = dr["Title"].ToString();
        //            doc.Content = dr["Text"].ToString();

        //            docList.Add(doc);
        //        }
        //    }
        //    return docList;
        //}
    }
}
