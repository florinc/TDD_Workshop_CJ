using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class PriceDisplay : Form, IPriceDisplay
    {
        public PriceDisplay()
        {
            InitializeComponent();
        }

        public void ShowPrice(double price)
        {
            label1.Text = price.ToString();
        }

        public void ShowError()
        {
            label1.Text = "Error";
        }
    }
}
