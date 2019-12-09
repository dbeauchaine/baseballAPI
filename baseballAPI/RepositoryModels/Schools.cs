using System;
using System.Collections.Generic;

namespace BaseballAPI.RepositoryModels
{
    public partial class Schools
    {
        public string SchoolId { get; set; }
        public string NameFull { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
