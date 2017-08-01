using Problem_9.Traffic_Lights.Models.Enums;

namespace Problem_9.Traffic_Lights.Interfaces
{
    public interface ITrafficLight
    {
        Light Light { get; }

        void Cycle();
    }
}
