using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.Telephony.Mms;

namespace Lab1.Services
{
    internal interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date);
    }
}
