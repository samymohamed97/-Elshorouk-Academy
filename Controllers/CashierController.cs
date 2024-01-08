using Invoice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace Invoice.Controllers
{
    public class CashierController : Controller
    {
        private readonly ShaTaskContext context;
        public CashierController(ShaTaskContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Cashiers.Include(s => s.Branch).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["branchlist"] = context.Branches.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cashier cashier)
        {    
                context.Cashiers.Add(cashier);
                context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cashier = context.Cashiers.Find(id);
            ViewData["BranchList"] = context.Branches.ToList();
            return View(cashier);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id , Cashier cashier)
        {
            Cashier oldcashier = context.Cashiers.Find(id);
            oldcashier.CashierName = cashier.CashierName;

            return RedirectToAction("Index");

            ViewData["BranchList"] = context.Branches.ToList();
            return View("Edit", cashier);
        }

        public IActionResult Delete(int id)
        {
            Cashier cashier = context.Cashiers.FirstOrDefault(s => s.Id == id);
            return View(cashier);
        }
        public IActionResult ConfirmDelete(int id)
        {
            Cashier oldCashier = context.Cashiers.FirstOrDefault(c => c.Id == id);
            context.Cashiers.Remove(oldCashier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
