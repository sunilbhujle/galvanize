namespace CVT.Galvanize.Data
{
    public class MatchesVolunteerRoles:EntityId
    {
        public int MatchesId { get; set; }
        public int? VolunteerRoleId { get; set; }

        public Matches Matches { get; set; }
        public VolunteerRoles VolunteerRole { get; set; }
    }
}
