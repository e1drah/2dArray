using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    internal class Program
    {
        
        static int[,] timesTable = new int [,]
        {
            {1,0,1,0,1,0},
            {0,1,0,1,0,1},
            {1,0,1,0,1,0},
            {0,1,0,1,0,1},
            {1,0,1,0,1,0},
            };
        static int timeTableScaleX = timesTable.GetLength(1);
        static int timeTableScaleY = timesTable.GetLength(0);

        static void Main(string[] args)
        {
            TableDraw(6);
            Console.ReadKey();
        }
        static void TableDraw()
        {
            Console.Write("+");
            for ( int i = 0; i < timesTable.GetLength(1); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();

            for (int vertical = 0; vertical <= (timeTableScaleY - 1); vertical++)
            {
                Console.Write("|");
                for (int horizontal = 0; horizontal <= (timeTableScaleX - 1); horizontal++)
                {
                    Console.Write(timesTable[vertical, horizontal]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.Write("+");
            for (int i = 0; i < timesTable.GetLength(1); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        static void TableDraw(int scale)
        {
            Console.Write("+");
            for (int i = 0; i < (timesTable.GetLength(1)* scale); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
            for (int vertical = 0; vertical <= (timeTableScaleY - 1); vertical++)
            { 
                for (int scaleY = 1; scaleY <= scale; scaleY++ )
                {
                    Console.Write("|");
                    for (int horizontal = 0; horizontal <= (timeTableScaleX - 1); horizontal++)
                    {
                        
                        for (int scalex = 1; scalex <= scale; scalex++)
                        {
                            Console.Write(timesTable[vertical, horizontal]);
                            //Console.ReadKey(true);
                        }
                        
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            Console.Write("+");
            for (int i = 0; i < (timesTable.GetLength(1) * scale); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
        }

    }
}
