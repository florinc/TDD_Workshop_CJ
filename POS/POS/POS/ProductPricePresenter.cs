using System;

namespace POS
{
    public class ProductPricePresenter
    {
        private readonly IPriceDisplay m_PriceDisplay;
        private readonly IBarcodeScanner m_Scanner;
        private readonly IPriceLookup m_PriceLookup;

        public ProductPricePresenter(IPriceDisplay priceDisplay, IBarcodeScanner scanner, IPriceLookup priceLookup)
        {
            m_PriceDisplay = priceDisplay;
            m_PriceLookup = priceLookup;
            m_Scanner = scanner;

            m_Scanner.BarcodeScanned += Scanner_BarcodeScanned;
        }

        private void Scanner_BarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            try
            {
                double price = m_PriceLookup.GetPrice(e.Barcode);
                m_PriceDisplay.DisplayPrice(price);
            }
            catch (Exception)
            {
                m_PriceDisplay.ShowError();
            }
        }
    }
}