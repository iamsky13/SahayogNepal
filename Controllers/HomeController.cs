using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SahayogNepal.Interface;
using SahayogNepal.Models;
using SahayogNepal.Models.ViewModels;

namespace SahayogNepal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientService patientService;

        private readonly IDonorService donorService;

        public HomeController(ILogger<HomeController> logger, IPatientService patientService, IDonorService donorService) 
        {
            this.patientService = patientService;
            this.donorService = donorService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                Donors = await donorService.TotalDonor(),
                Patients = await patientService.TotalPatient()
            };
            return View(model);
        }
        [HttpGet("plasma-therapy")]
        public IActionResult PlasmaTherapy()
        {
            return View();
        }
        [HttpGet("sahayogi-haat")]
        public IActionResult SahayogiHaath()
        {
            return View();
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
