namespace INVMS.ProductManagement;
internal class Product
{
    public string Name { set; get; } = string.Empty;
    private double price;
    public int Quantity {  set; get; }

    public double Price
    {
        get {  return price; }
        set { price = value > 0? value: 0; }
    }

    public Product(string name, int quantitiy, double price)
    {
        Name = name;
        Quantity = quantitiy;
        Price = price;
    }

    public override string ToString()
    {
        return $"| {Name.PadRight(20)} | {Price.ToString("0.00").PadRight(8)} | {Quantity.ToString().PadRight(8)} |";
    }
}
