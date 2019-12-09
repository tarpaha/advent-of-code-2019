using System.Collections.Generic;
using System.Linq;
using Utils;
using Utils.Computer;

namespace Day_2019_12_07
{
    public static class Circuit2
    {
        public static long GetHighestSignal(long[] program)
        {
            var permutations = Combinatorics.Permute(Enumerable.Range(5, 5).ToList());

            IntCodeComputer previousComputer = null;
            var computers = new List<IntCodeComputer>();
            for (var i = 0; i < 5; i++)
            {
                var computer = new IntCodeComputer();
                computer.LoadProgram(program);
                computers.Add(computer);

                previousComputer?.SetOutput(computer);
                previousComputer = computer;
            }
            
            computers.Last().SetOutput(computers.First());

            var highestSignal = 0L;
            foreach (var permutation in permutations)
            {
                for (var i = 0; i < computers.Count; i++)
                {
                    computers[i].Reset();
                    computers[i].AddInput(permutation.ElementAt(i));
                }
                computers[0].AddInput(0);

                while (computers.Any(computer => computer.CurrentState != IntCodeComputer.State.Halt))
                {
                    foreach (var computer in computers)
                        computer.Run();
                }

                var data = computers[0].GetInput();
                if (data > highestSignal)
                    highestSignal = data;
            }
            
            return highestSignal;
        }
    }
}