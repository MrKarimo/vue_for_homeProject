﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Model.Entity.Core
{
    public partial class TypeMeter
    {
        public TypeMeter()
        {
            Meter = new HashSet<Meter>();
        }

        public int Id { get; set; }
        public int KindMeterId { get; set; }
        public string Title { get; set; }

        public virtual KindMeter KindMeter { get; set; }
        public virtual ICollection<Meter> Meter { get; set; }
    }
}
