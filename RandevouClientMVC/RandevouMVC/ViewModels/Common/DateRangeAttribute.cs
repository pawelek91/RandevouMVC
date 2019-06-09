using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Common
{
    public class AllowedDateRangeAttribute : RangeAttribute
    {
        public AllowedDateRangeAttribute()
          : base(typeof(DateTime) ,DateTime.Now.AddYears(-100).ToShortDateString(), DateTime.Now.AddMonths(-8).ToShortDateString()) { }
    }
}
