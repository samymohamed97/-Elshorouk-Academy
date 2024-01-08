﻿using System;
using System.Collections.Generic;

namespace Invoice.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Cashiers = new HashSet<Cashier>();
            InvoiceHeaders = new HashSet<InvoiceHeader>();
        }

        public int Id { get; set; }
        public string BranchName { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Cashier> Cashiers { get; set; }
        public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
