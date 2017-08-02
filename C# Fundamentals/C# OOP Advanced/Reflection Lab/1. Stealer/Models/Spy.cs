using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(classToInvestigate);
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        var fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                                             .Where(f => fieldsToInvestigate.Contains(f.Name));
        var instanceOfClass = Activator.CreateInstance(classType, new object[] {});
        foreach (var fieldInfo in fieldsInfo)
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(instanceOfClass)}");
        }

        return sb.ToString().Trim();
    }
}
