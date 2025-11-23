using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Text_BasedRPG___FirstPlayable_GageMcKenzie
{
    internal class Program
    {
        static string path = @"Map.txt";
        static string[] data = File.ReadAllLines(path);

        static int player_yMax = 25;
        static int player_yMin = 0;
        static int player_xMax = 61;
        static int player_xMin = 0;

        static bool alive = true;
        static bool enemy1alive = true;
        static bool enemy2alive = true;
        static bool playerTurn;
        static bool enemyTurn;

        static int cursoerPosy;
        static (int, int) playerPos = (5, 6);
        static int playerPosx = 4;
        static int playerPosy = 6;
        static int playerInputx = 0;
        static int playerInputy = 0;
        static int enemy1Posx = 10;
        static int enemy1Posy = 10;
        static int enemy2Posx = 20;
        static int enemy2Posy = 20;
        static int turns = 0;
        static int playerPrex = playerPos.Item1;
        static int playerPrey = playerPos.Item2;
        static int futureplayerPos;
        static int futureplayerPosx;
        static int enemy1Prex = enemy1Posx;
        static int enemy1Prey = enemy1Posy;
        static int enemy2Prex = enemy2Posx;
        static int enemy2Prey = enemy2Posy;
        static int playerHealth = 10;
        static int enemy1Health = 10;
        static int enemy2Health = 20;

        static int placeHolder = 0;

        static char water = '~';

        static List<(int, int)> border = new List<(int, int)>();
        static List<(int, int)> money = new List<(int, int)>();
        static List<(int, int)> damageMarker = new List<(int, int)>();
        static List<string> replacementMapString = new List<string>();
        static char[] replacementMapChar;



        static char[,] map = new char[,] // dimensions defined by following data:
    {

        {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},
        {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`',},
        {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`',},
        {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},
        {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`',},
        {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`',},
        {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`',},
        {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`',},

    };
        static void Main(string[] args)
        {
            //Console.WriteLine(map.GetLength(1)*2);
            //Console.WriteLine(map.GetLength(0) * 2);
            
            
            
            

            Console.CursorVisible = false;
            Draw();
            
            
                while (alive)
                {
                if (enemy1alive == true || enemy2alive == true) 
                {
                    playerinput();
                    Update();
                    Draw();
                }

                if (enemy1alive == false && enemy2alive == false)
                { 
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("You Win");
                }




                }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You Lose");



        }

        static void MapDisplay()
        {
            int bottem = 0;
            int mapPosy = 0;
            int mapPosx = 0;
            Console.Write('┌');
            for (int l = 0; l < data[0].Length; l++) 
            {
                border.Add((l, mapPosy));
                Console.Write('-');
                
            }
            Console.Write("┐");
            Console.WriteLine(" ");
            for (int i = 0; i < data.GetLength(0); i++)
            {
                mapPosx += 1;
                
                border.Add((cursoerPosy, i));
                border.Add((cursoerPosy, i+1));
                Console.Write('|');
                for (int j = 0; j < data[i].Length; j++)
                {
                    
                    mapPosy += 1;
                    if (data[i][j] == '`')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(data[i][j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        
                    }
                    if (data[i][j] == '+')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(data[i][j]);
                        money.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (data[i][j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(data[i][j]);
                        border.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;
                        
                    }
                    if (data[i][j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(data[i][j]);
                        border.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;
                        
                    }
                    if (data[i][j] == '_')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(data[i][j]);
                        damageMarker.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    if (data[i][j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(data[i][j]);

                        border.Add((j +1, i +1));
                    }
                    if (mapPosx == data.GetLength(0))
                    {
                        for (int l = 0; l < data[0].Length; l++)
                        {
                            border.Add((bottem, mapPosx+1));
                            bottem += 1;

                        }
                        
                    }
                         
                    
                    cursoerPosy += 1;
                }
                mapPosy = 0;
                Console.WriteLine('|');
                border.Add((cursoerPosy + 1, i));
                border.Add((cursoerPosy + 1, i+1));
                cursoerPosy = 0;
            }
            Console.Write('└');
            for (int l = 0; l < data[0].Length; l++)
            {
                Console.Write('-');
            }
            Console.Write("┘");
        }

        

        static void playerinput()
        {
            playerInputx = 0;
            playerInputy = 0;


            ConsoleKeyInfo input = Console.ReadKey(true);
            //ConsoleKeyInfo input = new ConsoleKeyInfo();

            //while (Console.KeyAvailable)
            //{
            //    input = Console.ReadKey(true);
            //}
            

            if(input.Key == ConsoleKey.W)
            {
                playerInputy -= 1;
                turns += 1;
                
            }

            if (input.Key == ConsoleKey.S)
            {
                playerInputy += 1;
                turns += 1;
            }

            if (input.Key == ConsoleKey.A)
            {
                playerInputx -= 1;
                turns += 1;
            }

            
            if (input.Key == ConsoleKey.D)
            {
                playerInputx += 1;
                turns += 1;
            }
            
            
        }
        static void Update()
        {
            playerPrex = playerPos.Item1;
            playerPrey = playerPos.Item2;

            //if (playerInputx == -1)
            //{
            //    futureplayerPos.Item1 = playerPos.Item1 + playerInputx;
            //}
            //if (playerInputx == 1)
            //{
            //    futureplayerPos.Item1 = playerPos.Item1 + playerInputx;
            //}
            //if (playerInputy == -1)
            //{
            //    futureplayerPos.Item2 = playerPos.Item2 + playerInputy;
            //}
            //if (playerInputx == 1)
            //{
            //    futureplayerPos.Item2 = playerPos.Item2 + playerInputy;
            //}

            playerPos.Item1 += playerInputx;
            playerPos.Item2 += playerInputy;
            
            
            
            playerTurn = true;
            if (playerTurn == true)
            {
                if (playerPos.Item1 == enemy1Posx && playerPos.Item2 == enemy1Posy)
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                    enemy1Health -= 1;
                    
                    
                }
                if (playerPos.Item1 == enemy2Posx && playerPos.Item2 == enemy2Posy)
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                    enemy2Health -= 1;


                }
                //if ( '|' == futureplayerPos.Item1)
                //{

                //    playerPos.Item1 = playerPrex;
                //}
                //if ('|' == futureplayerPos.Item2)
                //{

                //    playerPos.Item2 = playerPrey;
                //}


            }

            if (turns == 2)
            {
                enemyTurn = true;
                enemymovement();
                playerTurn = false;
            }
            if (playerTurn == true)
            {
                if (playerPos.Item1 == enemy1Posx && playerPos.Item2 == enemy1Posy)
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                    enemy1Health -= 1;
                }
                if (playerPos.Item1 == enemy2Posx && playerPos.Item2 == enemy2Posy)
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                    enemy2Health -= 1;
                }
                //if ('|' == futureplayerPos.Item1)
                //{

                //    playerPos.Item1 = playerPrex;
                //}
                //if ('|' == futureplayerPos.Item2)
                //{

                //    playerPos.Item2 = playerPrey;
                //}
                if (border.Contains(playerPos))
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                }
                if (damageMarker.Contains(playerPos))
                {
                    playerHealth -= 1;
                }
                
                //if (money.Contains(playerPos)) 
                //{
                //    int indexMap = Array.IndexOf(data, '+');
                    
                //    replacementMapString.Add(data[indexMap]);
                //    replacementMapChar = replacementMapString[0].ToCharArray();
                //    int indexMapChar = Array.IndexOf(replacementMapChar, '+');
                //    replacementMapChar[indexMapChar] = '`';
                //    string test = replacementMapChar.ToString();
                //    replacementMapString.Remove(data[indexMap]);
                //    replacementMapString.Add(test);
                //    data[indexMap] = replacementMapString[0];
                //}

            }
            if (damageMarker.Contains(playerPos))
            {
                playerHealth -= 1;
            }

            if (border.Contains(playerPos))
            {
                playerPos.Item2 = playerPrey;
                playerPos.Item1 = playerPrex;
            }
            if(playerHealth <= 0)
            {
                playerHealth = 0;
                alive = false;
            }

        }
        static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            MapDisplay();
            Console.SetCursorPosition(playerPos.Item1, playerPos.Item2);
            Console.Write('o');
            enemysAlive();
            Console.SetCursorPosition(1, 26);
            PlayerHUD();
        }
        static void PlayerHUD()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player Health: {playerHealth} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy one Health: {enemy1Health} ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Enemy two Health: {enemy2Health} ");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        static void enemysAlive() 
        {
            if (enemy1Health <= 0) 
            {
                enemy1Health = 0;
                enemy1alive = false;
                
            }
            if (enemy2Health <= 0)
            {
                enemy2Health = 0;
                enemy1alive = false;
                
            }
            else
            {
                Console.SetCursorPosition(enemy1Posx, enemy1Posy);
                Console.Write("x");
                Console.SetCursorPosition(enemy2Posx, enemy2Posy);
                Console.Write("x");
            }

        }
        static void enemymovement()
        {
            enemy1Prex = enemy1Posx;
            enemy1Prey = enemy1Posy;
            enemy2Prex = enemy2Posx;
            enemy2Prey = enemy2Posy;
            if (enemy1Posx > playerPos.Item1)
            {
                enemy1Posx -= 1;
            }
            if (enemy1Posx < playerPos.Item1)
            {
                enemy1Posx += 1;
            }
            if ( enemy1Posy > playerPos.Item2)
            {
                enemy1Posy -= 1;
            }
            if (enemy1Posy < playerPos.Item2)
            {
                enemy1Posy += 1;
            }
            if (border.Contains((enemy1Posx,enemy1Posy)))
            {
                enemy1Posx = enemy1Prex;
                enemy1Posy = enemy1Prey;
            }
            if (border.Contains((enemy1Posx, enemy1Posy)))
            {
                enemy1Health -= 1;
            }

            if (enemyTurn == true)
            {
                if (enemy1Posy == playerPos.Item2 && enemy1Posx == playerPos.Item1)
                {
                    enemy1Posx = enemy1Prex;
                    enemy1Posy = enemy1Prey;
                    playerHealth -= 1;
                }
                if (enemy1Posy == enemy2Posy && enemy1Posx == enemy2Posx)
                {
                    enemy1Posx = enemy1Prex;
                    enemy1Posy = enemy1Prey;
                    
                }
            }
            if (enemy2Posx > playerPos.Item1)
            {
                enemy2Posx -= 1;
            }
            if (enemy2Posx < playerPos.Item1)
            {
                enemy2Posx += 1;
            }
            if (enemy2Posy > playerPos.Item2)
            {
                enemy2Posy -= 1;
            }
            if (enemy2Posy < playerPos.Item2)
            {
                enemy2Posy += 1;
            }
            if (border.Contains((enemy2Posx, enemy2Posy)))
            {
                enemy2Posx = enemy2Prex;
                enemy2Posy = enemy2Prey;
            }
            if (border.Contains((enemy2Posx, enemy2Posy)))
            {
                enemy2Health -= 1;
            }
            if (enemyTurn == true)
            {
                if (enemy2Posy == playerPos.Item2 && enemy2Posx == playerPos.Item1)
                {
                    enemy2Posx = enemy2Prex;
                    enemy2Posy = enemy2Prey;
                    playerHealth -= 1;

                }
                if (enemy1Posy == enemy2Posy && enemy1Posx == enemy2Posx)
                {
                    enemy2Posx = enemy2Prex;
                    enemy2Posy = enemy2Prey;

                }

            }
            turns = 0;
        }
        


    }
}

