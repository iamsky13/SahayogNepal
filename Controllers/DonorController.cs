using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahayogNepal.Interface;
using SahayogNepal.Models;
using SahayogNepal.Models.ViewModels;

namespace SahayogNepal.Controllers
{
    public class DonorController : Controller
    {
        private readonly SahayogNepal.Interface.IDonorService donorService;

        public DonorController(IDonorService donorService)
        {
            this.donorService = donorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<bool> SubmitData(DonorViewModel donorData)
        {
            return await donorService.AddDonor(donorData);
        }
    }
}