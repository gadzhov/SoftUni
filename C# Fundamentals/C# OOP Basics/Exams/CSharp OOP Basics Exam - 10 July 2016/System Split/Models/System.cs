namespace System_Split.Models
{
    public abstract class System
    {
        protected System(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }
}
