using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcSiteModel
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteLocation { get; set; }
        public string SiteManager { get; set; }
    }
}