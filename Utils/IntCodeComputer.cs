using System;
using System.Collections.Generic;

namespace Utils
{
    public class IntCodeComputer
    {
        private int[] _program;
        private int[] _memory;
        
        private Queue<int> _input;
        private readonly Stack<int> _output = new Stack<int>();

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

        public void SetInput(IEnumerable<int> data)
        {
            _input = new Queue<int>(data);
        }

        public IEnumerable<int> GetOutput()
        {
            return _output.ToArray();
        }

        public void Execute()
        {
            _output.Clear();
            
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
                    case 3:
                    {
                        var parameter = _memory[ip + 1];
                        _memory[parameter] = _input.Dequeue();
                        ip += 2;
                        break;
                    }
                    case 4:
                    {
                        var parameter = _memory[ip + 1];
                        _output.Push(_memory[parameter]);
                        ip += 2;
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