using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Models.db;

namespace Shopping.Controllers
{
    public class TbCustomersController : Controller
    {
        private readonly ShoppingContext _context;

        public TbCustomersController(ShoppingContext context)
        {
            _context = context;
        }

        // GET: TbCustomers
        public async Task<IActionResult> Index()
        {
            TempData.Keep();
            var nav = 2;
            ViewBag.nav = nav;
            if (TempData["UserName"] != null)
            {
                TempData.Keep();
                return View(await _context.TbCustomer.ToListAsync());
            }
            else
            {
                TempData.Keep();
                return RedirectToAction("Index", "Admin");
            }


        }

        public ActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Admin");
        }

        // GET: TbCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            TempData.Keep();
            var nav = 2;
            ViewBag.nav = nav;

            if (id == null)
            {
                TempData.Keep();
                return NotFound();
            }

            var tbCustomer = await _context.TbCustomer
                .FirstOrDefaultAsync(m => m.CusId == id);
            if (tbCustomer == null)
            {
                TempData.Keep();
                return NotFound();
            }
            TempData.Keep();
            return View(tbCustomer);
        }

        // POST: TbCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TempData.Keep();
            var nav = 2;
            ViewBag.nav = nav;


                var tbCustomer = await _context.TbCustomer.FindAsync(id);
                _context.TbCustomer.Remove(tbCustomer);
                await _context.SaveChangesAsync();
                TempData.Keep();
                return RedirectToAction(nameof(Index));



        }

        private bool TbCustomerExists(int id)
        {
            return _context.TbCustomer.Any(e => e.CusId == id);
        }


        public IActionResult Searchbox(string query)
        {
            {
                TempData.Keep();
                var nav = 2;
                ViewBag.nav = nav;
                if (string.IsNullOrEmpty(query))
                {
                    TempData.Keep();
                    return View("Index", _context.TbCustomer.ToList());

                }
                else
                {
                    TempData.Keep();
                    return View("Index", _context.TbCustomer.Where(p => p.CusName.Contains(query)).ToList());
                }
            }
        }
    }
}
