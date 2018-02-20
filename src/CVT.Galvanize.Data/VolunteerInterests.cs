namespace CVT.Galvanize.Data
{
    public class VolunteerInterests: EntityId
    {
        public int VolunteerId { get; set; }
        public int? VolunteeringCategoryId { get; set; }

        public Volunteers Volunteer { get; set; }
        public VolunteringCategories VolunteeringCategory { get; set; }
    }
}
