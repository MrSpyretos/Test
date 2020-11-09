namespace CrmAzure.Model
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public decimal Price { get => Product.Price; set => Product.Price=value; }
    }
}