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

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);
        var fieldsInfo = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

        foreach (var fieldInfo in fieldsInfo)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        var gettersInfo = classType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(m => m.Name.StartsWith("get_"));

        foreach (var getter in gettersInfo)
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }

        var settersInfo = classType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public)
            .Where(m => m.Name.StartsWith("set_"));

        foreach (var setter in settersInfo)
        {
            sb.AppendLine($"{setter.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);
        var allPrivateMethods =
            classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in allPrivateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}
