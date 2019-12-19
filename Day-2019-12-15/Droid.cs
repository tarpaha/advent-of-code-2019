using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using Utils.Computer;

namespace Day_2019_12_15
{
    public class Droid
    {
        private enum Direction
        {
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }
        
        private readonly Field _field;
        private readonly IntCodeComputer _computer;

        public Droid(Field field, long[] program)
        {
            _field = field;

            _computer = new IntCodeComputer();
            _computer.LoadProgram(program);
        }

        public void Explore(Action onStep)
        {
            var position = new Vector2(0, 0);
            var state = 1;
            
            _field.SetCellState(position, state);
            onStep();
            
            var borderCells = new List<Vector2>();
            borderCells.Add(position);

            while (borderCells.Count > 0)
            {
                var borderCell = borderCells.First();
                borderCells.RemoveAt(0);

                // TODO: temp
                if (borderCell.y != 0)
                    return;
                
                Move(position, borderCell);
                position = borderCell;

                var unknownDirections = GetDirectionsToUnknownCellsFrom(position);
                foreach (var direction in unknownDirections)
                {
                    (state, position) = TryToMove(position, direction);
                    switch (state)
                    {
                        case 0:
                            _field.SetCellState(GetNewPosition(position, direction), 0);
                            break;
                        case 1:
                        case 2:
                            _field.SetCellState(position, state);
                            borderCells.Add(position);
                            (_, position) = TryToMove(position, InverseDirection(direction));
                            break;
                    }
                
                    onStep();
                }
            }
        }

        private void Move(Vector2 p1, Vector2 p2)
        {
            // TODO: implement A*
            if(p2.x != 0)
                TryToMove(p1, Direction.Left);
        }

        private IEnumerable<Direction> GetDirectionsToUnknownCellsFrom(Vector2 pos)
        {
            return Enum.GetValues(typeof(Direction)).Cast<Direction>()
                .Where(direction => !_field.HaveCell(GetNewPosition(pos, direction)));
        }
        
        private (int, Vector2) TryToMove(Vector2 position, Direction direction)
        {
            var output = new BufferOutput();
            _computer.AddInput((int)direction);
            _computer.SetOutput(output);
            _computer.Run();

            var state = (int)output.Data.First();
            if (state != 0)
                position = GetNewPosition(position, direction);

            return (state, position);
        }

        private static Direction InverseDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                default:
                    throw new InvalidOperationException();
            }
        }
        
        private static Vector2 GetNewPosition(Vector2 p, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Vector2(p.x, p.y - 1);
                case Direction.Down:
                    return new Vector2(p.x, p.y + 1);
                case Direction.Left:
                    return new Vector2(p.x - 1, p.y);
                case Direction.Right:
                    return new Vector2(p.x + 1, p.y);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}