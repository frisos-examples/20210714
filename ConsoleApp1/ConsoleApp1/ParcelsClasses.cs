using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }

    public class Sender
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string CcNumber { get; set; }
        public string Type { get; set; }
    }

    public class Receipient
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Parcel
    {
        public Sender Sender { get; set; }
        public Receipient Receipient { get; set; }
        public string Weight { get; set; }
        public string Value { get; set; }
    }

    public class Parcels
    {
        public List<Parcel> Parcel { get; set; }
    }

    public class Container
    {
        public string Id { get; set; }
        public DateTime ShippingDate { get; set; }
        public Parcels parcels { get; set; }
    }
}
