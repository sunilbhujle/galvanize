using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public class ClientProvider : EntityId
    {
        public ClientProvider()
        {
            MatchesClientProviders = new HashSet<MatchesClientProviders>();
        }

        public string Name { get; set; }

        public ICollection<MatchesClientProviders> MatchesClientProviders { get; set; }
    }
}
