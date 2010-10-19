using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace POS.UniTests
{
    [TestClass]
    public class PricePresenterTests
    {
        private FakeBarcodeScanner m_FakeScanner;
        private Mock<IPriceDisplay> m_FakePriceDisplay;
        private Mock<IProductRepository> m_FakeRep;
        private Mock<ITaxCalculator> m_FakeCalculator;

        [TestInitialize]
        public void TestInit()
        {
            m_FakeScanner = new FakeBarcodeScanner();
            m_FakePriceDisplay = new Mock<IPriceDisplay>();
            m_FakeRep = new Mock<IProductRepository>();
            m_FakeCalculator = new Mock<ITaxCalculator>();

            PricePresenter pos = new PricePresenter(m_FakeScanner, m_FakePriceDisplay.Object, m_FakeRep.Object, m_FakeCalculator.Object);
        }

        [TestMethod]
        public void WhenScanned_ExistentProduct_CatalogPriceDisplayed()
        {
            m_FakeRep.Setup(r => r.GetPrice(It.IsAny<string>())).Returns(100);
            m_FakeCalculator.Setup(t => t.CalculateTax(It.IsAny<double>(), It.IsAny<bool>())).Returns<double, bool>((p, b) => p);

            m_FakeScanner.Scan("12345");

            m_FakePriceDisplay.Verify(p => p.ShowPrice(100), Times.Once());
        }

        [TestMethod]
        public void WhenScanned_NotExistentProduct_ProductNotFoundTextDisplayed()
        {
            m_FakeRep.Setup(r => r.GetPrice(It.IsAny<string>())).Throws(new ProductNotFoundException());
            m_FakeCalculator.Setup(t => t.CalculateTax(It.IsAny<double>(), It.IsAny<bool>())).Returns<double, bool>((p, b) => p);

            m_FakeScanner.Scan("123asd4");

            m_FakePriceDisplay.Verify(p => p.ShowProductNotFound("123asd4"), Times.Once());
        }

        [TestMethod]
        public void WhenScaned_EmptyStringBarcode_ScanErrorTextDisplayed()
        {
            m_FakeScanner.Scan(string.Empty);

            m_FakePriceDisplay.Verify(d => d.ShowScanError(), Times.Once());
        }

        [TestMethod]
        public void WhenScanned_TaxCalculatorCalled()
        {
            m_FakeScanner.Scan("12345");
            m_FakeCalculator.Verify(c => c.CalculateTax(It.IsAny<double>(), It.IsAny<bool>()), Times.Once());
        }

        [TestMethod]
        public void WhenProvincialScanned_CalculatorCalledWithProvincialTax()
        {
            const string productCode = "5678fe";

            m_FakeRep.Setup(r => r.IsProvincial(productCode)).Returns(true);

            m_FakeScanner.Scan(productCode);

            m_FakeCalculator.Verify(c => c.CalculateTax(It.IsAny<double>(), true), Times.Once());
        }

        private class FakeBarcodeScanner : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void Scan(string barcode)
            {
                if (BarcodeScanned != null)
                    BarcodeScanned(this, new BarcodeScannedEventArgs {Barcode = barcode});
            }
        }
    }
}