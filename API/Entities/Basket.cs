namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Product product, int quantity)
        {
            if (Items.All(item => item.ProductId != product.Id))
            {
                Items.Add(new BasketItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            BasketItem item = Items.FirstOrDefault(item => item.ProductId == product.Id);
            if (item != null)
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId, int quantity)
        {
            BasketItem item = Items.FirstOrDefault(item => item.ProductId == productId);
            if (item == null)
            {
                return;
            }

            item.Quantity -= quantity;
            if (item.Quantity <= 0)
            {
                _ = Items.Remove(item);
            }
        }
    }
}
