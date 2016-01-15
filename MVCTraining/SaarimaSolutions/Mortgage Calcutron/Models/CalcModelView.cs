using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mortgage_Calcutron.Models
{
    public class CalcModelView
    {

        public string Principal;
        public double Interest;
        public string MonthlyPayments;
        public string TotalInterestPaid;
        public string TotalPayment;
        public double NumYears;

        public CalcModelView()
        {

        }
        public CalcModelView(MortgageCalc mort)
        {
            Principal = string.Format("{0:C}", mort.Principal);
            Interest = mort.Interest;
            MonthlyPayments = string.Format("{0:C}", mort.MonthlyPayments);
            TotalInterestPaid = string.Format("{0:C}", mort.TotalInterestPaid);
            TotalPayment = string.Format("{0:C}", mort.TotalPayment);
            NumYears = mort.NumYears;
        }
    }
}