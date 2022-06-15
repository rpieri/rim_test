namespace RetailInMontionTest.Order.Application.Dtos
{
    public class OrderProductUpdateDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Removed { get; set; }
    }
}
