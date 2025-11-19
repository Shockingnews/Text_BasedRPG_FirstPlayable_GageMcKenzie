using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Text_BasedRPG___FirstPlayable_GageMcKenzie
{
    internal class Program
    {
        static int player_yMax = 25;
        static int player_yMin = 0;
        static int player_xMax = 61;
        static int player_xMin = 0;

        static bool alive = true;

        static int playerPosx = 4;
        static int playerPosy = 6;
        static int playerInputx = 0;
        static int playerInputy = 0;
        static int enemyPosx = 10;
        static int enemyPosy = 10;
        static int turns = 0;
        //static int playerPrex = 7;
        //static int playerPrey = 7;

        static int placeHolder = 0;

        static char water = '~';

        static string path = @"Map.txt";

        static char[] border = new char[]
        {
            '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'
        };
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

        

        static void Display()
        {
           
                Console.Write('┌');
                Console.Write(border);
                Console.Write(border);
                Console.Write("--┐");
                placeHolder += 1;
                Console.SetCursorPosition(0, placeHolder);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {


                        if (j == 0)
                        {

                            Console.SetCursorPosition(0, placeHolder);

                            placeHolder += 1;
                            Console.Write('|');
                        }

                        if (map[i, j] == '`')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map[i, j] == '~')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (map[i, j] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map[i, j] == '^')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);

                        }



                    }
                    Console.Write('|');
                    for (int j = 0; j < map.GetLength(1); j++)
                    {


                        if (j == 0)
                        {
                            Console.SetCursorPosition(0, placeHolder);
                            Console.Write('|');
                            placeHolder += 1;

                        }

                        if (map[i, j] == '`')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map[i, j] == '~')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (map[i, j] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map[i, j] == '^')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.Write(map[i, j]);

                        }


                    }

                    Console.Write('|');
                }

                Console.SetCursorPosition(0, placeHolder);
                Console.Write('└');
                Console.Write(border);
                Console.Write(border);
                Console.Write("--┘");
            placeHolder = 0;


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


            playerPosx += playerInputx;
            playerPosy += playerInputy;

            if (playerPosy == player_yMin)
            {
                playerPosy = 1;
            }
            if (playerPosx == player_xMin)
            {
                playerPosx = 1;
            }
            if (playerPosx == player_xMax)
            {
                playerPosx -= 1;
            }
            if (playerPosy == player_yMax)
            {
                playerPosy -= 1;
            }
            if (turns == 2)
            {
                enemymovement();
            }
            
            

        }
        static void Draw()
        {

            Console.SetCursorPosition(0, 0);
            Display();
            Console.SetCursorPosition(playerPosx, playerPosy);
            //waterPos();
            Console.Write('o');
            Console.SetCursorPosition(enemyPosx, enemyPosy);
            Console.Write("x");

        }
        static void enemymovement()
        {
            if(enemyPosx > playerPosx)
            {
                enemyPosx -= 1;
            }
            if (enemyPosx < playerPosx)
            {
                enemyPosx += 1;
            }
            if ( enemyPosy > playerPosy)
            {
                enemyPosy -= 1;
            }
            if (enemyPosy < playerPosy)
            {
                enemyPosy += 1;
            }
            turns = 0;
        }
        //static void waterPos()
        //{
        //    if(playerPosy == water)
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

