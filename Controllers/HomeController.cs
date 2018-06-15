using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTmakefood.Models;
using Microsoft.EntityFrameworkCore;

namespace RESTmakefood.Controllers
{
    public class HomeController : Controller
    {
        private RESTmakefoodContext _context;
        public HomeController(RESTmakefoodContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Reviews")]
        public IActionResult Reviews(Reviews inp)
        {
            if(ModelState.IsValid)
            {
                inp.created_at = DateTime.Now;
                inp.updated_at = DateTime.Now;
                _context.Add(inp);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            List<Reviews> AllReviews = _context.entries.OrderByDescending(x => x.created_at).ToList();
            ViewBag.AllReviews = AllReviews;
            return View("Reviews");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
