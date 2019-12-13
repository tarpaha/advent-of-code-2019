using System.Collections.Generic;
using System.Linq;
using Utils.Computer;

namespace Day_2019_12_13
{
    public class ArcadeCabinet
    {
        private readonly Screen _screen;
        private readonly IntCodeComputer _computer;

        public ArcadeCabinet(Screen screen, long[] program)
        {
            _screen = screen;
            _computer = new IntCodeComputer();
            _computer.LoadProgram(program);
        }

        public void Reset()
        {
            _computer.Reset();
            _screen.Clear();
        }
        
        public void Run()
        {
            var output = new BufferOutput();
            _computer.SetOutput(output);
            _computer.Run();
            ProcessOutput(output.Data);
        }

        private void ProcessOutput(IEnumerable<long> data)
        {
            var dataArray = data.ToArray();
            var pos = 0;
            while (pos < dataArray.Length)
            {
                var x = (int)dataArray[pos++];
                var y = (int)dataArray[pos++];
                var tileId = (int)dataArray[pos++];
                _screen.Draw(x, y, tileId);
            }
        }
    }
}