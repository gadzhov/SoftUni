using System.Text;

namespace System_Split.Models
{
    public class Dump
    {
        public Dump(Hardware hardware)
        {
            this.Hardware = hardware;
        }

        public Hardware Hardware { get; private set; }
    }
}
