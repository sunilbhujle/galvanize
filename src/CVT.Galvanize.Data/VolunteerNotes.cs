using System;

namespace CVT.Galvanize.Data
{
    public class VolunteerNotes : EntityId
    {
        public int VolunteerId { get; set; }
        public string NoteText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public Volunteers Volunteer { get; set; }
    }
}
