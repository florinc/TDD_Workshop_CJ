using System;

namespace POS
{
    public class BarcodeScannedEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }
}