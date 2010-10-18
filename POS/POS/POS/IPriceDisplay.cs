namespace POS
{
    public interface IPriceDisplay
    {
        void DisplayPrice(double barcode);
        void ShowError();
    }
}