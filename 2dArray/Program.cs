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
            {"Forest Goblin","Bear","Wolf","Mad Deer" }, // Trees
            {"Plains Goblin","Slime","Bandit","Mad Horse" }, //grass
            {"Water Goblin","Shark","Pirate","Mad Fish" }, //Water
            {"Mountain Goblin","Mad Goat","Giant","vulture" } //Mountain
        };

        // monsterRND stats
        static int[] monsterHealth = new int[16];
        static int[] monsterAttack = new int[16];


        //Map length and width
        static int timeTableScaleX = map.GetLength(1);
        static int timeTableScaleY = map.GetLength(0);
        //Player position on map
        static int playerHorizontal = 1;
        static int playerVertical = 1;

        //player Stats
        static int playerAttack = 10;
        static int playerHealth = 50;


            
        static bool exit = false;

        static Random rnd = new Random();
     
        static int monsterEncounter = rnd.Next(1,20);
        static void Main(string[] args)
        {
            //monsterRND stats initialization
            //Monster Health
            monsterHealth[0] = 30; //Forest Goblin
            monsterHealth[1] = 80; //Bear
            monsterHealth[2] = 50; //Wolf
            monsterHealth[3] = 40; //Mad Deer
            monsterHealth[4] = 30; //Plains Goblin
            monsterHealth[5] = 20; //Slime
            monsterHealth[6] = 50; //Bandit
            monsterHealth[7] = 60; //Mad Horse
            monsterHealth[8] = 30; //Water Goblin
            monsterHealth[9] = 80; //Shark
            monsterHealth[10] = 50; //Pirate
            monsterHealth[11] = 20; //Mad Fish
            monsterHealth[12] = 30; //Mountain Goblin
            monsterHealth[13] = 40; //Mad Goat
            monsterHealth[14] = 100; //Giant
            monsterHealth[15] = 50; //vulture
            //Monster Attack
            monsterAttack[0] = 5; //Forest Goblin
            monsterAttack[1] = 50; //Bear
            monsterAttack[2] = 50; //Wolf
            monsterAttack[3] = 10; //Mad Deer
            monsterAttack[4] = 5; //Plains Goblin
            monsterAttack[5] = 20; //Slime
            monsterAttack[6] = 20; //Bandit
            monsterAttack[7] = 15; //Mad Horse
            monsterAttack[8] = 5; //Water Goblin
            monsterAttack[9] = 50; //Shark
            monsterAttack[10] = 20; //Pirate
            monsterAttack[11] = 5; //Mad Fish
            monsterAttack[12] = 5; //Mountain Goblin
            monsterAttack[13] = 15; //Mad Goat
            monsterAttack[14] = 50; //Giant
            monsterAttack[15] = 20; //vulture

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
                Console.CursorVisible = false;

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
                monsterEncounter = rnd.Next(1,20);
                MonsterCheck();
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
            char mapIcon = map[(playerVertical - 1),(playerHorizontal - 1)];
            int monsterRND = rnd.Next(0, 3);
            string monster;

            switch(mapIcon)
            {
                case '*':
                    monster = monsterTable[0, monsterRND];
                    Battle(monster);
                    break;
                case '`':
                    monster = monsterTable[1, monsterRND];
                    Battle(monster);
                    break;
                case '~':
                    monster = monsterTable[2, monsterRND];
                    Battle(monster);
                    break;
                case '^':
                    monster = monsterTable[3,monsterRND];
                    Battle(monster);
                    break;

                default:
                    monster = monsterTable[monsterRND, monsterRND];
                    Battle(monster);
                    break;
            }
        }
        static void Battle(string monster)
        {
            int monsterHealthTemp = MonsterHealth(monster);
            bool escaped = false;
            Console.WriteLine(monster);
            Console.WriteLine("");
            int playerAttackRND;
            Monster();
            BattleText();
            ConsoleKeyInfo playerInput;


            while (monsterHealthTemp > 0)
            {
                Console.WriteLine(monsterHealthTemp);
                if (playerHealth > 0)
                {
                    playerInput = Console.ReadKey(true);
                    switch (playerInput.Key)
                    {
                        case ConsoleKey.D1:
                            playerAttackRND = rnd.Next(1, playerAttack);
                            monsterHealthTemp -= playerAttackRND;
                            break;
                        case ConsoleKey.D2:
                            monsterHealthTemp = 0;
                            break;
                        case ConsoleKey.D3:
                            playerHealth = 0;
                            break;
                    }
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            MapUpdate();
        }
        static void BattleText()
        {
            Console.WriteLine("+-----------+");
            Console.WriteLine("| Attack: 1 |");
            Console.WriteLine("| Run: 2    |");
            Console.WriteLine("+-----------+");
        }
        static void Monster()
        {
            Console.WriteLine(@" {} ");
            Console.WriteLine(@"/[]\");
            Console.WriteLine(@" || ");
            Console.WriteLine("");
        }
        private static int MonsterHealth(string monster)
        {
            int tempMonsterHealth = 0;
            switch (monster)
            {
                case "Forest Goblin":
                    tempMonsterHealth = monsterHealth[0];
                    return tempMonsterHealth;
                case "Bear":
                    tempMonsterHealth = monsterHealth[1];
                    return tempMonsterHealth;
                case "Wolf":
                    tempMonsterHealth = monsterHealth[2];
                    return tempMonsterHealth;
                case "Mad Deer":
                    tempMonsterHealth = monsterHealth[3];
                    return tempMonsterHealth;
                case "Plains Goblin":
                    tempMonsterHealth = monsterHealth[4];
                    return tempMonsterHealth;
                case "Slime":
                    tempMonsterHealth = monsterHealth[5];
                    return tempMonsterHealth;
                case "Bandit":
                    tempMonsterHealth = monsterHealth[6];
                    return tempMonsterHealth;
                case "Mad Horse":
                    tempMonsterHealth = monsterHealth[7];
                    return tempMonsterHealth;
                case "Water Goblin":
                    tempMonsterHealth = monsterHealth[8];
                    return tempMonsterHealth;
                case "Shark":
                    tempMonsterHealth = monsterHealth[9];
                    return tempMonsterHealth;
                case "Pirate":
                    tempMonsterHealth = monsterHealth[10];
                    return tempMonsterHealth;
                case "Mad Fish":
                    tempMonsterHealth = monsterHealth[11];
                    return tempMonsterHealth;
                case "Mountain Goblin":
                    tempMonsterHealth = monsterHealth[12];
                    return tempMonsterHealth;
                case "Mad Goat":
                    tempMonsterHealth = monsterHealth[13];
                    return tempMonsterHealth;
                case "Giant":
                    tempMonsterHealth = monsterHealth[14];
                    return tempMonsterHealth;
                case "vulture":
                    tempMonsterHealth = monsterHealth[15];
                    return tempMonsterHealth;
                default:
                    return tempMonsterHealth;
            }
        }
    }
}
    
