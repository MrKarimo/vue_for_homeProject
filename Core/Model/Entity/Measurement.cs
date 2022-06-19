using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Model.Entity.Core
{
    public partial class Measurement
    {
        public Measurement()
        {
            CalcMeter = new HashSet<CalcMeter>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MeterId { get; set; }
        public double Value1 { get; set; }
        public double? Value2 { get; set; }
        public double? Value3 { get; set; }

        public virtual Meter Meter { get; set; }
        public virtual ICollection<CalcMeter> CalcMeter { get; set; }
    }
}
