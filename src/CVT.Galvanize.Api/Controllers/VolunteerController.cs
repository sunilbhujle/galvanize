using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CVT.Galvanize.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CVT.Galvanize.Api.Controllers
{
    [Route("api/[controller]")]
    public class VolunteerController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<VolunteerModel>> Get()
        {
            throw new NotImplementedException();
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
