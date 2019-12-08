using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class Combinatorics
    {
        public static IEnumerable<IEnumerable<int>> Permute(IEnumerable<int> collection)
        {
            if (collection.Count() == 1)
                return new[] {collection};
            
            var result = new List<IEnumerable<int>>();
            foreach (var head in collection)
            {
                var tailPermutations = Permute(collection.Where(e => e != head));
                foreach (var tailPermutation in tailPermutations)
                {
                    result.Add(new [] { head }.Concat(tailPermutation) ); 
                }
            }
            return result;
        }
    }
}