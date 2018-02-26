namespace CVT.Galvanize.Data
{
    public class VolunteerLanguages : EntityId
    {
        public int VolunteerId { get; set; }
        public int LanguageId { get; set; }

        public Languages Language { get; set; }
        public Volunteers Volunteer { get; set; }
    }
}
