using System.Linq;
using System.Reflection;
using System.Text;
using Problem_1.Harvesting_Fields.Models;

namespace Problem_1.Harvesting_Fields.Engine.Commands
{
    public class ProtectedCommand
    {
        public string Execute()
        {
            var sb = new StringBuilder();

            var typeInfo = typeof(HarvestingFields);
            var protectedFields =
                typeInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.IsFamily);

            foreach (var field in protectedFields)
            {
                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
