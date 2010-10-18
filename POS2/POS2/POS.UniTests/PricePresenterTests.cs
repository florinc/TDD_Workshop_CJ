using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace POS.UniTests
{
    [TestClass]
    public  class PricePresenterTests
    {
        private FakeBarcodeScanner m_Scanner;
        private Mock<IPriceDisplay> m_PriceDisplayMock;
        private Mock<IProductLookup> m_LookupMock;

        [TestInitialize]
        public void TestInit()
        {
            m_Scanner = new FakeBarcodeScanner();
            m_PriceDisplayMock = new Mock<IPriceDisplay>();
            m_LookupMock = new Mock<IProductLookup>();
        }

        [TestMethod]
        public void When12345Scanned_10dot40Displayed()
        {
            m_LookupMock.Setup(l => l.GetPrice(It.IsAny<string>())).Returns(10.40);

            PricePresenter target = new PricePresenter(m_Scanner, m_PriceDisplayMock.Object, m_LookupMock.Object);

            m_Scanner.Scan("12345");

            m_PriceDisplayMock.Verify(p=>p.ShowPrice(10.40), Times.Once());
        }

        [TestMethod]
        public void When5678Scanned_11dot56Displayed()
        {
            m_LookupMock.Setup(l => l.GetPrice(It.IsAny<string>())).Returns(11.56);

            PricePresenter target = new PricePresenter(m_Scanner, m_PriceDisplayMock.Object, m_LookupMock.Object);

            m_Scanner.Scan("5678");

            m_PriceDisplayMock.Verify(p => p.ShowPrice(11.56), Times.Once());
        }

        [TestMethod]
        public void WhenInvalidBarcode_ErrorShown()
        {
            m_LookupMock.Setup(l => l.GetPrice(It.IsAny<string>())).Throws(new Exception());

            PricePresenter target = new PricePresenter(m_Scanner, m_PriceDisplayMock.Object, m_LookupMock.Object);

            m_Scanner.Scan("1234");

            m_PriceDisplayMock.Verify(p=>p.ShowError(), Times.Once());
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