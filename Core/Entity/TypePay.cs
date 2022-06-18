using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core
{
    public partial class TypePay
    {
        public TypePay()
        {
            CalcMeter = new HashSet<CalcMeter>();
            Price = new HashSet<Price>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CalcMeter> CalcMeter { get; set; }
        public virtual ICollection<Price> Price { get; set; }
    }
}
