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
            int[] input1 = [-2,-2,1,-1];

            // int[] input2 = {2,4,6};
            // string input2 = "c";
            int[] expected = [-2,-2];

            // loging
            // Console.WriteLine($"input: [{string.Join(", ", input1)}]");
            // Console.WriteLine($"input: [{string.Join(", ", input2)}]");
            Console.WriteLine($"expected: [{string.Join(", ", expected)}]");

            int[] result = Stack.AsteroidCollision(input1);
            Console.WriteLine($"result: [{string.Join(", ", result)}]");
            // if (expected == result)
            if (expected.SequenceEqual(result))
            {
                Console.WriteLine("Pass.");
            } else {
                Console.WriteLine("Fail!!");
            }
        }

    }

}