using System.Reflection;
using System.Text;
using Problem_1.Harvesting_Fields.Models;

namespace Problem_1.Harvesting_Fields.Engine.Commands
{
    public class PublicCommand
    {
        public string Execute()
        {
            var sb = new StringBuilder();

            var typeInfo = typeof(HarvestingFields);
            var publicFields = typeInfo.GetFields(BindingFlags.Instance | BindingFlags.Public);

            foreach (var field in publicFields)
            {
                sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
