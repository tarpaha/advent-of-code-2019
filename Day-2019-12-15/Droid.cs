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

        public int Explore(Action onStep)
        {
            var position = new Vector2(0, 0);
            var state = 1;
            
            _field.SetCellState(position, state);
            
            var borderCells = new List<Vector2>();
            borderCells.Add(position);

            while (state != 2)
            {
                var borderCell = borderCells.OrderBy(p => p.SqrDist(position)).First();
                borderCells.Remove(borderCell);
                
                Move(position, borderCell);
                position = borderCell;
                
                onStep();

                var unknownDirections = GetDirectionsToCellsFrom(position, p => !_field.HaveCell(p));
                foreach (var direction in unknownDirections)
                {
                    (state, position) = TryToMove(position, direction);
                    switch (state)
                    {
                        case 0:
                            _field.SetCellState(GetNewPosition(position, direction), 0);
                            break;
                        case 1:
                            _field.SetCellState(position, 1);
                            borderCells.Add(position);
                            (_, position) = TryToMove(position, InverseDirection(direction));
                            break;
                        case 2:
                            _field.SetCellState(position, 2);
                            break;
                    }

                    onStep();

                    if (state == 2)
                        break;
                }
            }

            var map = new Dictionary<Vector2, int>();
            var p1 = new Vector2(0, 0);
            var p2 = position;
            PrepareMap(map, p1, p2);
            var steps = CalculateSteps(map, p1, p2);
            return steps.Count();
        }

        private void Move(Vector2 p1, Vector2 p2)
        {
            if (p1 == p2)
                return;
            
            var map = new Dictionary<Vector2, int>();

            PrepareMap(map, p1, p2);
            var steps = CalculateSteps(map, p1, p2);

            var pos = p1;
            foreach (var step in steps)
            {
                (_, pos) = TryToMove(pos, step);
            }
        }

        private void PrepareMap(IDictionary<Vector2, int> map, Vector2 p1, Vector2 p2)
        {
            var borderCells = new List<Vector2>();

            map[p1] = 0;
            borderCells.Add(p1);

            while (true)
            {
                var pos = borderCells.OrderBy(p => p.SqrDist(p2)).First();
                if (pos == p2)
                    break;

                borderCells.Remove(pos);
            
                var dist = map[pos];
                var directions = GetDirectionsToCellsFrom(pos, p => !map.ContainsKey(p) && _field.IsNotWall(p));
                foreach (var direction in directions)
                {
                    var newPos = GetNewPosition(pos, direction); 
                    map[newPos] = dist + 1;
                    borderCells.Add(newPos);
                }
            }
        }
        
        private IEnumerable<Direction> CalculateSteps(IReadOnlyDictionary<Vector2, int> map, Vector2 p1, Vector2 p2)
        {
            var steps = new List<Direction>();
            
            var pos = p2;
            var distance = map[p2];

            while (distance != 0)
            {
                distance -= 1;
                var directions = GetDirectionsToCellsFrom(pos, p => map.ContainsKey(p) && map[p] == distance).ToList();
                var direction = directions.First();
                steps.Add(direction);
                pos = GetNewPosition(pos, direction);
            }

            steps.Reverse();

            return steps.Select(InverseDirection);
        }

        private IEnumerable<Direction> GetDirectionsToCellsFrom(Vector2 pos, Func<Vector2, bool> filter)
        {
            return Enum.GetValues(typeof(Direction)).Cast<Direction>()
                .Where(direction => filter(GetNewPosition(pos, direction)));
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