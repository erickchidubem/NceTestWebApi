using System;
using System.Collections.Generic;

namespace NceTestWebApi.Data
{
    public partial class User
    {
        public User()
        {
            Family = new HashSet<Family>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public ICollection<Family> Family { get; set; }
    }
}
