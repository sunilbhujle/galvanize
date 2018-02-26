using System;
using System.Collections.Generic;

namespace CVT.Galvanize.Data
{
    public class Interactions : EntityId
    {
        public Interactions()
        {
            Matches = new HashSet<Matches>();
        }

        public string NoteText { get; set; }
        public int MatchId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<Matches> Matches { get; set; }
    }
}
