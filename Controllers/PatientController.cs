using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahayogNepal.Interface;
using SahayogNepal.Models.ViewModels;

namespace SahayogNepal.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService PatientService)
        {
            this.patientService = PatientService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<bool> SubmitPatientData(PatientViewModel PatientData)
        {
            return await patientService.AddPatient(PatientData);
        }
    }
}