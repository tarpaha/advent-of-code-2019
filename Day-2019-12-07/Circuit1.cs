using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_07
{
    public static class Circuit1
    {
        public static int GetHighestSignal(int[] program)
        {
            var permutations = Combinatorics.Permute(Enumerable.Range(0, 5).ToList());

            var computers = new List<IntCodeComputer>();
            for (var i = 0; i < 5; i++)
            {
                var computer = new IntCodeComputer();
                computer.LoadProgram(program);
                computers.Add(computer);
            }

            var highestSignal = 0;
            foreach (var permutation in permutations)
            {
                var data = 0;
                for (var i = 0; i < 5; i++)
                {
                    computers[i].Reset();
                    computers[i].SetInput(new [] { permutation.ElementAt(i), data });
                    computers[i].Execute();
                    data = computers[i].GetOutput().First();
                }
                if (data > highestSignal)
                    highestSignal = data;
            }
            
            return highestSignal;
        }
    }
}