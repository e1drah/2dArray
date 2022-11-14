using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dArray
{
    internal class Program
    {

        static char[,] map = new char[,] // dimensions defined by following data:
        {
            {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
            {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
            {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
            {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        };

        // map legend:
        // ^ = mountain
        // ` = grass
        // ~ = water
        // * = trees
        static string[,] monsterTable = new string[,]
        {
            {"Forest Goblin","Bear","Wolf","Horse Deer" }, // Trees
            {"plains Goblin","Slime","Bandit","Mad Horse" }, //grass
            {"Water Goblin","Shark","Pirate","Mad Fish" }, //Water
            {"Mountain Goblin","Cougar","Giant","vulture" } //Mountain
        };
        
        //Map length and width
        static int timeTableScaleX = map.GetLength(1);
        static int timeTableScaleY = map.GetLength(0);
        //Player position on map
        static int playerHorizontal = 1;
        static int playerVertical = 1;
            
        static bool exit = false;

        static Random rnd = new Random();
     
        static int monsterEncounter = rnd.Next(1,20);
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MapDraw();
            PlayerPosition();
            update();
        }
        static void update()
        {
            while(exit == false)
            {
                //Console.Clear();
               // MapDraw();


                PlayerMove();
            }
        }
        //draws map 
        static void MapDraw()
        {
            Console.Write("+");
            for ( int i = 0; i < map.GetLength(1); i++)
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
                    MapColour(vertical, horizontal);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.Write("+");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write("—");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        //draws map to scale
        static void MapDraw(int scale)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("+");
            for (int i = 0; i < (map.GetLength(1)* scale); i++)
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
                            MapColour(vertical, horizontal);
                            //Console.ReadKey(true);
                        }
                        
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            Console.Write("+");
            for (int i = 0; i < (map.GetLength(1) * scale); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");

            Console.WriteLine(playerVertical);
        }
        //detirmines the colour of each tile
        static void MapColour(int v, int h)
        {
            char mapIcon = map[v, h];

            switch(mapIcon)
            {
                case '^':
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(map[v, h]);
                    Console.ResetColor();
                    break;
                case '`':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(map[v, h]);
                    Console.ResetColor();
                    break;
                case '~':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(map[v, h]);
                    Console.ResetColor();
                    break;
                case '*':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(map[v, h]);
                    Console.ResetColor();
                    break;

                default:
                    Console.Write(map[v, h]);
                    break;

            }
        }
        //detirmines the position of player
        static void PlayerMove()
        {
            ConsoleKeyInfo playerInput;


            playerInput = Console.ReadKey(true);
            switch(playerInput.Key)
            {   
                case ConsoleKey.W:
                    playerVertical -= 1;
                    break;
                case ConsoleKey.A:
                    playerHorizontal -= 1;
                    break;
                case ConsoleKey.S:
                    playerVertical += 1;
                    break;
                case ConsoleKey.D:
                    playerHorizontal += 1;
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
                default:
                    Console.WriteLine(playerInput.Key + " is not a valid input");
                    break;
                }
            MapUpdate();
        }
        //prints the player to the screen
        static void PlayerPosition()
        {
            Console.SetCursorPosition(playerHorizontal, playerVertical);
            Console.Write("@");
        }
        //handles updating the map
        static void MapUpdate()
        {
            BoundCheck();
            Console.Clear();
            if (monsterEncounter > 0)
            {
                MapDraw();
                PlayerPosition();
                monsterEncounter -= 1;
            }
            else
            {
                MonsterCheck();
                Console.ReadKey(true);
                monsterEncounter = rnd.Next(1,20);
            }
        }
        //Checks if the player has reatched the map bourders
        static void BoundCheck()
        {
            if (playerHorizontal > timeTableScaleX)
            {
                playerHorizontal -= 1;
            }
            if (playerHorizontal < 1)
            {
                playerHorizontal += 1;
            }
            if (playerVertical < (timeTableScaleY + 1))
            {
                playerVertical += 1;
            }
            if (playerVertical > 1)
            {
                playerVertical -= 1;
            }

        }
        static void MonsterCheck()
        {
            Console.WriteLine((playerHorizontal - 1) + " " + (playerVertical - 1));
            Console.WriteLine();
            Console.WriteLine(timeTableScaleX);
            Console.WriteLine(timeTableScaleY);

            Console.ReadKey();

            char mapIcon = map[(playerVertical - 1),(playerHorizontal - 1)];
            int monster = rnd.Next(0, 3);

            switch(mapIcon)
            {
                case '^':
                    Console.WriteLine(monsterTable[3,monster]);
                    Console.WriteLine(mapIcon);
                    break;
                case '`':
                    Console.WriteLine(monsterTable[1, monster]);
                    break;
                case '~':
                    Console.WriteLine(monsterTable[2, monster]);
                    break;
                case '*':
                    Console.WriteLine(monsterTable[0, monster]);
                    break;

                default:
                    Console.WriteLine(monsterTable[monster, monster]);
                    break;
            }
        }
    }
}
    
