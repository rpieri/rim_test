namespace RetailInMontionTest.Order.Domain
{
    public interface IOrderRepository
    {
        Task Create(Orders order);
        Task Update(Orders order);
        Task<Orders?> GetById(Guid id);
    }
}
