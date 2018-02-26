using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public class Matches : EntityId
    {
        public Matches()
        {
            MatchesClientProviders = new HashSet<MatchesClientProviders>();
            MatchesVolunteerRoles = new HashSet<MatchesVolunteerRoles>();
        }

        public int VolunteerId { get; set; }
        public int ClientId { get; set; }
        public int VolunteerCoordinatorId { get; set; }
        public string Status { get; set; }

        public Interactions Volunteer { get; set; }
        public Volunteers VolunteerCoordinator { get; set; }
        public Volunteers VolunteerNavigation { get; set; }
        public ICollection<MatchesClientProviders> MatchesClientProviders { get; set; }
        public ICollection<MatchesVolunteerRoles> MatchesVolunteerRoles { get; set; }
    }
}
