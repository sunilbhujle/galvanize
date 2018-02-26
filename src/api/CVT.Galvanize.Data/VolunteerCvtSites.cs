namespace CVT.Galvanize.Data
{
    public class VolunteerCvtSites:EntityId
    {
        public int VolunteerId { get; set; }
        public int CvtSiteId { get; set; }

        public CvtSites CvtSite { get; set; }
        public Volunteers Volunteer { get; set; }
    }
}
