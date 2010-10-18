using System;

namespace POS
{
    public interface IScanner
    {
        event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }

    class Scanner : IScanner
    {
        public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }

    public class BarcodeScannedEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }
}