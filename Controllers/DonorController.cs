using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahayogNepal.Models;

namespace SahayogNepal.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public bool SubmitData(DonorViewModel donorData)
        {
            return true;
        }
    }
}