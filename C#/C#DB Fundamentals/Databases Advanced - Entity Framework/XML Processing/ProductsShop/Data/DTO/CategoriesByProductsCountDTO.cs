using System.Xml.Serialization;

namespace Data.DTO
{   
    [XmlType(TypeName = "category")]
    public class CategoriesByProductsCountDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("products-count")]
        public int Count { get; set; }
        [XmlElement("average-price")]
        public decimal? AveragePrice { get; set; }
        [XmlElement("total-revenue")]
        public decimal? TotalRevenue { get; set; }
    }
}
