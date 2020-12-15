using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using LibAutoMapper.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LibAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
        GOTO_BEGIN:
            Console.WriteLine("BEGIN");
            string input = string.Empty;
            while (
                   input != "1" && 
                   input != "2" &&
                   input != "3" &&
                   input != "4"
                   )
            {
                Console.WriteLine("Input 1 - Manual Benchmark");
                Console.WriteLine("Input 2 - Summary by Benchmark");
                Console.WriteLine("Input 3 - Manual Benchmark JsonSerializeDeserialize");
                Console.WriteLine("Input 4 - Manual Benchmark MapObjectToDictionary");
                Console.WriteLine("Your choice: ");
                input = Console.ReadLine();
            }

            if (input == "1")
            {
                int input2Value = 0;

                while (input2Value <= 0)
                {
                    Console.Write("Input Number Object:");
                    var input2 = Console.ReadLine();
                    int.TryParse(input2, out input2Value);
                }

                BenchMarkManual benchmarkManual = new BenchMarkManual(numberObject: input2Value);
                benchmarkManual.RunWaitAll();
            }
            else if (input == "2")
            {
                var summary = BenchmarkRunner.Run<BenchMarkAuto>();
                Console.WriteLine(summary);
            }
            else if (input == "3")
            {
                int input2Value = 0;

                while (input2Value <= 0)
                {
                    Console.Write("Input Number Object:");
                    var input2 = Console.ReadLine();
                    int.TryParse(input2, out input2Value);
                }

                BenchMarkJsonSerializeDeserializeManual benchmarkManual = new BenchMarkJsonSerializeDeserializeManual(numberObject: input2Value);
                benchmarkManual.RunWaitAll();
            }
            else if (input == "4")
            {
                int input2Value = 0;

                while (input2Value <= 0)
                {
                    Console.Write("Input Number Object:");
                    var input2 = Console.ReadLine();
                    int.TryParse(input2, out input2Value);
                }

                BenchMarkMapObjectToDictionary benchmarkManual = new BenchMarkMapObjectToDictionary(numberObject: input2Value);
                benchmarkManual.RunWaitAll();
            }
            Console.WriteLine("END");

            goto GOTO_BEGIN;
        }
    }
}
