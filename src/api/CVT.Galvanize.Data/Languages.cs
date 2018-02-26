using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public class Languages : EntityId
    {
        public Languages()
        {
            VolunteerLanguages = new HashSet<VolunteerLanguages>();
        }

        public string Name { get; set; }

        public ICollection<VolunteerLanguages> VolunteerLanguages { get; set; }
    }
}
