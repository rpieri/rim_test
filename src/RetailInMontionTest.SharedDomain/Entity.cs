namespace RetailInMontionTest.SharedDomain
{
    public abstract class Entity
    {
        protected readonly List<DomainEvent> EventsToAdd = new();
        public IReadOnlyCollection<DomainEvent> Events => EventsToAdd;

        public Guid Id { get; }
        public DateTime CreatedDateTime { get; }
        public bool Removed { get; private set; }
        public DateTime? RemovedDateTime { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTime.UtcNow;
            Removed = false;
        }

        public virtual void Remove()
        {
            Removed = true;
            RemovedDateTime = DateTime.UtcNow;
        }
    }
}
