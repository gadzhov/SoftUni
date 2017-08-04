using System.Linq;
using System.Reflection;
using Problem_2.Black_Box_Integer.Models;

namespace Problem_2.Black_Box_Integer.Engine.Commands
{
    public class SubtractCommand
    {
        public string Execute(object instance, int value)
        {
            var typeInfo = typeof(BlackBoxInt);

            var subtractMethod = instance.GetType().GetMethod("Subtract", BindingFlags.Instance | BindingFlags.NonPublic);
            subtractMethod.Invoke(instance, new object[] { value });
            var result = typeInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault()
                .GetValue(instance).ToString();

            return result;
        }
    }
}
