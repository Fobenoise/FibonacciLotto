using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciLotto
{
    class Program
    {
        static void Main(string[] args)
        {
            fLotto();
        }
        private static void fLotto()
        {

            long n1 = 0, n2 = 1, n3;
            Console.WriteLine("Declare starting index of Fibonacci sequence to start with: ");

            uint userVal = Convert.ToUInt32(Console.ReadLine());

            var result = new List<long>();

            Console.WriteLine();
            //Console.WriteLine("Here is " + Convert.ToString(userVal) + " iterations of Fibonacci sequence:");
            Console.WriteLine();

            if (n1 == 0 || n2 == 1)
            {
                n1 = 1; //uncomment to exclude zero
                Console.WriteLine(" {0}", n1);
                Console.WriteLine(" {0}", n2);
                result.Add(n1);
                result.Add(n2);
            }
            for (int i = 2; i < userVal + 5; i++)
            {

                n3 = n2 + n1;

                if (n3 < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" {0}", n3);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Data type ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0} ", n3.GetTypeCode());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("out of range...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine(" {0}", n3);
                    n1 = n2;
                    n2 = n3;
                    result.Add(n3);
                }
            }
            var fibonacciCounter = result.TakeLast(6);
            var finalResult = new List<long>();

            foreach (var item in fibonacciCounter)
            {
                finalResult.Add(item % 59);
            }

            for (int i = 0; i < finalResult.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                finalResult[i] = (finalResult[i] + finalResult[i - 1]) % 59;
            }

            Console.WriteLine("Your Fibonacci Lotto numbers: " + string.Join(" ", finalResult));

            Console.WriteLine();

            Console.WriteLine("Calculate next?y/n");

            var c = Console.ReadKey().Key;

            if (c.ToString() == "y" || c.ToString() == "Y")
            {
                Console.Clear();
                fLotto();
            }
            else
            {
                return;
            }


        }
    }

}

