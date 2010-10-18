using System;

namespace POS
{
    public interface IBarcodeScanner
    {
        event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }
}