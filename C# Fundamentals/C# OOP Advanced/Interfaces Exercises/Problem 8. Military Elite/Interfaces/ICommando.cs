using System.Collections.Generic;
using Problem_8.Military_Elite.Models;

namespace Problem_8.Military_Elite.Interfaces
{
    public interface ICommando
    {
        ICollection<Mission> Missions { get; }
    }
}
