using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        RestService restService = new RestService();

        [HttpGet("{idBook}")]
        public async Task<ActionResult<List<Authors>>> GetbyIDBooks(int idBook)
        {
            List<Authors> authors = await restService.GetbyIDBooks(idBook);
            return authors;
        }
    }
}
