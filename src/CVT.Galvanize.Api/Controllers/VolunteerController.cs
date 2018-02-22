using System.Collections.Generic;
using System.Threading.Tasks;
using CVT.Galvanize.Api.Models;
using CVT.Galvanize.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CVT.Galvanize.Api.Controllers
{
    [Route("api")]
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        // GET: api/values
        [HttpGet]
        [Route("volunteers")]
        public async Task<IEnumerable<VolunteerModel>> Get()
        {
            return await _volunteerService.SearchVolunteers();
        }
    }
}