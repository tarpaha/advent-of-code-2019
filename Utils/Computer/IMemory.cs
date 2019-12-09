namespace Utils.Computer
{
    public interface IMemory
    {
        void InitFrom(long[] data);
        void Set(long offset, long value);
        long Get(long offset);
        long[] GetPlain();
    }
}