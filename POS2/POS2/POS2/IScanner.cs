using System;

namespace POS
{
    public interface IScanner
    {
        event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }

    public class BarcodeScannedEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }
}