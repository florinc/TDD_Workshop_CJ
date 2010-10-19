using System;
using System.Windows.Forms;

namespace POS
{
    public partial class PriceDisplay : Form, IPriceDisplay
    {
        public PriceDisplay()
        {
            InitializeComponent();
        }

        public string DisplayText
        {
            get { return label1.Text; }
        }

        public void ShowPrice(double price)
        {
            label1.Text = price.ToString("C");
        }

        public void ShowProductNotFound(string productCode)
        {
            label1.Text = string.Format(@"Product with code: {0} was not found", productCode);
        }

        public void ShowScanError()
        {
            
        }
    }
}