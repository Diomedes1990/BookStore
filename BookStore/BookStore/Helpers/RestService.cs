using BookStore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class RestService
    {
        string urlBooks = "https://fakerestapi.azurewebsites.net/api/Books";
        string urlAuthors = "https://fakerestapi.azurewebsites.net/api/Authors";
        string urlBooksAuthors = "https://fakerestapi.azurewebsites.net/authors/";

        #region Book Requests
        public async Task<List<Book>> GetBooks()
        {
            var jsonRsult = await MakeCall(urlBooks);
            var myBooks = JsonConvert.DeserializeObject<List<Book>>(jsonRsult);
            return myBooks;
        }

        public async Task<Book> GetBook(int id)
        {
            string urlF = string.Format("{0}/{1}", urlBooks, id);
            var jsonRsult = await MakeCall(urlF);
            var myBook = JsonConvert.DeserializeObject<Book>(jsonRsult);
            return myBook;
        }

        public async Task<string> InsertBook(Book book)
        {
            return await PostBook(urlBooks, book);
        }

        public async Task<string> PostBook(string url, Book book)
        {
            Uri geturi = new Uri(url);
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(book);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage responseGet = await client.PostAsync(geturi, stringContent);
            string statusCode = responseGet.StatusCode.ToString();
            return statusCode;
        }

        public string PutBook(int id, Book book)
        {
            string urlF = string.Format("{0}/{1}", urlBooks, id);
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(urlF);
            var json = JsonConvert.SerializeObject(book);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/xml");
            var response = client.PutAsync(urlF, httpContent).Result;
            return response.StatusCode.ToString();
        }

        public string DeleteBook(int id)
        {
            string response = Delete(urlBooks, id);
            return response;
        }

        #endregion

        #region Autor Requests
        public async Task<List<Authors>> GetAuthors()
        {
            var jsonRsult = await MakeCall(urlAuthors);
            var authors = JsonConvert.DeserializeObject<List<Authors>>(jsonRsult);
            return authors;
        }

        public async Task<Authors> GetAuthor(int idAuthor)
        {
            string urlF = string.Format("{0}/{1}", urlAuthors, idAuthor);
            var jsonRsult = await MakeCall(urlF);
            var authors = JsonConvert.DeserializeObject<Authors>(jsonRsult);
            return authors;
        }

        public async Task<List<Authors>> GetbyIDBooks(int idAuthor)
        {
            string urlF = string.Format("{0}/books/{1}", urlBooksAuthors, idAuthor);
            var jsonRsult = await MakeCall(urlF);
            var authors = JsonConvert.DeserializeObject<List<Authors>>(jsonRsult);
            return authors;
        }

        public async Task<string> InsertAuthor(Authors authors)
        {
            return await PostAuthor(urlAuthors, authors);
        }

        public async Task<string> PostAuthor(string url, Authors authors)
        {
            Uri geturi = new Uri(url);
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(authors);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage responseGet = await client.PostAsync(geturi, stringContent);
            string statusCode = responseGet.StatusCode.ToString();
            return statusCode;
        }

        public string PutAuthor(int id, Authors authors)
        {
            string urlF = string.Format("{0}/{1}", urlAuthors, id);
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(urlF);
            var json = JsonConvert.SerializeObject(authors);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/xml");
            var response = client.PutAsync(urlF, httpContent).Result;
            return response.StatusCode.ToString();
        }

        public string DeleteAuthor(int id)
        {
            string response = Delete(urlAuthors, id);
            return response;
        }
        #endregion

        private static async Task<string> MakeCall(string url)
        {
            Uri geturi = new Uri(url); //replace your url  
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
            string response = await responseGet.Content.ReadAsStringAsync();
            return response;
        }

        public string Delete(string url, int id)
        {
            string urlF = string.Format("{0}/{1}", url, id);
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync(urlF).Result;
            return response.StatusCode.ToString();
        }
    }
}