using System;
using System.Drawing;

namespace Game16
{
    class Program
    {
        static int moveCounter;
        static int[][] board = new int[4][];
        static Point position = new Point(3, 3);
        static void Main(string[] args)
        {
            board[0] = new int[] { 1, 2, 3, 4 };
            board[1] = new int[] { 5, 6, 7, 8 };
            board[2] = new int[] { 9, 10, 11, 12 };
            board[3] = new int[] { 13, 14, 15, 16 };
            bool isGameOver;
            Shufle(100);
            moveCounter = 0;
            do
            {
                Draw(board);
                var key = Console.ReadKey(false).Key;
                isGameOver = Move(key);
                isGameOver = isGameOver == false ? false : GameOver(board);
                Console.Clear();
            } while (isGameOver);
            Console.WriteLine($"Your score:{moveCounter}\nThx for play :)");
        }

        static void Draw(int[][] board)
        {
            Console.WriteLine(moveCounter);
            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine("+----+----+----+----+");
                Console.Write("|");
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 16)
                        Console.Write($"    |");
                    else
                        Console.Write($" { board[i][j],2} |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("+----+----+----+----+");
        }

        static bool Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (position.Y != 0)
                    {
                        int buff = board[position.Y][position.X];
                        board[position.Y][position.X] = board[position.Y - 1][position.X];
                        board[position.Y - 1][position.X] = buff;
                        position.Y--;
                        moveCounter++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (position.X != 3)
                    {
                        int buff = board[position.Y][position.X];
                        board[position.Y][position.X] = board[position.Y][position.X + 1];
                        board[position.Y][position.X + 1] = buff;
                        position.X++;
                        moveCounter++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (position.Y != 3)
                    {
                        int buff = board[position.Y][position.X];
                        board[position.Y][position.X] = board[position.Y + 1][position.X];
                        board[position.Y + 1][position.X] = buff;
                        position.Y++;
                        moveCounter++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (position.X != 0)
                    {
                        int buff = board[position.Y][position.X];
                        board[position.Y][position.X] = board[position.Y][position.X - 1];
                        board[position.Y][position.X - 1] = buff;
                        position.X--;
                        moveCounter++;
                    }
                    break;
                case ConsoleKey.Escape:
                    return false;
            }
            return true;
        }

        static void Shufle(int numbersOfShufle)
        {
            for (int i = 0; i < numbersOfShufle; i++)
            {
                Random rand = new Random();
                rand.Next(4);
                switch (rand.Next(4))
                {
                    case 0:
                        Move(ConsoleKey.UpArrow);
                        break;
                    case 1:
                        Move(ConsoleKey.RightArrow);
                        break;
                    case 2:
                        Move(ConsoleKey.DownArrow);
                        break;
                    case 3:
                        Move(ConsoleKey.LeftArrow);
                        break;
                }
            }


        }

        static bool GameOver(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != (i * 4) + j + 1)
                        return true;
                }
            }
            return false;
        }
    }
}
