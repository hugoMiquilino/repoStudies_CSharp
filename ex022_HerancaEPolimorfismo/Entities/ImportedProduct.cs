using System.Globalization;

namespace ex022_HerancaEPolimorfismo.Entities
{
    internal class ImportedProduct : Product
    {
        public double CustomFee { get; set; }

        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customFee)
        : base(name, price)
        {
            CustomFee = customFee;
        }

        public override string PriceTag()
        {
            return Name
                + " $ "
                + TotalPrice().ToString("f2", CultureInfo.InvariantCulture)
                + " (Customs fee: $ "
                + CustomFee.ToString("f2", CultureInfo.InvariantCulture)
                + ")";
        }

        public double TotalPrice()
        {
            return Price + CustomFee;
        }

    }
}
