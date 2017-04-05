using System.Collections.Generic;
using System.Xml.Serialization;

namespace Data.DTO
{
    [XmlType(TypeName = "user")]
    public class SellerDTO
    {
        public SellerDTO()
        {
            this.SoldProducts = new List<SoldProductsDTO>();
        }
        [XmlAttribute(AttributeName = "first-name")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        [XmlArrayItem("product")]
        public virtual List<SoldProductsDTO> SoldProducts { get; set; }
    }
}
