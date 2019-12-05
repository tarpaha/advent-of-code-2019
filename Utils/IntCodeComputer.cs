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
                var instruction = _memory[ip];
                var opCode = instruction % 100;

                var mode = instruction / 100;
                var imm1 = mode % 10 != 0; mode /= 10;
                var imm2 = mode % 10 != 0;
                
                switch (opCode)
                {
                    case 1:
                    {
                        var value1 = imm1 ? _memory[ip + 1] : _memory[_memory[ip + 1]];
                        var value2 = imm2 ? _memory[ip + 2] : _memory[_memory[ip + 2]];
                        _memory[_memory[ip + 3]] = value1 + value2;
                        ip += 4;
                        break;
                    }
                    case 2:
                    {
                        var value1 = imm1 ? _memory[ip + 1] : _memory[_memory[ip + 1]];
                        var value2 = imm2 ? _memory[ip + 2] : _memory[_memory[ip + 2]];
                        _memory[_memory[ip + 3]] = value1 * value2;
                        ip += 4;
                        break;
                    }
                    case 3:
                    {
                        _memory[_memory[ip + 1]] = _input.Dequeue();
                        ip += 2;
                        break;
                    }
                    case 4:
                    {
                        var value = imm1 ? _memory[ip + 1] : _memory[_memory[ip + 1]];
                        _output.Push(value);
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