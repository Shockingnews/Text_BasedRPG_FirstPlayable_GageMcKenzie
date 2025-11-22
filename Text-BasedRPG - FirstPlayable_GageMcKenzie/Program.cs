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
        static bool playerTurn;
        static bool enemyTurn;

        static int cursoerPosy;
        static (int, int) playerPos = (5, 6);
        static int playerPosx = 4;
        static int playerPosy = 6;
        static int playerInputx = 0;
        static int playerInputy = 0;
        static int enemyPosx = 10;
        static int enemyPosy = 10;
        static int turns = 0;
        static int playerPrex = playerPos.Item1;
        static int playerPrey = playerPos.Item2;
        static int futureplayerPos;
        static int futureplayerPosx;
        static int enemyPrex = enemyPosx;
        static int enemyPrey = enemyPosy;
        static int playerHealth = 10;
        static int enemyHealth = 10;

        static int placeHolder = 0;

        static char water = '~';

        static List<(int, int)> border = new List<(int, int)>();




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
                playerinput();
                Update();
                Draw();



            }


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
                border.Add((cursoerPosy+1, i));
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
                if (playerPos.Item1 == enemyPosx && playerPos.Item2 == enemyPosy)
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                    enemyHealth -= 1;
                    
                    
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
                //enemymovement();
                playerTurn = false;
            }
            if (playerTurn == true)
            {
                if (playerPos.Item1 == enemyPosx && playerPos.Item2 == enemyPosy)
                {
                    playerPos.Item2 = playerPrey;
                    playerPos.Item1 = playerPrex;
                    enemyHealth -= 1;
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

            }


            if (border.Contains(playerPos))
            {
                playerPos.Item2 = playerPrey;
                playerPos.Item1 = playerPrex;
            }

        }
        static void Draw()
        {

            Console.SetCursorPosition(0, 0);
            MapDisplay();
            Console.SetCursorPosition(playerPos.Item1, playerPos.Item2);
            //waterPos();
            Console.Write('o');
            Console.SetCursorPosition(enemyPosx, enemyPosy);
            Console.Write("x");

        }
        //static void enemymovement()
        //{
        //    enemyPrex = enemyPosx;
        //    enemyPrey = enemyPosy;
        //    if (enemyPosx > playerPos.Item1)
        //    {
        //        enemyPosx -= 1;
        //    }
        //    if (enemyPosx < playerPos.Item1)
        //    {
        //        enemyPosx += 1;
        //    }
        //    if ( enemyPosy > playerPos.Item2)
        //    {
        //        enemyPosy -= 1;
        //    }
        //    if (enemyPosy < playerPos.Item2)
        //    {
        //        enemyPosy += 1;
        //    }
            
        //    if (enemyTurn == true)
        //    {
        //        if (enemyPosy == playerPos.Item2 && enemyPosx == playerPos.Item1)
        //        {
        //            enemyPosx = enemyPrex;
        //            enemyPosy = enemyPrey;
        //            playerHealth -= 1;
        //        }
        //    }
            
        //    turns = 0;
        //}
        //static void waterPos()
        //{
        //    if(playerPos.Item2 == water)
        //    {
        //        if (playerPosx == water)
        //        {
        //            Console.ReadKey(true);
        //            Console.Clear();
        //            Console.Write("hi");
        //        }
        //    }
            
        //}


    }
}

