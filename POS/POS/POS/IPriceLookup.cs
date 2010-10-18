namespace POS
{
    public interface IPriceLookup
    {
        double GetPrice(string productCode);
    }
}