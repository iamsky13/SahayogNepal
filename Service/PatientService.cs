using SahayogNepal.Interface;
using SahayogNepal.Models;
using SahayogNepal.Models.Enums;
using SahayogNepal.Models.ViewModels;
using SahayogNepal.RepositoryAndSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.Service
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _uow;

        public PatientService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> AddPatient(PatientViewModel patientViewModel)
        {
            try
            {
                var patientModel = new Patient
                {
                    BloodGroup = patientViewModel.blood,
                    Age = patientViewModel.age,
                    City = patientViewModel.city,
                    Gender = GetGender(patientViewModel.gender),
                    HasCaseSheet = patientViewModel.hasCaseSheet,
                    MobileNumber = patientViewModel.mobile,
                    Name = patientViewModel.name,
                    Hospital= patientViewModel.hospital,
                    RegisteredDate=DateTime.Now
                };
                await _uow.AsyncRepository<Patient>().AddAsync(patientModel);
                return await _uow.CommitAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        private Gender GetGender(string gender)
        {
            Gender genderres;
            Enum.TryParse(gender, out genderres);
            return genderres;
        }
    }
}
