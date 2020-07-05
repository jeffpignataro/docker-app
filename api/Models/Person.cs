using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int? PersonAge { get; set; }
    }
}
