using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<mvcCustomerModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers").Result; 
            calList = response.Content.ReadAsAsync<IEnumerable<mvcCustomerModel>>().Result;
            return View(calList);
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcCustomerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCustomerModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Add(mvcCustomerModel customer)
        {
            if (customer.CustomerId == 0)
            {//post add
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Customers", customer).Result;
                TempData["SuccessMessage"] = "Successful Add";

            }
            else
            {//put update
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customers/" + customer.CustomerId, customer).Result; 
                TempData["SuccessMessage"] = "Successful Update";
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Successful Delete";
            return RedirectToAction("Index");
        }
    }
}