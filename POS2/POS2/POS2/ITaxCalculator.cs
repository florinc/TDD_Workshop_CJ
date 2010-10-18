using System;

namespace POS
{
    public interface ITaxCalculator
    {
        double GetFederalTax(double price);
    }

    class TaxCalculator : ITaxCalculator
    {
        public double GetFederalTax(double price)
        {
            throw new NotImplementedException();
        }
    }
}