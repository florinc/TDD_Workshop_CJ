using System;

namespace POS
{
    public interface IScanner
    {
        event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }

    public class BarcodeScannedEventArgs : EventArgs
    {
        public BarcodeScannedEventArgs(string barcode)
        {
            Barcode = barcode;
        }

        public BarcodeScannedEventArgs()
        {
            Barcode = string.Empty;
        }

        public string Barcode { get; set; }
    }
}