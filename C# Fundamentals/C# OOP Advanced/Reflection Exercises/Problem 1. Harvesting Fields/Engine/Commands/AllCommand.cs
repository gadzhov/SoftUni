using System;
using System.Reflection;
using System.Text;
using Problem_1.Harvesting_Fields.Models;

namespace Problem_1.Harvesting_Fields.Engine.Commands
{
    public class AllCommand
    {
        public string Execute()
        {
            var sb = new StringBuilder();

            var typeInfo = typeof(HarvestingFields);
            var allFields = typeInfo.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            string fieldModifier = null;

            foreach (var field in allFields)
            {
                if (field.IsFamily)
                {
                    fieldModifier = "protected";
                }
                else if (field.IsPublic)
                {
                    fieldModifier = "public";
                }
                else if (field.IsPrivate)
                {
                    fieldModifier = "private";
                }

                sb.AppendLine($"{fieldModifier} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
