using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core
{
    public partial class CalcMeter
    {
        public int Id { get; set; }
        public int MeasurementId { get; set; }
        public double Sum { get; set; }
        public int TypePayId { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual TypePay TypePay { get; set; }
    }
}
