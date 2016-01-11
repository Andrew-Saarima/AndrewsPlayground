using System;
using System.ComponentModel.DataAnnotations;

namespace Mortgage_Calcutron.Models
{
    public class MortgageCalc
    {
        [Required]
        [Range(0,Double.MaxValue, ErrorMessage ="Please enter a valid loan amount")]
        private double _principal { get; set; }
        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a valid interest rate")]
        private double _interest { get; set; }
        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a valid number of years")]
        private double _numYears { get; set; }
        private double _monthlyPayments { get; set; }

        public MortgageCalc(double principal, double interest, double numYears)
        {
            _principal = principal;
            _interest = interest;
            _numYears = numYears;
        }

        public double calculateMonthlyPayment()
        {
            double numPayments = _numYears * 12;
            double monthlyInterest = (_interest * .01) / 12;
            double dividend = Math.Pow((1 + monthlyInterest), numPayments);
            double divisor = (Math.Pow((1 + monthlyInterest), numPayments) - 1);
            _monthlyPayments = _principal * monthlyInterest * (dividend / divisor);
            return _monthlyPayments;
        }
        public double calculateTotalInterestPaid()
        {
            return (calculateMonthlyPayment() * 12 * _numYears) - _principal;
        }

        public double calculateTotalPayment()
        {
            return calculateTotalInterestPaid() + _principal;
        }
    }
}