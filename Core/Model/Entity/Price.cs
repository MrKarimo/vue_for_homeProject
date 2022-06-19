using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Model.Entity.Core
{
    public partial class Price
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public int TypePayId { get; set; }

        public virtual TypePay TypePay { get; set; }
    }
}
