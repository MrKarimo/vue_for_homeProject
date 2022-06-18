using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core
{
    public partial class Meter
    {
        public Meter()
        {
            Measurement = new HashSet<Measurement>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int TypeMeterId { get; set; }

        public virtual TypeMeter TypeMeter { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Measurement> Measurement { get; set; }
    }
}
