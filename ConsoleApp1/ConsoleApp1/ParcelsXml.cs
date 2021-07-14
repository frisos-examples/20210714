using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleApp1
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Container));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Container)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "Address")]
	public class Address
	{

		[XmlElement(ElementName = "Street")]
		public string Street { get; set; }

		[XmlElement(ElementName = "HouseNumber")]
		public int HouseNumber { get; set; }

		[XmlElement(ElementName = "PostalCode")]
		public string PostalCode { get; set; }

		[XmlElement(ElementName = "City")]
		public string City { get; set; }
	}

	[XmlRoot(ElementName = "Sender")]
	public class Sender
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Address")]
		public Address Address { get; set; }

		[XmlElement(ElementName = "CcNumber")]
		public int CcNumber { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Receipient")]
	public class Receipient
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Address")]
		public Address Address { get; set; }
	}

	[XmlRoot(ElementName = "Parcel")]
	public class Parcel
	{

		[XmlElement(ElementName = "Sender")]
		public Sender Sender { get; set; }

		[XmlElement(ElementName = "Receipient")]
		public Receipient Receipient { get; set; }

		[XmlElement(ElementName = "Weight")]
		public double Weight { get; set; }

		[XmlElement(ElementName = "Value")]
		public double Value { get; set; }
	}

	[XmlRoot(ElementName = "parcels")]
	public class Parcels
	{

		[XmlElement(ElementName = "Parcel")]
		public List<Parcel> Parcel { get; set; }
	}

	[XmlRoot(ElementName = "Container")]
	public class Container
	{

		[XmlElement(ElementName = "Id")]
		public int Id { get; set; }

		[XmlElement(ElementName = "ShippingDate")]
		public DateTime ShippingDate { get; set; }

		[XmlElement(ElementName = "parcels")]
		public Parcels Parcels { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "xsd")]
		public string Xsd { get; set; }

		[XmlText]
		public string Text { get; set; }
	}


}
