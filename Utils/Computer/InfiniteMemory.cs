using System.Collections.Generic;
using System.Linq;

namespace Utils.Computer
{
    public class InfiniteMemory : IMemory
    {
        private readonly Dictionary<long, long> _data = new Dictionary<long, long>();
        
        public void InitFrom(long[] data)
        {
            _data.Clear();
            for(var i = 0; i < data.Length; i++)
                _data.Add(i, data[i]);
        }

        public void Set(long offset, long value)
        {
            _data[offset] = value;
        }

        public long Get(long offset)
        {
            return _data[offset];
        }

        public long[] GetPlain()
        {
            return _data.Keys.OrderBy(k => k).Select(k => _data[k]).ToArray();
        }
    }
}