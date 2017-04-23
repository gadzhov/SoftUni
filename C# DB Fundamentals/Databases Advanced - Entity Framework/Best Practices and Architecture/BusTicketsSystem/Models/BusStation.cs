using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class BusStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Town Town { get; set; }
    }
}
