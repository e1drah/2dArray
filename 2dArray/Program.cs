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

        // monster stats
        static readonly int[] monsterHealth = new int[16];
        static readonly int[] monsterAttack = new int[16];
        static readonly int[] monsterSpeed = new int[16];
        static int[,] monsterStats = new int[,]
        {
            {30,80,50,40,30,20,50,60,30,80,50,20,30,40,100,50}, // monster health
            {5,50,25,10,5,15,10,20,5,50,20,5,5,15,50,20}, // Monster Attack
            {10,35,50,60,10,10,10,40,10,50,10,110,10,15,30,35}, // Monster Speed
            {10,100,50,25,10,5,15,50,10,100,15,5,10,25,100,50 }, // Monster Xp
        };
        


        //Map length and width
        static int timeTableScaleX = map.GetLength(1);
        static int timeTableScaleY = map.GetLength(0);
        //Player position on map
        static int playerHorizontal = 1;
        static int playerVertical = 1;

        //player Stats
        static int playerAttack = 10;
        static int playerHealth = 50;
        static int playerHealthTemp = playerHealth;
        static int playerSpeed = 10;
        static int playerCurrentExp = 0;
        static int expToNextLvl = 100;



        static bool exit = false;

        static readonly Random rnd = new Random();

        static int monsterEncounter = rnd.Next(1, 20);
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
            monsterAttack[2] = 25; //Wolf
            monsterAttack[3] = 10; //Mad Deer
            monsterAttack[4] = 5; //Plains Goblin
            monsterAttack[5] = 15; //Slime
            monsterAttack[6] = 10; //Bandit
            monsterAttack[7] = 20; //Mad Horse
            monsterAttack[8] = 5; //Water Goblin
            monsterAttack[9] = 50; //Shark
            monsterAttack[10] = 20; //Pirate
            monsterAttack[11] = 5; //Mad Fish
            monsterAttack[12] = 5; //Mountain Goblin
            monsterAttack[13] = 15; //Mad Goat
            monsterAttack[14] = 50; //Giant
            monsterAttack[15] = 20; //vulture

            monsterSpeed[0] = 10; //Forest Goblin
            monsterSpeed[1] = 35; //Bear
            monsterSpeed[2] = 50; //Wolf
            monsterSpeed[3] = 60; //Mad Deer
            monsterSpeed[4] = 10; //Plains Goblin
            monsterSpeed[5] = 10; //Slime
            monsterSpeed[6] = 10; //Bandit
            monsterSpeed[7] = 40; //Mad Horse
            monsterSpeed[8] = 10; //Water Goblin
            monsterSpeed[9] = 50; //Shark
            monsterSpeed[10] = 10; //Pirate
            monsterSpeed[11] = 110; //Mad Fish
            monsterSpeed[12] = 10; //Mountain Goblin
            monsterSpeed[13] = 15; //Mad Goat
            monsterSpeed[14] = 30; //Giant
            monsterSpeed[15] = 35; //vulture

            Console.CursorVisible = false;
            MapDraw();
            Hud();
            Instructions();
            PlayerPosition();
            Update();
        }
        static void Update()
        {
            while (exit == false)
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
            for (int i = 0; i < map.GetLength(1); i++)
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
            for (int i = 0; i < (map.GetLength(1) * scale); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
            for (int vertical = 0; vertical <= (timeTableScaleY - 1); vertical++)
            {
                for (int scaleY = 1; scaleY <= scale; scaleY++)
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

            switch (mapIcon)
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
            switch (playerInput.Key)
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
                case ConsoleKey.R:
                    Console.WriteLine("You reat to full health");
                    playerHealthTemp = playerHealth;
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
                Hud();
                Instructions();
                PlayerPosition();

                monsterEncounter -= 1;
            }
            else
            {
                monsterEncounter = rnd.Next(1, 20);
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
            char mapIcon = map[(playerVertical - 1), (playerHorizontal - 1)];
            int monsterRND = rnd.Next(0, 3);
            string monster;

            switch (mapIcon)
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
                    monster = monsterTable[3, monsterRND];
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
            int monsterID = MonsterStat(monster);
            int monsterHealthTemp = monsterStats[0, monsterID]; 
            int monsterAttackTemp = monsterStats[1, monsterID];
            int monsterSpeedTemp = monsterStats[2, monsterID];
            int monsterExpTemp = monsterStats[3, monsterID];
            bool escaped = false;
            int playerAttackRND;

            ConsoleKeyInfo playerInput;


            while (monsterHealthTemp > 0)
            {
                Console.Clear();
                Hud();
                Console.WriteLine(monster);
                Monster();
                BattleText();

                //Console.WriteLine("Monster Health: " + monsterHealthTemp);
                //Console.WriteLine("Player Health: " + playerHealthTemp);
                if (playerHealthTemp > 0)
                {
                    playerInput = Console.ReadKey(true);
                    switch (playerInput.Key)
                    {
                        case ConsoleKey.D1:
                            playerAttackRND = rnd.Next(1, playerAttack);
                            Console.WriteLine(monster + " Takes " + playerAttackRND + " damage");
                            monsterHealthTemp -= playerAttackRND;
                            break;
                        case ConsoleKey.D2:
                            escaped = true;
                            monsterHealthTemp = 0;
                            break;
                    }
                    int monsterAttackRnd = rnd.Next(1, monsterAttackTemp);
                    MonsterAttack(monsterAttackRnd, monsterSpeedTemp, monster);

                    //Console.WriteLine(monsterAttackTemp + " monster Attack");
                    //Console.WriteLine(monsterAttackRnd + " monster Attack");

                }
                else
                {
                    Console.WriteLine("You have died...");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }
            if (escaped == false)
            {
                playerCurrentExp += monsterExpTemp;
                Console.WriteLine("You gained " + monsterExpTemp + " expairiance");
                Console.ReadKey();
                if (playerCurrentExp >= expToNextLvl)
                {
                    LevelUp();
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
        private static int MonsterStat(string monster)
        {
            int tempMonsterHealth = 0;
            switch (monster)
            {
                case "Forest Goblin":
                    //tempMonsterHealth = monsterHealth[0];
                    tempMonsterHealth = 0;
                    return tempMonsterHealth;
                case "Bear":
                    //tempMonsterHealth = monsterHealth[1];
                    tempMonsterHealth = 1;
                    return tempMonsterHealth;
                case "Wolf":
                    tempMonsterHealth = 2;
                    //tempMonsterHealth = monsterHealth[2];
                    return tempMonsterHealth;
                case "Mad Deer":
                    tempMonsterHealth = 3;
                    //tempMonsterHealth = monsterHealth[3];
                    return tempMonsterHealth;
                case "Plains Goblin":
                    tempMonsterHealth = 4;
                    //tempMonsterHealth = monsterHealth[4];
                    return tempMonsterHealth;
                case "Slime":
                    tempMonsterHealth = 5;
                    //tempMonsterHealth = monsterHealth[5];
                    return tempMonsterHealth;
                case "Bandit":
                    tempMonsterHealth = 6;
                    //tempMonsterHealth = monsterHealth[6];
                    return tempMonsterHealth;
                case "Mad Horse":
                    tempMonsterHealth = 7;
                    //tempMonsterHealth = monsterHealth[7];
                    return tempMonsterHealth;
                case "Water Goblin":
                    tempMonsterHealth = 8;
                    //tempMonsterHealth = monsterHealth[8];
                    return tempMonsterHealth;
                case "Shark":
                    tempMonsterHealth = 9;
                    //tempMonsterHealth = monsterHealth[9];
                    return tempMonsterHealth;
                case "Pirate":
                    tempMonsterHealth = 10;
                    //tempMonsterHealth = monsterHealth[10];
                    return tempMonsterHealth;
                case "Mad Fish":
                    tempMonsterHealth = 11;
                    //tempMonsterHealth = monsterHealth[11];
                    return tempMonsterHealth;
                case "Mountain Goblin":
                    tempMonsterHealth = 12;
                    //tempMonsterHealth = monsterHealth[12];
                    return tempMonsterHealth;
                case "Mad Goat":
                    tempMonsterHealth = 13;
                    //tempMonsterHealth = monsterHealth[13];
                    return tempMonsterHealth;
                case "Giant":
                    tempMonsterHealth = 14;
                    //tempMonsterHealth = monsterHealth[14];
                    return tempMonsterHealth;
                case "vulture":
                    tempMonsterHealth = 15;
                    //tempMonsterHealth = monsterHealth[15];
                    return tempMonsterHealth;
                default:
                    return tempMonsterHealth;
            }
        }
        private static int MonsterAttackPower(string monster)
        {
            int tempMonsterAttack = 0;
            switch (monster)
            {
                case "Forest Goblin":
                    tempMonsterAttack = monsterAttack[0];
                    return tempMonsterAttack;
                case "Bear":
                    tempMonsterAttack = monsterAttack[1];
                    return tempMonsterAttack;
                case "Wolf":
                    tempMonsterAttack = monsterAttack[2];
                    return tempMonsterAttack;
                case "Mad Deer":
                    tempMonsterAttack = monsterAttack[3];
                    return tempMonsterAttack;
                case "Plains Goblin":
                    tempMonsterAttack = monsterAttack[4];
                    return tempMonsterAttack;
                case "Slime":
                    tempMonsterAttack = monsterAttack[5];
                    return tempMonsterAttack;
                case "Bandit":
                    tempMonsterAttack = monsterAttack[6];
                    return tempMonsterAttack;
                case "Mad Horse":
                    tempMonsterAttack = monsterAttack[7];
                    return tempMonsterAttack;
                case "Water Goblin":
                    tempMonsterAttack = monsterAttack[8];
                    return tempMonsterAttack;
                case "Shark":
                    tempMonsterAttack = monsterAttack[9];
                    return tempMonsterAttack;
                case "Pirate":
                    tempMonsterAttack = monsterAttack[10];
                    return tempMonsterAttack;
                case "Mad Fish":
                    tempMonsterAttack = monsterAttack[11];
                    return tempMonsterAttack;
                case "Mountain Goblin":
                    tempMonsterAttack = monsterAttack[12];
                    return tempMonsterAttack;
                case "Mad Goat":
                    tempMonsterAttack = monsterAttack[13];
                    return tempMonsterAttack;
                case "Giant":
                    tempMonsterAttack = monsterAttack[14];
                    return tempMonsterAttack;
                case "vulture":
                    tempMonsterAttack = monsterAttack[15];
                    return tempMonsterAttack;
                default:
                    return tempMonsterAttack;
            }
        }
        private static int MonsterSpeed(string monster)
        {
            int tempMonsterSpeed = 0;
            switch (monster)
            {
                case "Forest Goblin":
                    tempMonsterSpeed = monsterSpeed[0];
                    return tempMonsterSpeed;
                case "Bear":
                    tempMonsterSpeed = monsterSpeed[1];
                    return tempMonsterSpeed;
                case "Wolf":
                    tempMonsterSpeed = monsterSpeed[2];
                    return tempMonsterSpeed;
                case "Mad Deer":
                    tempMonsterSpeed = monsterSpeed[3];
                    return tempMonsterSpeed;
                case "Plains Goblin":
                    tempMonsterSpeed = monsterSpeed[4];
                    return tempMonsterSpeed;
                case "Slime":
                    tempMonsterSpeed = monsterSpeed[5];
                    return tempMonsterSpeed;
                case "Bandit":
                    tempMonsterSpeed = monsterSpeed[6];
                    return tempMonsterSpeed;
                case "Mad Horse":
                    tempMonsterSpeed = monsterSpeed[7];
                    return tempMonsterSpeed;
                case "Water Goblin":
                    tempMonsterSpeed = monsterSpeed[8];
                    return tempMonsterSpeed;
                case "Shark":
                    tempMonsterSpeed = monsterSpeed[9];
                    return tempMonsterSpeed;
                case "Pirate":
                    tempMonsterSpeed = monsterSpeed[10];
                    return tempMonsterSpeed;
                case "Mad Fish":
                    tempMonsterSpeed = monsterSpeed[11];
                    return tempMonsterSpeed;
                case "Mountain Goblin":
                    tempMonsterSpeed = monsterSpeed[12];
                    return tempMonsterSpeed;
                case "Mad Goat":
                    tempMonsterSpeed = monsterSpeed[13];
                    return tempMonsterSpeed;
                case "Giant":
                    tempMonsterSpeed = monsterSpeed[14];
                    return tempMonsterSpeed;
                case "vulture":
                    tempMonsterSpeed = monsterSpeed[15];
                    return tempMonsterSpeed;
                default:
                    return tempMonsterSpeed;
            }
        }
        static void MonsterAttack(int tempMonsterAttack, int tempMonsterSpeed, string monster)
        {
            int MonsterSpeedRnd = rnd.Next(0, tempMonsterSpeed);
            int playerSpeedRnd = rnd.Next(1, playerSpeed);
            
            if (playerSpeedRnd >= MonsterSpeedRnd)
            {
                Console.WriteLine("The " + monster + " missed");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("You take " + tempMonsterAttack + " Damage");
                playerHealthTemp -= tempMonsterAttack;
                if (playerHealthTemp < 0)
                {
                    playerHealthTemp = 0;
                }
                Console.ReadKey(true);
            }
        }
        static void LevelUp()
        {
            playerHealth = (int)Math.Round( playerHealth * 1.5f);
            playerHealthTemp = playerHealth;
            playerSpeed = (int)Math.Round(playerSpeed * 1.5f);
            playerAttack = (int)Math.Round(playerAttack * 1.5f);
            playerCurrentExp = 0;
            expToNextLvl = (int)Math.Round(expToNextLvl * 1.5f);

        }
        static void Hud()
        {
            Console.WriteLine("health: " + playerHealthTemp + @"/" + playerHealth + " Exp: " + playerCurrentExp + @"/" + expToNextLvl);
        }
        static void Instructions()
        {
            Console.WriteLine("W/A/S/D to move");
            Console.WriteLine("R to rest");
        }
    }
}
    
