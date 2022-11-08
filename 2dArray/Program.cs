using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    internal class Program
    {
        static int[,] timesTable = new int [10, 10]
        {
            {1,2,3,4,5,6,7,8,9,10},
            {2,4,6,8,10,12,14,16,18,20},
            {3,6,9,12,15,18,21,24,27,30},
            {4,8,12,16,20,24,28,32,36,40},
            {5,10,15,20,25,30,35,40,45,50},
            {6,12,18,24,30,36,42,48,54,60},
            {7,14,21,28,35,42,49,56,63,70},
            {8,16,24,32,40,48,56,64,72,80},
            {9,18,27,36,45,54,63,72,81,90},
            {10,20,30,40,50,60,70,80,90,100},
            };


        static void Main(string[] args)
        {
            TableDrawScale(5);
            Console.ReadKey();
        }
        static void TableDraw()
        {
            for (int h = 0; h <= 9; h++)
            {
                for (int v = 0; v <= 9; v++)
                {
                    Console.Write(timesTable[h, v] + ",");
                }
                Console.WriteLine();
            }
        }
        static void TableDrawScale(int scale)
        {
            for (int h = 0; h <= 9; h++)
            {
                for (int v = 0; v <= 9; v++)
                {
                    for (int x = 1; x <= scale; x++)
                    {
                        for (int w = 1; w <= scale; w++)
                        {
                            Console.Write(timesTable[h, v] + ",");
                        }
                        Console.WriteLine();
                    }
                    
                }
                Console.WriteLine();
            }
        }

    }
}
