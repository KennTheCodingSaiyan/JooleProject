using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_MVC_Team1.Models
{
    public class SearchViewModel
    {
        public List<SpecFilter> filters { get; set; }

        SearchViewModel(List<SpecFilter> filters)
        {
            this.filters = filters;
        }

    }
}