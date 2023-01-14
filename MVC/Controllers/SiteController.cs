using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            IEnumerable<mvcSiteModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Sites").Result; 
            calList = response.Content.ReadAsAsync<IEnumerable<mvcSiteModel>>().Result;
            return View(calList);
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcSiteModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Sites/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcSiteModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Add(mvcSiteModel site)
        {
            if (site.SiteId == 0)
            {//post add
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Sites", site).Result;
                TempData["SuccessMessage"] = "Successful Add";

            }
            else
            {//put update
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Sites/" + site.SiteId, site).Result; 
                TempData["SuccessMessage"] = "Successful Update";
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Sites/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Successful Delete";
            return RedirectToAction("Index");
        }
    }
}