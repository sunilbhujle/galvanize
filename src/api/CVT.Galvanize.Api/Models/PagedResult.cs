using System.Collections.Generic;

namespace CVT.Galvanize.Api.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> ResultSet { get; set; }

        public int StartIndex { get; set; }

        public int ItemsPerPage { get; set; }

        public int ItemCount { get; set; }

        public int TotalItemCount { get; set; }
    }
}