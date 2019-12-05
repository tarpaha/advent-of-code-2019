using System;

namespace Utils
{
    public class IntCodeComputer
    {
        private int[] _program;
        private int[] _memory;

        public void LoadProgram(int[] data)
        {
            _program = new int[data.Length];
            _memory = new int[data.Length];
            
            Array.Copy(data, _program, data.Length);
            RestoreMemory();
        }

        public void RestoreMemory()
        {
            Array.Copy(_program, _memory, _program.Length);
        }

        public void SetMemory(int offset, int value)
        {
            _memory[offset] = value;
        }

        public int GetMemory(int offset)
        {
            return _memory[offset];
        }

        public int[] GetMemory()
        {
            return _memory;
        }

        public void Execute()
        {
            var ip = 0;
            while (true)
            {
                switch (_memory[ip])
                {
                    case 1:
                    {
                        var parameter1 = _memory[ip + 1];
                        var parameter2 = _memory[ip + 2];
                        var parameter3 = _memory[ip + 3];
                        _memory[parameter3] = _memory[parameter1] + _memory[parameter2];
                        ip += 4;
                        break;
                    }
                    case 2:
                    {
                        var parameter1 = _memory[ip + 1];
                        var parameter2 = _memory[ip + 2];
                        var parameter3 = _memory[ip + 3];
                        _memory[parameter3] = _memory[parameter1] * _memory[parameter2];
                        ip += 4;
                        break;
                    }
                    case 99:
                        return;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
}