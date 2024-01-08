﻿using System;
using System.Collections.Generic;

namespace Invoice.Models
{
    public partial class InvoiceHeader
    {
        public InvoiceHeader()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public long Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime Invoicedate { get; set; }
        public int? CashierId { get; set; }
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual Cashier? Cashier { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
