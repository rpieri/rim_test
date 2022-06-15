namespace RetailInMontionTest.SharedDomain
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualComponenents();

        public bool Equals(ValueObject other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is not ValueObject) return false;

            return this == (obj as ValueObject);
        }

        public static bool operator ==(ValueObject objectA, ValueObject objectB)
        {
            if (ReferenceEquals(objectA, objectB)) return true;

            if (objectA is null || objectB is null) return false;

            return objectA.GetType() == objectB.GetType() &&
                objectA.GetEqualComponenents().SequenceEqual(objectB.GetEqualComponenents());
        }

        public static bool operator !=(ValueObject objectA, ValueObject objectB) => !(objectA == objectB);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach(var item in GetEqualComponenents())
                {
                    hash = HashCode.Combine(hash, item) * 31;
                }
                return hash;
            }
        }
    }
}
