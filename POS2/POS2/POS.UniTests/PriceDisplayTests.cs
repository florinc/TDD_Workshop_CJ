using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POS.UniTests
{
    [TestClass]
    public class PriceDisplayTests
    {
        [TestMethod]
        public void ShowPrice_WhenCalled_PriceDisplayed()
        {
            PriceDisplay display = new PriceDisplay();

            display.ShowPrice(20.5);

            Assert.AreEqual("$20.50", display.DisplayText);
        }

        [TestMethod]
        public void ShowProductNotFound_WhenCalled_ProductNotFoundTextDisplayed()
        {
            PriceDisplay display = new PriceDisplay();

            display.ShowProductNotFound("4567ff4");

            Assert.AreEqual("Product with code: 4567ff4 was not found", display.DisplayText);
        }

        [TestMethod]
        public void ShowScanError_WhenCalled_ErrorTextDisplayed()
        {
            PriceDisplay display = new PriceDisplay();

            display.ShowScanError();

            Assert.AreEqual("Scanner error!", display.DisplayText);
        }
    }
}