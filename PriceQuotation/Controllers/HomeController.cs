using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Total = 0;
            ViewBag.TotalDiscount = 0;
            return View();              
        }

        [HttpPost]
        public IActionResult Index(Quotation model)
        {

            if (ModelState.IsValid)
            {
                ViewBag.TotalDiscount = model.CalculateTotalDiscount();
            }
            else
            {
                model.DiscountPercent = 0;
            }
         

            if (ModelState.IsValid)
            {
                ViewBag.Total = model.CalculateTotal();
            }
            else
            {
                model.Subtotal = 0;
            }

            ViewBag.Total = model.CalculateTotal();
            ViewBag.TotalDiscount = model.CalculateTotalDiscount();
            return View();
        }






    }
}
