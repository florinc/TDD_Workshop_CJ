using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WindowScanner scanner = new WindowScanner();
            IProductRepository rep = ConfigureRepository();

            var taxCalculator = new TaxCalculator();
            var priceDisplay = new PriceDisplay();
            
            var pricePresenter = new PricePresenter(scanner, priceDisplay, rep, taxCalculator);

            scanner.Show();  
            Application.Run(priceDisplay);
             
            

        }

        private static IProductRepository ConfigureRepository()
        {
            // read the actula files from a DB or file with available products
            DictionaryProductRepository rep = new DictionaryProductRepository
                                                  {
                                                      new Product {Code = "1", IsProvincial = false, Price = 1.2},
                                                      new Product {Code = "2", IsProvincial = true, Price = 0.4},
                                                      new Product {Code = "3", IsProvincial = false, Price = 3.2}
                                                  };

            return rep;
        }
    }
}
