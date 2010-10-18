using System;

namespace POS
{
    public class PricePresenter
    {
        private readonly IScanner m_Scanner;
        private readonly IPriceDisplay m_PriceDisplay;
        private readonly IProductRepository m_ProductRepository;
        private readonly ITaxCalculator m_TaxCalculator;
        private const double provincialTaxPercent = 8;

        public PricePresenter(IScanner scanner, IPriceDisplay priceDisplay, IProductRepository productRepository, ITaxCalculator taxCalculator)
        {
            m_Scanner = scanner;
            m_ProductRepository = productRepository;
            m_TaxCalculator = taxCalculator;
            m_PriceDisplay = priceDisplay;

            m_Scanner.BarcodeScanned += Scanner_BarcodeScanned;
        }

        private void Scanner_BarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            try
            {
                string scannedBarcode = e.Barcode;
                double price = m_ProductRepository.GetPrice(scannedBarcode);
                
                double priceWithFederalTax = m_TaxCalculator.GetFederalTax(price);

                m_PriceDisplay.ShowPrice(priceWithFederalTax);
            }
            catch (Exception)
            {
                m_PriceDisplay.ShowError();
            }
        }

        private static double GetProvincialTax(double price)
        {
            return price*provincialTaxPercent/100;
        }


        //private static double GetFederalTax(double price)
        //{
        //    return price*federalTaxPercent/100;
        //}
    }
}