using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public class VolunteringCategories : EntityId
    {
        public VolunteringCategories()
        {
            VolunteerInterests = new HashSet<VolunteerInterests>();
        }

        public string Name { get; set; }

        public ICollection<VolunteerInterests> VolunteerInterests { get; set; }
    }
}
