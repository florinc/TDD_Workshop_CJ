using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace POS.UnitTests
{
    [TestClass]
    public class ProductPricePresenterTests
    {
        private FakeScanner m_Scanner;
        private Mock<IPriceDisplay> m_DisplayMock;
        private Mock<IPriceLookup> m_FakePriceLookup;

        [TestInitialize]
        public void TestInit()
        {
            m_Scanner = new FakeScanner();
            m_DisplayMock = new Mock<IPriceDisplay>();

            m_FakePriceLookup = new Mock<IPriceLookup>();
        }

        [TestMethod]
        public void When1234Scanned_10dot40Displayed()
        {
            Test_WhenBarcodeScanned_CorrectPriceDisplayed("1234", 10.40);
        }

        [TestMethod]
        public void When5678Scanned_11dot50Displayed()
        {
            Test_WhenBarcodeScanned_CorrectPriceDisplayed("5678", 11.50);
        }

        [TestMethod]
        public void WhenInvalidBarcode_NothingDisplayed()
        {
            m_FakePriceLookup.Setup(p => p.GetPrice(It.IsAny<string>())).Throws(new Exception());

            ProductPricePresenter pos = new ProductPricePresenter(m_DisplayMock.Object, m_Scanner, m_FakePriceLookup.Object);

            m_Scanner.ScanBarcode("1234");
            m_DisplayMock.Verify(d => d.ShowError(), Times.Once());
        }

        private void Test_WhenBarcodeScanned_CorrectPriceDisplayed(string barcode, double price)
        {
            m_FakePriceLookup.Setup(p => p.GetPrice(It.IsAny<string>())).Returns(price);

            ProductPricePresenter pos = new ProductPricePresenter(m_DisplayMock.Object, m_Scanner, m_FakePriceLookup.Object);

            m_Scanner.ScanBarcode(barcode);
            m_DisplayMock.Verify(d => d.DisplayPrice(price), Times.Once());
        }

        private class FakeScanner : IBarcodeScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void ScanBarcode(string barcode)
            {

                if (BarcodeScanned != null)
                    BarcodeScanned(this, new BarcodeScannedEventArgs {Barcode = barcode});
            }
        }
    }
}