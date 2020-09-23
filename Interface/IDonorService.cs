using SahayogNepal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.Interface
{
    public interface IDonorService
    {
        Task<bool> AddDonor(DonorViewModel donorViewModel);
    }
}
