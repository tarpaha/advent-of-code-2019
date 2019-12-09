using System.Collections.Generic;

namespace Utils.Computer
{
    public class BufferOutput : IDataReceiver
    {
        public IEnumerable<long> Data => _data;
        private readonly List<long> _data = new List<long>();
        public void AddInput(long value)
        {
            _data.Add(value);
        }
    }
}