using System;

namespace POS
{
    public interface IPriceDisplay
    {
        void ShowPrice(double price);
        void ShowError();
    }
}