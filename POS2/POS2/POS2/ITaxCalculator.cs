using System;

namespace POS
{
    public interface ITaxCalculator
    {
        double CalculateTax(double price, bool federal);
    }

    class TaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double price, bool federal)
        {
            throw new NotImplementedException();
        }
    }
}