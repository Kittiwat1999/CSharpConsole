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
            int[] input1 = {2,1,-1};
            // string input2 = "c";
            int expected =  0;

            // loging
            Console.WriteLine($"input: [{string.Join(", ", input1)}]");
            // Console.WriteLine($"input: [{string.Join(", ", input2)}]");
            Console.WriteLine($"expected: [{string.Join(", ", expected)}]");

            int result = SlidingWindow.PivotIndex(input1);
            Console.WriteLine($"result: [{string.Join(", ", result)}]");
            if (expected == result)
            // if (expected.SequenceEqual(input))
            {
                Console.WriteLine("Pass.");
            } else {
                Console.WriteLine("Fail!!");
            }
        }

    }

}