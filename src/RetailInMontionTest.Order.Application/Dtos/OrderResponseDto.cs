namespace RetailInMontionTest.Order.Application.Dtos
{
    public class OrderResponseDto
    {
        public Guid Id { get; }
        public string Message { get; }

        public OrderResponseDto(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
