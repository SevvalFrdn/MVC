using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            IEnumerable<mvcPaymentModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Payments").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<mvcPaymentModel>>().Result;
            return View(calList);
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcPaymentModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Payments/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPaymentModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Add(mvcPaymentModel pay)
        {
            if (pay.PaymentId == 0)
            {//post add
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Payments", pay).Result;
                TempData["SuccessMessage"] = "Successful Add";

            }
            else
            {//put update
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Payments/" + pay.PaymentId, pay).Result; 
                TempData["SuccessMessage"] = "Successful Update";
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Calisans/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Successful Delete";
            return RedirectToAction("Index");
        }
    }
}