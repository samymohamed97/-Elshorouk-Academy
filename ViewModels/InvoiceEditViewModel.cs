using Invoice.Models;

namespace Invoice.ViewModels
{
    public class InvoiceEditViewModel
    {
        public InvoiceHeader InvoiceHeader { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
