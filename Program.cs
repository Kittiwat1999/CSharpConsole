using System;
using System.Formats.Asn1;
using System.Globalization;
using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input1 = new[]
            {
                new[] { 3, 2, 1 },
                new[] { 1, 7, 6 },
                new[] { 2, 7, 7 }
            };

            // int[] input2 = {2,4,6};
            // string input2 = "c";
            int expected = 1;

            // loging
            // Console.WriteLine($"input: [{string.Join(", ", input1)}]");
            // Console.WriteLine($"input: [{string.Join(", ", input2)}]");
            Console.WriteLine($"expected: [{string.Join(", ", expected)}]");

            int result = HashMapSet.EqualPairsLinQ(input1);
            Console.WriteLine($"result: [{string.Join(", ", result)}]");
            if (expected == result)
            // if (expected.SequenceEqual(result))
            {
                Console.WriteLine("Pass.");
            } else {
                Console.WriteLine("Fail!!");
            }
        }

    }

}