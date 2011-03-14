// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.deepCopy
{

	[DataContract]
	[DebuggerDisplay("ImmutableAddress[Street={Street} City={City} ZipCode={ZipCode}]")]
	public abstract class BaseImmutableAddress : ICloneable
	{
		[DataMember(Name = "Street", Order = 0, IsRequired = false)]
		public readonly string Street;
		
		[DataMember(Name = "City", Order = 1, IsRequired = false)]
		public readonly string City;
		
		[DataMember(Name = "ZipCode", Order = 2, IsRequired = false)]
		public readonly string ZipCode;
		
		public BaseImmutableAddress(string street, string city, string zipCode)
		{
			Street = street;
			City = city;
			ZipCode = zipCode;
		}
		
		public BaseImmutableAddress(BaseImmutableAddress other)
		{
			this.Street = other.Street;
			if (other.City == null)
				this.City = null;
			else
				this.City = string.Copy(other.City);
			this.ZipCode = other.ZipCode;
		}
		
		public virtual ImmutableAddress WithStreet(string street)
		{
			return new ImmutableAddress(street, City, ZipCode);
		}
		
		public virtual ImmutableAddress WithCity(string city)
		{
			return new ImmutableAddress(Street, city, ZipCode);
		}
		
		public virtual ImmutableAddress WithZipCode(string zipCode)
		{
			return new ImmutableAddress(Street, City, zipCode);
		}
		
#pragma warning disable 109
		public new ImmutableAddress Clone()
#pragma warning restore 109
		{
			return (ImmutableAddress) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new ImmutableAddress((ImmutableAddress) this);
		}
	}
	
}
