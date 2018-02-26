using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public class VolunteerRoles : EntityId
    {
        public VolunteerRoles()
        {
            MatchesVolunteerRoles = new HashSet<MatchesVolunteerRoles>();
        }

        public string Name { get; set; }

        public ICollection<MatchesVolunteerRoles> MatchesVolunteerRoles { get; set; }
    }
}
