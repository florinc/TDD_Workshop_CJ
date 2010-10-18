using System;

namespace POS
{
    class PriceDisplay : IPriceDisplay
    {
        public string Text
        {
            get; private set;
        }

        public void ShowPrice(double price)
        {
            Text = price.ToString();
        }

        public void ShowError()
        {
            
        }
    }
}