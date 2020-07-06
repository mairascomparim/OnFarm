using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnFarm.Helpers
{
    public static class FoundYearsAgo
    {
        public static int GetYearsAgo(this DateTime dateTime)
        {
            var currentDate = DateTime.Now;
            int yearsAgo = currentDate.Year - dateTime.Year;

            return yearsAgo;
        }
    }
}
