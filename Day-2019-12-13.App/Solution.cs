using System;
using System.Drawing.Imaging;
using System.Linq;
using Utils;

namespace Day_2019_12_13.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }
        
        private readonly ArcadeCabinet _arcadeCabinet;
        private readonly Screen _screen; 
        
        public Solution()
        {
            var program = Input.GetData()
                .Split(',')
                .Select(long.Parse)
                .ToArray();
            _screen = new Screen();
            _arcadeCabinet = new ArcadeCabinet(_screen, program);
        }

        public object SolvePart1()
        {
            _arcadeCabinet.Reset();
            _arcadeCabinet.Run();
            return _screen.BlockTilesCount;
        }

        public object SolvePart2()
        {
            var player = new Player(_arcadeCabinet);
            var score = player.Play(2, stepCount =>
            {
                // uncomment to save each step to images folder
                //Image.FromScreen(_screen, 16).Save($"images/{stepCount:D6}.png", ImageFormat.Png);
            });
            return score;
        }
    }
}