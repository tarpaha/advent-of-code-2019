using System;
using System.Linq;
using System.Collections.Generic;

namespace Utils
{
    public interface IDataReceiver
    {
        void AddInput(long value);
    }

    public class BufferOutput : IDataReceiver
    {
        public IEnumerable<long> Data => _data;
        private readonly List<long> _data = new List<long>();
        public void AddInput(long value)
        {
            _data.Add(value);
        }
    }
    
    public class IntCodeComputer : IDataReceiver
    {
        private long[] _program;
        private long[] _memory;

        private long _ip;
        
        private Queue<long> _input;
        private IDataReceiver _output;

        public enum State
        {
            Ready,
            Running,
            WaitingForInput,
            Halt
        }
        public State CurrentState { get; private set; }

        public void LoadProgram(long[] data)
        {
            _program = new long[data.Length];
            _memory = new long[data.Length];
            
            Array.Copy(data, _program, data.Length);
            Reset();
        }

        public void Reset()
        {
            Array.Copy(_program, _memory, _program.Length);
            _ip = 0;
            _input = new Queue<long>();
            CurrentState = State.Ready;
        }

        public void SetMemory(long offset, long value)
        {
            _memory[offset] = value;
        }

        public long GetMemory(long offset)
        {
            return _memory[offset];
        }

        public long[] GetMemory()
        {
            return _memory;
        }

        public void AddInput(long value)
        {
            _input.Enqueue(value);
        }

        public long GetInput()
        {
            return new List<long>(_input).First();
        }
        
        public void SetOutput(IDataReceiver output)
        {
            _output = output;
        }

        public void Run()
        {
            CurrentState = State.Running;
            while (true)
            {
                var instruction = _memory[_ip];
                var opCode = instruction % 100;

                var mode = instruction / 100;
                var imm1 = mode % 10 != 0; mode /= 10;
                var imm2 = mode % 10 != 0;
                
                switch (opCode)
                {
                    case 1:
                    {
                        var value1 = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        var value2 = imm2 ? _memory[_ip + 2] : _memory[_memory[_ip + 2]];
                        _memory[_memory[_ip + 3]] = value1 + value2;
                        _ip += 4;
                        break;
                    }
                    case 2:
                    {
                        var value1 = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        var value2 = imm2 ? _memory[_ip + 2] : _memory[_memory[_ip + 2]];
                        _memory[_memory[_ip + 3]] = value1 * value2;
                        _ip += 4;
                        break;
                    }
                    case 3:
                    {
                        if (_input.Count <= 0)
                        {
                            CurrentState = State.WaitingForInput;
                            return;
                        }
                        _memory[_memory[_ip + 1]] = _input.Dequeue();
                        _ip += 2;
                        break;
                    }
                    case 4:
                    {
                        var value = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        _output.AddInput(value);
                        _ip += 2;
                        break;
                    }
                    case 5:
                    {
                        var value1 = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        var value2 = imm2 ? _memory[_ip + 2] : _memory[_memory[_ip + 2]];
                        if (value1 != 0)
                            _ip = value2;
                        else
                            _ip += 3;
                        break;
                    }
                    case 6:
                    {
                        var value1 = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        var value2 = imm2 ? _memory[_ip + 2] : _memory[_memory[_ip + 2]];
                        if (value1 == 0)
                            _ip = value2;
                        else
                            _ip += 3;
                        break;
                    }
                    case 7:
                    {
                        var value1 = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        var value2 = imm2 ? _memory[_ip + 2] : _memory[_memory[_ip + 2]];
                        _memory[_memory[_ip + 3]] = value1 < value2 ? 1 : 0;
                        _ip += 4;
                        break;
                    }
                    case 8:
                    {
                        var value1 = imm1 ? _memory[_ip + 1] : _memory[_memory[_ip + 1]];
                        var value2 = imm2 ? _memory[_ip + 2] : _memory[_memory[_ip + 2]];
                        _memory[_memory[_ip + 3]] = value1 == value2 ? 1 : 0;
                        _ip += 4;
                        break;
                    }
                    case 99:
                        CurrentState = State.Halt;
                        return;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public override string ToString()
        {
            return $"[{CurrentState}]";
        }
    }
}