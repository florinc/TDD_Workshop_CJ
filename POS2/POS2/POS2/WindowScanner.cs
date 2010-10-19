using System;
using System.Windows.Forms;

namespace POS
{
    public partial class WindowScanner : Form, IScanner
    {
        public WindowScanner()
        {
            InitializeComponent();

            button.Click += new EventHandler(button_Click);
        }

        void button_Click(object sender, EventArgs e)
        {
            if (BarcodeScanned != null)
                BarcodeScanned(this, new BarcodeScannedEventArgs(textBox.Text));
        }

        public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }
}