﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CVT.Galvanize.Api.Controllers
{
    [Route("api")]
    public class AboutController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("about")]
        public async Task<AboutModel> Get()
        {
            return await Task.Run(() => new AboutModel
            {
                Name = "CVT Galvanize",
                Version = "0.0.1"
            });
        }
    }

    public sealed class AboutModel
    {
        public string Version { get; set; }

        public string Name { get; set; }
    }
}
