using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using RESTauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RESTauranterContext _context;
        public HomeController(RESTauranterContext context){
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("/addreview")]
        public IActionResult AddReview(Reviewer NewReview){
            if(ModelState.IsValid){
                if(NewReview.VisitDate > DateTime.Today){
                    TempData["futuredate"] = "Visit Date cannot be in the future!";
                    return View("Index");
                }
            _context.Add(NewReview);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
            }
            return View("Index");
        }
        [HttpGet]
        [Route("/reviews")]
        public IActionResult Reviews(){
            List<Reviewer> AllReviewers = _context.Reviewers.OrderBy(Reviewer =>Reviewer.VisitDate).ToList();
            AllReviewers.Reverse();
            ViewBag.Reviewers = AllReviewers;
            return View("Reviews");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
