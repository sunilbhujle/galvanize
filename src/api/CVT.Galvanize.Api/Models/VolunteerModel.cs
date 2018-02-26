using System;

namespace CVT.Galvanize.Api.Models
{
    public class VolunteerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public bool? Hippa { get; set; }
        public bool? BackgroundCheck { get; set; }
        public bool? MandatedReporter { get; set; }
        public DateTime? CsOrientationdate { get; set; }
        public bool? CsInterest { get; set; }
        public DateTime? DateInterviewed { get; set; }
        public bool? Active { get; set; }
        public DateTime? PostOrientationFollowupDate { get; set; }
        public int? ReferencesResponded { get; set; }
        public string ImportantNames { get; set; }
        public bool IsVolunteerCoordinator { get; set; }
        public int Id { get; set; }
    }
}
