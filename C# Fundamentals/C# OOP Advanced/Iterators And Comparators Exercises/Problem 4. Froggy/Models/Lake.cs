using System.Collections;
using System.Collections.Generic;

namespace Problem_4.Froggy.Models
{
    public class Lake : IEnumerable<int>
    {
        public Lake(params int[] stones)
        {
            this.Stones = new List<int>(stones);
        }

        private IList<int> Stones { get; }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < this.Stones.Count; i += 2)
            {
                yield return this.Stones[i];
            }
            var lastIndex = 0;
            if (this.Stones.Count % 2 == 0)
            {
                lastIndex = this.Stones.Count - 1;
            }
            else
            {
                lastIndex = this.Stones.Count - 2;
            }
            for (var i = lastIndex; i >= 0; i -= 2)
            {
                yield return this.Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
