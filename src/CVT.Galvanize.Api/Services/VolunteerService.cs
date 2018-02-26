using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVT.Galvanize.Api.Models;
using CVT.Galvanize.Data;
using Microsoft.EntityFrameworkCore;

namespace CVT.Galvanize.Api.Services
{
    public interface IVolunteerService
    {
        Task<PagedResult<VolunteerModel>> SearchVolunteers();
        Task<VolunteerModel> GetById(int id);
    }

    public class VolunteerService : IVolunteerService
    {
        private readonly GalvanizeContext _dbContext;

        public VolunteerService(GalvanizeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResult<VolunteerModel>> SearchVolunteers()
        {
            var volunteers = _dbContext.Volunteers.AsQueryable();
            var result = new List<VolunteerModel>();
            await volunteers.ForEachAsync(v => result.Add(new VolunteerModel
            {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,
                AddressLine1 = v.AddressLine1,
                AddressLine2 = v.AddressLine2,
                City = v.City,
                State = v.State,
                Zip = v.Zip,
                HomePhone = v.HomePhone,
                CellPhone = v.CellPhone,
                BusinessPhone = v.CellPhone,
                Email1 = v.Email1,
                Email2 = v.Email2,
                Hippa = v.Hippa,
                BackgroundCheck = v.BackgroundCheck,
                MandatedReporter = v.MandatedReporter,
                CsOrientationdate = v.CsOrientationdate,
                CsInterest = v.CsInterest,
                DateInterviewed = v.DateInterviewed,
                Active = v.Active,
                PostOrientationFollowupDate = v.PostOrientationFollowupDate,
                ReferencesResponded = v.ReferencesResponded,
                ImportantNames = v.ImportantNames,
                IsVolunteerCoordinator = v.IsVolunteerCoordinator
            }));
            return new PagedResult<VolunteerModel>
            {
                ResultSet = result,
                ItemCount = result.Count,
                StartIndex = 0,
                TotalItemCount = result.Count,
                ItemsPerPage = result.Count
            };
        }

        public async Task<VolunteerModel> GetById(int id)
        {
            var v = await _dbContext.Volunteers.FindAsync(id);
            if (v == null)
            {
                throw new NotFoundException();
            }

            return new VolunteerModel
            {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,
                AddressLine1 = v.AddressLine1,
                AddressLine2 = v.AddressLine2,
                City = v.City,
                State = v.State,
                Zip = v.Zip,
                HomePhone = v.HomePhone,
                CellPhone = v.CellPhone,
                BusinessPhone = v.CellPhone,
                Email1 = v.Email1,
                Email2 = v.Email2,
                Hippa = v.Hippa,
                BackgroundCheck = v.BackgroundCheck,
                MandatedReporter = v.MandatedReporter,
                CsOrientationdate = v.CsOrientationdate,
                CsInterest = v.CsInterest,
                DateInterviewed = v.DateInterviewed,
                Active = v.Active,
                PostOrientationFollowupDate = v.PostOrientationFollowupDate,
                ReferencesResponded = v.ReferencesResponded,
                ImportantNames = v.ImportantNames,
                IsVolunteerCoordinator = v.IsVolunteerCoordinator
            };
        }
    }
}
