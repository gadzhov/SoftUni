using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Problem_4.Telephony.Entities.Interfaces;

namespace Problem_4.Telephony.Entities
{
    public class Smartphone : ICall, IBrowse
    {
        public Smartphone(ICollection<string> contacts, ICollection<string> sites)
        {
            this.Contacts = contacts;
            this.Sites = sites;
        }

        public ICollection<string> Contacts { get; private set; }

        public ICollection<string> Sites { get; private set; }

        public string Browse(string url)
        {
            return url.Any(char.IsDigit) ? "Invalid URL!" : $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return !number.All(char.IsDigit) ? "Invalid number!" : $"Calling... {number}";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var num in this.Contacts)
            {
                sb.AppendLine(Call(num));
            }

            foreach (var url in this.Sites)
            {
                sb.AppendLine(Browse(url));
            }

            return sb.ToString();
        }
    }
}
