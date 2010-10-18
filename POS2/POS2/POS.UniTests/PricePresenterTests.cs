using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace POS.UniTests
{
    [TestClass]
    public class PricePresenterTests
    {
        private FakeBarcodeScanner m_Scanner;
        private Mock<IPriceDisplay> m_PriceDisplayMock;
        private Mock<IProductRepository> m_RepStub;
        private Mock<ITaxCalculator> m_TaxCalculatorStub;

        [TestInitialize]
        public void TestInit()
        {
            m_Scanner = new FakeBarcodeScanner();
            m_PriceDisplayMock = new Mock<IPriceDisplay>();
            m_RepStub = new Mock<IProductRepository>();
            m_TaxCalculatorStub = new Mock<ITaxCalculator>();
        }

        [TestMethod]
        public void WhenScanned_PriceDisplayed()
        {
            m_RepStub.Setup(r => r.GetPrice(It.IsAny<string>())).Returns(100);
            m_TaxCalculatorStub.Setup(t => t.CalculateTax(It.IsAny<double>(), It.IsAny<bool>())).Returns<double, bool>((p, b) => p);

            PricePresenter pos = CreateNewPricePresenter();

            m_Scanner.Scan("12345");

            m_PriceDisplayMock.Verify(p => p.ShowPrice(100), Times.Once());
        }

        [TestMethod]
        public void WhenInvalidBarcode_ErrorShown()
        {
            m_RepStub.Setup(r => r.GetPrice("123asd4")).Throws(new InvalidBarcodeException());
            m_TaxCalculatorStub.Setup(t => t.CalculateTax(It.IsAny<double>(), It.IsAny<bool>())).Returns<double, bool>((p, b) => p);

            PricePresenter pos = CreateNewPricePresenter();

            m_Scanner.Scan("123asd4");

            m_PriceDisplayMock.Verify(p => p.ShowError(), Times.Once());
        }

        [TestMethod]
        public void WhenScanned_PriceWithFederalTaxDisplayed()
        {
            m_RepStub.Setup(r => r.GetPrice("12345")).Returns(10.40);
            m_TaxCalculatorStub.Setup(t => t.CalculateTax(It.IsAny<double>(), It.IsAny<bool>())).Returns(10.92);

            PricePresenter pos = CreateNewPricePresenter();

            m_Scanner.Scan("12345");

            m_PriceDisplayMock.Verify(p => p.ShowPrice(10.92), Times.Once());
        }

        [TestMethod]
        public void WhenScanned_ProvincialAndFederalTaxDisplayed()
        {
            m_RepStub.Setup(r => r.GetPrice("5678fe")).Returns(100);
            m_RepStub.Setup(r => r.IsProvincial("5678fe")).Returns(true);
            m_TaxCalculatorStub.Setup(t => t.CalculateTax(It.IsAny<double>(), It.IsAny<bool>())).Returns(113);

            PricePresenter pos = CreateNewPricePresenter();

            m_Scanner.Scan("5678fe");

            m_PriceDisplayMock.Verify(p => p.ShowPrice(113), Times.Once());
        }

        private PricePresenter CreateNewPricePresenter()
        {
            return new PricePresenter(m_Scanner, m_PriceDisplayMock.Object, m_RepStub.Object, m_TaxCalculatorStub.Object);
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