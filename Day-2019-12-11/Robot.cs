using System;
using System.Linq;
using Utils;
using Utils.Computer;

namespace Day_2019_12_11
{
    public class Robot
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        
        private readonly IntCodeComputer _computer;

        private Direction _direction;
        private Vector2 _position;

        public Vector2 GetPosition() { return _position; }
        public Direction GetDirection() { return _direction;}

        public Robot(IntCodeComputer computer)
        {
            _computer = computer;
            Reset();
        }

        public void Reset()
        {
            _computer.Reset();
            _position = new Vector2(0, 0);
            _direction = Direction.Up;
        }
        
        public void Run(Floor floor)
        {
            while (_computer.CurrentState != IntCodeComputer.State.Halt)
            {
                MakeOneStep(floor);
            }
        }

        public void MakeOneStep(Floor floor)
        {
            var color = floor.GetColor(_position);
            var output = new BufferOutput();
            
            _computer.AddInput(color);
            _computer.SetOutput(output);
            _computer.Run();
            
            var outputData = output.Data.ToArray();
            floor.Paint(_position, outputData[0]);
            Rotate(outputData[1]);
            Move();
        }

        private void Rotate(long direction)
        {
            switch(_direction)
            {
                case Direction.Up:
                    _direction = direction == 0 ? Direction.Left : Direction.Right; 
                    break;
                case Direction.Down:
                    _direction = direction == 0 ? Direction.Right : Direction.Left;
                    break;
                case Direction.Left:
                    _direction = direction == 0 ? Direction.Down : Direction.Up;
                    break;
                case Direction.Right:
                    _direction = direction == 0 ? Direction.Up : Direction.Down;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Move()
        {
            switch(_direction)
            {
                case Direction.Up:
                    _position.y -= 1;
                    break;
                case Direction.Down:
                    _position.y += 1;
                    break;
                case Direction.Left:
                    _position.x -= 1;
                    break;
                case Direction.Right:
                    _position.x += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}