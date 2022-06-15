namespace RetailInMontionTest.Order.Application.Dtos
{
    public class OrderCreatedDto
    {
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Number2 { get; set; }
        public string Country { get; set; }

        public IList<OrderProductCreatedDto> Products { get; set; }

        public OrderCreatedDto()
        {
            Products = new List<OrderProductCreatedDto>();
        }
    }
}
