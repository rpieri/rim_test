using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain.ValueObjects
{
    public class DeliveryAddress : ValueObject
    {
        public string ZipCode { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Number { get; private set; }
        public string Number2 { get; private set; }
        public string Country { get; private set; }

        private DeliveryAddress()
        {

        }

        public DeliveryAddress(string zipCode, string address, string city, string number, string number2, string country)
        {
            ZipCode = zipCode;
            Address = address;
            City = city;
            Number = number;
            Number2 = number2;
            Country = country;
        }


        protected override IEnumerable<object> GetEqualComponenents()
        {
            return new[] { ZipCode, Address, City, Number, Number2, Country };  
        }

        internal void Update(DeliveryAddress deliveryAddress)
        {
            this.Address = deliveryAddress.Address;
            this.ZipCode = deliveryAddress.ZipCode;
            this.City = deliveryAddress.City;
            this.Number = deliveryAddress.Number;
            this.Number2 = deliveryAddress.Number2;
        }
    }
}
