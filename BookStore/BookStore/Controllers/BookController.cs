using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        RestService restService = new RestService();
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAsync()
        {
            var BookResult = await restService.GetBooks();
            return BookResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetAsync(int id)
        {
            Book book = await restService.GetBook(id);
            return book;
        }

        [HttpPost]
        public async Task<string> PostAsync(Book value)
        {
            string strResult = await restService.InsertBook(value);
            return strResult;
        }

        [EnableCors("MyPolicy")]
        [HttpPut("{id}")]
        public string Put(int id, Book value)
        {
            string strResult = restService.PutBook(id, value);
            return strResult;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string strResult = restService.DeleteBook(id);
            return strResult;
        }
    }
}
