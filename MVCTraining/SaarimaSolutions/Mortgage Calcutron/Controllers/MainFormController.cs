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
        public ActionResult MainForm(double principal, double interest, double numYears)
        {
            ViewData["interest"] = interest;
            ViewData["principal"] = string.Format("{0:C}", principal);
            ViewData["years"] = numYears;
            MortgageCalc mort = new MortgageCalc(principal, interest, numYears);
            double monthlyPayments = mort.calculateMonthlyPayment();
            ViewData["monthlyPayments"] = string.Format("{0:C}", monthlyPayments);
            double totalInterest = mort.calculateTotalInterestPaid();
            ViewData["totalInterest"] = string.Format("{0:C}", totalInterest);
            double totalPayment = mort.calculateTotalPayment();
            ViewData["totalPayment"] = string.Format("{0:C}", totalPayment);



            return View("Result");
        }
    }
}
