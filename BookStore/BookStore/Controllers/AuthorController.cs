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
    public class AuthorController : ControllerBase
    {
        RestService restService = new RestService();
 
        [HttpGet]
        public async Task<IEnumerable<Authors>> GetAsync()
        {
            var AuthorsResult = await restService.GetAuthors();
            return AuthorsResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAsync(int id)
        {
            Authors authors = await restService.GetAuthor(id);
            return authors;
        }

        [HttpPost]
        public async Task<string> Post(Authors value)
        {
            string strResult = await restService.InsertAuthor(value);
            return strResult;
        }

        [EnableCors("MyPolicy")]
        [HttpPut("{id}")]
        public string Put(int id, Authors value)
        {
            string strResult = restService.PutAuthor(id, value);
            return strResult;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string strResult = restService.DeleteAuthor(id);
            return strResult;
        }
    }
}
