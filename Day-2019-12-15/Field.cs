using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_15
{
    public class Field
    {
        private readonly Dictionary<Vector2, int> _cells = new Dictionary<Vector2, int>();

        public IEnumerable<(Vector2, int)> Cells => _cells.Select(cell => (cell.Key, cell.Value));
        
        public void SetCellState(Vector2 position, int state)
        {
            _cells[position] = state;
        }

        public bool HaveCell(Vector2 pos)
        {
            return _cells.ContainsKey(pos);
        }
    }
}
