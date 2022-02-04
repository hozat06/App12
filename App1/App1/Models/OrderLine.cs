namespace App1.Models
{
    public class OrderLine
    {
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"{Product.Name}\nQuantity: {Quantity}, Total: {Total.ToString("N2")}";
        }
    }
}
