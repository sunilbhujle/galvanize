using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CVT.Galvanize.Api.Models;
using CVT.Galvanize.Data;

namespace CVT.Galvanize.Api.Services
{
    public class VolunteerService
    {
        private readonly IGalvanizeContext _dbContext;

        public VolunteerService(IGalvanizeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VolunteerModel>> SearchVolunteers()
        {
            throw new NotImplementedException();

        }

    }
}
