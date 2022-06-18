using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core
{
    public partial class User
    {
        public User()
        {
            Meter = new HashSet<Meter>();
            Pay = new HashSet<Pay>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Pasword { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string SecondName { get; set; }
        public int? PersonalAccountNumber { get; set; }

        public virtual ICollection<Meter> Meter { get; set; }
        public virtual ICollection<Pay> Pay { get; set; }
    }
}
