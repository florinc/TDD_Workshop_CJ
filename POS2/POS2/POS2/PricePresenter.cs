using System;

namespace POS
{
    public class PricePresenter
    {
        private readonly IScanner m_Scanner;
        private readonly IPriceDisplay m_PriceDisplay;
        private readonly IProductLookup m_ProductLookup;
        private const double federalTaxPercent = 5;

        public PricePresenter(IScanner scanner, IPriceDisplay priceDisplay, IProductLookup productLookup)
        {
            m_Scanner = scanner;
            m_ProductLookup = productLookup;
            m_PriceDisplay = priceDisplay;

            m_Scanner.BarcodeScanned += Scanner_BarcodeScanned;
        }

        private void Scanner_BarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            try
            {
                string scannedBarcode = e.Barcode;
                double price = m_ProductLookup.GetPrice(scannedBarcode);

                price = AddFederalTax(price);

                m_PriceDisplay.ShowPrice(price);
            }
            catch (Exception)
            {
                m_PriceDisplay.ShowError();
            }
        }

        private static double AddFederalTax(double price)
        {
            double tax = price*federalTaxPercent/100;
            return price + tax;
        }
    }
}