using Invoice.Models;
using Invoice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ShaTaskContext context;
        public InvoiceController(ShaTaskContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.InvoiceDetails.Include(v => v.InvoiceHeader).ToList());
        }

        public IActionResult Edit(int id)
        {
          //  var InvoiceHeader = context.InvoiceHeaders.FirstOrDefault(i => i.Id == id);
            var InvoiceDetails = context.InvoiceDetails.FirstOrDefault( i => i.Id == id);

            return View(InvoiceDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id ,InvoiceDetail invoiceDetail)
        {
                InvoiceDetail oldinvoice = context.InvoiceDetails.FirstOrDefault( i => i.Id == id);
                oldinvoice .ItemName = invoiceDetail.ItemName;
                oldinvoice.ItemCount = invoiceDetail.ItemCount;
                context.InvoiceDetails.Update(invoiceDetail);
                context.SaveChanges();
                return RedirectToAction("Index");    
        }

        public IActionResult Delete(int id)
        {
            InvoiceDetail invoice = context.InvoiceDetails.FirstOrDefault(d => d.Id == id);
            return View(invoice);
        }
        public IActionResult ConfirmDelete(int id)
        {
            InvoiceDetail invoice = context.InvoiceDetails.FirstOrDefault(d => d.Id == id);
            context.InvoiceDetails.Remove(invoice);
            return RedirectToAction("Index");
        }
    }
}
