using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Models.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Shopping.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShoppingContext _context;


        public AdminController(ShoppingContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            TempData.Keep();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TbAdminstrator admin)
        {

            if (ModelState.IsValid)
            {
                using (ShoppingContext _context = new ShoppingContext())
                {
                    var obj = _context.TbAdminstrator.Where(a => a.AdminName.Equals(admin.AdminName) && a.AdminPw.Equals(admin.AdminPw)).FirstOrDefault();
                    if (obj != null)
                    {
                        TempData["UserName"] = obj.AdminName.ToString();
                        TempData.Keep();
                        return RedirectToAction("Index", "TbProducts");
                    }
                }
            }

            ViewBag.msg = "Invalid Username Or Password";

            return View(admin);
        }

        public ActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }





    }
}
