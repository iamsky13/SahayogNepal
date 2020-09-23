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
    public class DonorService : IDonorService
    {
        private readonly IUnitOfWork _uow;

        public DonorService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> AddDonor(DonorViewModel donorViewModel)
        {
            try
            {
                var donorModel = new Donor
                {
                    BloodGroup = donorViewModel.blood,
                    Age = donorViewModel.age,
                    City = donorViewModel.city,
                    Gender = GetGender(donorViewModel.gender),
                    HasDischargeReport = donorViewModel.discharge,
                    MobileNumber = donorViewModel.mobile,
                    Name = donorViewModel.name,
                    RecoveredDate = GetParsedDate(donorViewModel.recoveredDate),
                    RegisteredDate=DateTime.Now
                };
                await _uow.AsyncRepository<Donor>().AddAsync(donorModel);
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

        private DateTime? GetParsedDate(string recoveredDate)
        {
            DateTime dateResult;
            if(DateTime.TryParse(recoveredDate, out dateResult)) return dateResult;
            return null;
        }
    }
}
