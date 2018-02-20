using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public partial class CvtSites:EntityId
    {
        public CvtSites()
        {
            VolunteerCvtSites = new HashSet<VolunteerCvtSites>();
        }

        public string Name { get; set; }

        public ICollection<VolunteerCvtSites> VolunteerCvtSites { get; set; }
    }
}
