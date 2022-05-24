using RandomFact.Core.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// All CRUD REST api Reqests is based upon this
/// https://zetcode.com/csharp/httpclient/   
/// </summary>

namespace RandomFact.Helpers
{
    //This file is going to have the most of the CRUD methods. 
    class Helper
    {
        // Get a single data for documents
        public async Task<Doc> GetDBDataAsync(int id)
        {
            Doc docItem = new Doc();
            try
            {
                string url = $"https://localhost:44340/api/Docs/" + id;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Status: " + response.StatusCode);
                        var content = await client.GetStringAsync(url);
                        docItem = Doc.FromSoloJson(content);
                        // Now doc have all data from JSON
                    }
                    else
                    {
                        Debug.WriteLine("Status Error Code : " + response.StatusCode);

                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return docItem;
        }
        // Get all data for documents
        public async Task<List<Doc>> GetAllDBDataAsync()
        {
            // Get all data for documents
            List<Doc> list = new List<Doc>();
            try
            {
                string url = $"https://localhost:44340/api/Docs";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Status: " + response.StatusCode);
                        var content = await client.GetStringAsync(url);

                        list = Doc.FromJson(content);
                        // What it should do with each doc
                        foreach (Doc doc in list)
                        {
                            Debug.Write(doc.Id);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Status Error Code : " + response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return list;
        }
        //Delete method
        public async void DeleteDBDataAsync(int id)
        {
            try
            {
                string url = $"https://localhost:44340/api/Docs/" + id;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Status: " + response.StatusCode);
                    }
                    else
                    {
                        Debug.WriteLine("Status Error Code : " + response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        // POST Method
        public async void PostDBDataAsync(string title, string content)
        {
            int id = GetRandomId();




            var doc = new Doc { Id = id, Title = title, Content = content };
            string docJson = doc.SoloToJson();
            try
            {
                string url = $"https://localhost:44340/api/Docs/";
                using (HttpClient client = new HttpClient())
                {
                    //To figure out what I should have in PostAsync
                    // https://stackoverflow.com/questions/6117101/posting-jsonobject-with-httpclient-from-web-api
                    var data = new StringContent(docJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, data).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Status: " + response.StatusCode);
                    }
                    else
                    {
                        Debug.WriteLine("Status Error Code : " + response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        //PUT = Update 
        public async void PutDBDataAsync(int id, string title, string content)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var doc = new Doc { Id = id, Title = title, Content = content };
                    string docJson = doc.SoloToJson();

                    string url = $"https://localhost:44340/api/Docs/" + id;

                    var data = new StringContent(docJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync(url, data).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Status: " + response.StatusCode);
                    }
                    else
                    {
                        Debug.WriteLine("Status Error Code : " + response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }


        //------------------------ For fact ----------------------------------

        /// <summary>
        /// Get All Facts
        /// </summary>
        /// <returns></returns>
        public async Task<List<Fact>> GetAllFactsDBAsync()
        {
            // Get all data for documents
            List<Fact> list = new List<Fact>();
            try
            {
                string url = $"https://localhost:44340/api/Facts";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Status: " + response.StatusCode);
                        var content = await client.GetStringAsync(url);

                        list = Fact.FromJson(content);
                        // What it should do with each doc
                        foreach (Fact fact in list)
                        {
                            Debug.Write(fact.Id);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Status Error Code : " + response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return list;
        }

        //Get a random number between 1 - 10000
        public int GetRandomId()
        {
            int Id = 0;
            Random random = new Random();
            Id = random.Next(1, 10000);
            return Id;
        }



    }
}
