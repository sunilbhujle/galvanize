namespace CVT.Galvanize.Data
{
    public class MatchesClientProviders : EntityId
    {
        public int MatchesId { get; set; }
        public int ClientProviderId { get; set; }

        public ClientProvider ClientProvider { get; set; }
        public Matches Matches { get; set; }
    }
}
