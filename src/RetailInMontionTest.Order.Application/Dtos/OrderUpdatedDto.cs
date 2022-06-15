namespace RetailInMontionTest.Order.Application.Dtos
{
    public class OrderUpdatedDto
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Number2 { get; set; }
        public string Country { get; set; }

        public IList<OrderProductUpdateDto> Products { get; set; }

        public OrderUpdatedDto()
        {
            Products = new List<OrderProductUpdateDto>();
        }
    }
}
