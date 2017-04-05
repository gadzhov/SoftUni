using System.Xml.Serialization;

namespace Data.DTO
{
    [XmlType(TypeName = "product")]
    public class ProductInRangeDTO
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }
        [XmlAttribute(AttributeName = "seller")]
        public string Seller { get; set; }
    }
}
