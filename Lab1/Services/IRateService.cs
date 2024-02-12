using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbrbAPI.Models;

namespace Lab1.Services
{
    public interface IRateService
    {
        public Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}
