using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DebtController : Controller
    {
        // GET: Debt
        public ActionResult Index()
        {
            IEnumerable<mvcDebtModel> calList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Debts").Result; 
            calList = response.Content.ReadAsAsync<IEnumerable<mvcDebtModel>>().Result;
            return View(calList);
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcDebtModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Debts/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDebtModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Add(mvcDebtModel debt)
        {
            if (debt.DebtId == 0)
            {//post add
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Debts", debt).Result;
                TempData["SuccessMessage"] = "Successful Add";

            }
            else
            {//put update
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Debts/" + debt.DebtId, debt).Result; 
                TempData["SuccessMessage"] = "Successful Update";
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Debts/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Successful Delete";
            return RedirectToAction("Index");
        }
    }
}