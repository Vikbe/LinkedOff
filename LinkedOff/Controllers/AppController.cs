using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkedOff.Data;
using LinkedOff.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedOff.Controllers
{
    public class AppController : Controller
    {
        private readonly ILinkedRepository _repo;

        public AppController(ILinkedRepository repo)
        {
            _repo = repo;
        }

       [Authorize]
        public IActionResult Timeline()
        {
            return View();
        }

        //public IActionResult Index(IndexViewModel model)
        //{
          
        //    return View();
        //}

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            return View();
        } 

        public IActionResult Profile()
        {
            var results = _repo.GetExperience();
            return View(results.ToList());
        }

    }
}