using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mortgage_Calcutron.Models
{
    public class MortgageCalc
    {
        static private double monthlyPayments { get; set; }

        public static double calculateMonthlyPayment(double principal, double interest, double numYears)
        {
            double numPayments = numYears * 12;
            double monthlyInterest = (interest * .01) / 12;
            double dividend = Math.Pow((1 + monthlyInterest), numPayments);
            double divisor = (Math.Pow((1 + monthlyInterest), numPayments) - 1);
            monthlyPayments = principal * monthlyInterest * (dividend / divisor);
            return monthlyPayments;
        }
        public static double calculateTotalInterestPaid(double principal, double interest, double numYears)
        {
            return (calculateMonthlyPayment(principal, interest, numYears) * 12 * numYears) - principal;
        }

        public static double calculateTotalPayment(double principal, double interest, double numYears)
        {
            return calculateTotalInterestPaid(principal, interest, numYears) + principal;
        }
    }
}