using RandevouMVC.Models.ApiQueryProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models
{
    public abstract class BusinessManager
    {
        protected readonly IApiQueryProvider _queryProvider;
        public BusinessManager(IApiQueryProvider apiQueryProvider)
        {
            _queryProvider = apiQueryProvider;
        }
    }
}
