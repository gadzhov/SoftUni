using System.Xml.Serialization;

namespace Data.DTO
{
    public class SoldProductsDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
