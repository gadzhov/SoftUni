using System.Linq;
using System.Reflection;
using System.Text;
using Problem_1.Harvesting_Fields.Models;

namespace Problem_1.Harvesting_Fields.Engine.Commands
{
    public class PrivateCommand
    {
        public string Execute()
        {
            var sb = new StringBuilder();

            var typeInfo = typeof(HarvestingFields);
            var privateFields = typeInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.IsPrivate);

            foreach (var field in privateFields)
            {
                sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
