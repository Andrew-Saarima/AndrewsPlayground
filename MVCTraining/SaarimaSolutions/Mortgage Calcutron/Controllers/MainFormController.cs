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
            double monthlyPayments = MortgageCalc.calculateMonthlyPayment(principal, interest, numYears);
            ViewData["monthlyPayments"] = string.Format("{0:C}", monthlyPayments);
            double totalInterest = MortgageCalc.calculateTotalInterestPaid(principal,interest, numYears);
            ViewData["totalInterest"] = string.Format("{0:C}", totalInterest);
            double totalPayment = MortgageCalc.calculateTotalPayment(principal, interest, numYears);
            ViewData["totalPayment"] = string.Format("{0:C}", totalPayment);
            return View("Result");
        }
    }
}
