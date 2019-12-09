using System;

namespace Utils.Computer
{
    public class PlainBufferMemory : IMemory
    {
        private long[] _data;
        
        public void InitFrom(long[] data)
        {
            _data = new long[data.Length];
            Array.Copy(data, _data, data.Length);
        }

        public void Set(long offset, long value)
        {
            _data.SetValue(value, offset);
        }

        public long Get(long offset)
        {
            return (long)_data.GetValue(offset);
        }

        public long[] GetPlain()
        {
            return _data;
        }
    }
}