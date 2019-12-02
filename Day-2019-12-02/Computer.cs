using System;

namespace Day_2019_12_02
{
    public static class Computer
    {
        public static void Compute(int[] program)
        {
            var ip = 0;
            while (true)
            {
                switch (program[ip])
                {
                    case 1:
                    {
                        var parameter1 = program[ip + 1];
                        var parameter2 = program[ip + 2];
                        var parameter3 = program[ip + 3];
                        program[parameter3] = program[parameter1] + program[parameter2];
                        ip += 4;
                        break;
                    }
                    case 2:
                    {
                        var parameter1 = program[ip + 1];
                        var parameter2 = program[ip + 2];
                        var parameter3 = program[ip + 3];
                        program[parameter3] = program[parameter1] * program[parameter2];
                        ip += 4;
                        break;
                    }
                    case 99:
                        return;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
}