﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Computer
{
    public class IntCodeComputer : IDataReceiver
    {
        private long[] _program;
        private readonly IMemory _memory = new InfiniteMemory();

        private long _ip;
        private long _baseOffset;
        
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
            Array.Copy(data, _program, data.Length);
            Reset();
        }

        public void Reset()
        {
            _memory.InitFrom(_program);
            _ip = 0;
            _baseOffset = 0;
            _input = new Queue<long>();
            CurrentState = State.Ready;
        }

        public void SetMemory(long offset, long value)
        {
            _memory.Set(offset, value);
        }

        public long GetMemory(long offset)
        {
            return _memory.Get(offset);
        }

        public long[] GetMemory()
        {
            return _memory.GetPlain();
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

        private long GetValue(long mode, long offset)
        {
            switch (mode)
            {
                case 0:
                    return _memory.Get(_memory.Get(offset));
                case 1:
                    return _memory.Get(offset);
                case 2:
                    return _memory.Get(_baseOffset + _memory.Get(offset));
                default:
                    throw new Exception();
            }
        }

        private void SetValue(long mode, long offset, long value)
        {
            switch (mode)
            {
                case 0:
                    _memory.Set(_memory.Get(offset), value);
                    break;
                case 1:
                    _memory.Set(offset, value);
                    break;
                case 2:
                    _memory.Set(_baseOffset + _memory.Get(offset), value);
                    break;
                default:
                    throw new Exception();
            }
        }
        
        public void Run()
        {
            checked
            {
                CurrentState = State.Running;
                while (true)
                {
                    var instruction = _memory.Get(_ip);
                    var opCode = instruction % 100;
                    instruction /= 100;
                    
                    var mode1 = instruction % 10;
                    instruction /= 10;
                    
                    var mode2 = instruction % 10;
                    instruction /= 10;
                    
                    var mode3 = instruction % 10;

                    switch (opCode)
                    {
                        case 1:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            var value2 = GetValue(mode2, _ip + 2);
                            SetValue(mode3, _ip + 3, value1 + value2);
                            _ip += 4;
                            break;
                        }
                        case 2:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            var value2 = GetValue(mode2, _ip + 2);
                            SetValue(mode3, _ip + 3, value1 * value2);
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
                            SetValue(mode1, _ip + 1, _input.Dequeue());
                            _ip += 2;
                            break;
                        }
                        case 4:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            _output.AddInput(value1);
                            _ip += 2;
                            break;
                        }
                        case 5:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            var value2 = GetValue(mode2, _ip + 2);
                            if (value1 != 0)
                                _ip = value2;
                            else
                                _ip += 3;
                            break;
                        }
                        case 6:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            var value2 = GetValue(mode2, _ip + 2);
                            if (value1 == 0)
                                _ip = value2;
                            else
                                _ip += 3;
                            break;
                        }
                        case 7:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            var value2 = GetValue(mode2, _ip + 2);
                            SetValue(mode3, _ip + 3, value1 < value2 ? 1 : 0);
                            _ip += 4;
                            break;
                        }
                        case 8:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            var value2 = GetValue(mode2, _ip + 2);
                            SetValue(mode3, _ip + 3, value1 == value2 ? 1 : 0);
                            _ip += 4;
                            break;
                        }
                        case 9:
                        {
                            var value1 = GetValue(mode1, _ip + 1);
                            _baseOffset += value1;
                            _ip += 2;
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
        }

        public override string ToString()
        {
            return $"[{CurrentState}]";
        }
    }
}