using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        static int placeHolder = 0;

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
            while (alive)
            {
                playerinput();
                Update();
                Draw();
                
            }
            

        }

        static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Display();
            Console.SetCursorPosition(playerPosx, playerPosx);
            Console.Write("o");

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
            if (playerPosx == player_xMax || playerPosx == player_xMin || playerPosx +1 == '|' || playerPosx - 1 == '|')
            {
                alive = false;
                return;
            }
            if (playerPosy == player_yMax || playerPosy == player_yMin || playerPosy + 1 == '-' || playerPosy - 1 == '-')
            {
                alive = false;
                return;
            }

            if(input.Key == ConsoleKey.W)
            {
                playerInputy -= 1;
                
            }

            if (input.Key == ConsoleKey.S)
            {
                playerInputy += 1;
                
            }

            if (input.Key == ConsoleKey.A)
            {
                playerInputx -= 1;
                
            }

            
            if (input.Key == ConsoleKey.D)
            {
                playerInputx += 1;
                
            }
            
        }
        static void Update()
        {
            playerPosx += playerInputx;
            playerPosy += playerInputy;
        }

        void enemymovement()
        {

        }


    }
}

