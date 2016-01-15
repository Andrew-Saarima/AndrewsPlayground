using Mortgage_Calcutron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Mortgage_Calcutron.Controllers
{
    public class MainFormController : Controller
    {
        // GET: MainForm
        public ActionResult MainForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MainForm(MortgageCalc model)
        {
            if (ModelState.IsValid)
            {
                MortgageCalc mort = new MortgageCalc(model.Principal, model.Interest, model.NumYears);
                CalcModelView mortView = new CalcModelView(mort);
                return View("Result",mortView);
            }
            else
            {
                return View(model);
            }
        }
    }
}
