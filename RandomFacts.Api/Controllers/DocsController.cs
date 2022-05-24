using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RandomFacts.Api.Models;

namespace RandomFacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly DocContext _context;

        public DocsController(DocContext context)
        {
            _context = context;
        }

        // GET: api/Docs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doc>>> GetDocItems()
        {
            //GetTest(_context.DocItems);
            List<Doc> list = GetDocDbDonau();
            foreach (Doc doc in list)
            {
                Debug.WriteLine(doc.Id);
                //_context.DocItems.Add(doc);
            }
            //await _context.SaveChangesAsync();
            return await _context.DocItems.ToListAsync();
        }






        // GET: api/Docs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doc>> GetDoc(int id)
        {
            var doc = await _context.DocItems.FindAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return doc;
        }

        // PUT: api/Docs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoc(int id, Doc doc)
        {
            string command = "update dbo.Documents set dbo.Documents.Title = '" + doc.Title + "', dbo.Documents.Text = '" + doc.Content + "' where dbo.Documents.id = " + doc.Id;
            CommandDocDbDonau(command);
            if (id != doc.Id)
            {
                return BadRequest();
            }

            _context.Entry(doc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Docs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doc>> PostDoc(Doc doc)
        {
            string command = "insert into dbo.Documents (dbo.Documents.id, dbo.Documents.Title, dbo.Documents.Text) values(" + doc.Id + ", '" + doc.Title + "', '" + doc.Content + "');";

            CommandDocDbDonau(command);
            _context.DocItems.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoc", new { id = doc.Id, title = doc.Title, content = doc.Content }, doc);
        }

        // DELETE: api/Docs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoc(int id)
        {
            string command = "delete from dbo.Documents WHERE dbo.Documents.Id = " + id + ";";
            CommandDocDbDonau(command);
            var doc = await _context.DocItems.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }

            _context.DocItems.Remove(doc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocExists(int id)
        {
            return _context.DocItems.Any(e => e.Id == id);
        }

        private List<Doc> GetDocDbDonau()
        {
            string command = "select dbo.Documents.id, dbo.Documents.Title, dbo.Documents.Text from dbo.Documents";
            List<Doc> arr = new List<Doc>();
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
                                    arr.Add(new Doc { Id = reader.GetInt32(0), Title = reader.GetString(1), Content = reader.GetString(2) });
                                    //for (int i = 0; i < returnValues; i++)
                                    //{

                                    //    arr.Add(new Doc { }reader.GetString(i));
                                    //}
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

        //public async Task<ActionResult<IEnumerable<Doc>>> GetDocItems()
        //{

        //    return await _context.DocItems.ToListAsync();
        //}

        private void CommandDocDbDonau(string command)
        {

            Debug.WriteLine(command);
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
                            SqlDataReader reader = cmd.ExecuteReader();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

    }
}
