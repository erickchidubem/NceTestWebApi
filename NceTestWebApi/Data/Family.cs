using System;
using System.Collections.Generic;

namespace NceTestWebApi.Data
{
    public partial class Family
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Relationship { get; set; }
        public int? Age { get; set; }
        public bool? IsDeleted { get; set; }

        public User User { get; set; }
    }
}
