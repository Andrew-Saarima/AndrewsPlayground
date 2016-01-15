using System;
using System.ComponentModel.DataAnnotations;

namespace Mortgage_Calcutron.Models
{
    public class MortgageCalc
    {

        [Required]
        [Range(0,Double.MaxValue, ErrorMessage ="Please enter a valid loan amount")]
        public double Principal { get; set; }
        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a valid interest rate")]
        public double Interest { get; set; }
        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a valid number of years")]
        public double NumYears { get; set; }
        public double NumPayments { get; set; }
        public double MonthlyInterest { get; set; }
        public double MonthlyPayments { get; set; }
        public double TotalInterestPaid { get; set; }
        public double TotalPayment { get; set; }

        public MortgageCalc()
        {

        }

        public MortgageCalc(double principal, double interest, double numYears)
        {
            Principal = principal;
            Interest = interest;
            NumYears = numYears;
            calculateNumPayments();
            calculateMonthlyInterest();
            calculateMonthlyPayment();
            calculateTotalInterestPaid();
            calculateTotalPayment();
        }

        public void calculateNumPayments()
        {
            NumPayments = NumYears * 12;
        }

        public void calculateMonthlyInterest()
        {
            MonthlyInterest = (Interest * .01) / 12;
        }

        public void calculateMonthlyPayment()
        {
            double dividend = Math.Pow((1 + MonthlyInterest), NumPayments);
            double divisor = (Math.Pow((1 + MonthlyInterest), NumPayments) - 1);
            MonthlyPayments = Principal * MonthlyInterest * (dividend / divisor);
        }
        public void calculateTotalInterestPaid()
        {
            TotalInterestPaid = (MonthlyPayments * 12 * NumYears) - Principal;
        }

        public void calculateTotalPayment()
        {
            TotalPayment = TotalInterestPaid + Principal;
        }
    }
}