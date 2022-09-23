using System;
using System.Collections.Generic;
using System.Linq;

namespace WizTop
{
    class Program
    {
        static void Main(string[] args)
        {
            new Game();
        }
    }

    public class Game
    {
        public Game()
        {
            Board board = new Board();
            board.GenerateCheckers();
            board.DrawBoard();

            Console.WriteLine("\nIf you want to move a checker one space diagonally forward, enter 'move'.");
            Console.WriteLine("\nIf a jump is available for one of your checker, you must enter 'jump'.");

            string choice = Console.ReadLine();

            do
            {
                switch (choice)
                {
                    case "move":

                        Console.WriteLine("Enter checker Row to move:");
                        int row = int.Parse((Console.ReadLine()));
                        Console.WriteLine("Enter checker Column:");
                        int column = int.Parse(Console.ReadLine());

                        if (board.SelectChecker(row, column) != null)
                        {
                            Checker checker = board.SelectChecker(row, column);
                            Console.WriteLine("Move to which Row: ");
                            int newRow = int.Parse(Console.ReadLine());
                            Console.WriteLine("Move to which Column: ");
                            int newColumn = int.Parse(Console.ReadLine());
                            checker.Position = new int[] { newRow, newColumn };
                            board.DrawBoard();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.WriteLine("Enter a valid checker Row:");
                            row = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter a valid checker Column:");
                            column = int.Parse(Console.ReadLine());
                        }
                        break;

                    case "jump":

                        Console.WriteLine("Select checker Row to remove:");
                        int removeRow = int.Parse(Console.ReadLine());
                        Console.WriteLine("Select checker Column to remove:");
                        int removeColumn = int.Parse(Console.ReadLine());
                        Checker changeChecker = board.SelectChecker(removeRow, removeColumn);
                        board.RemoveChecker(changeChecker);
                        board.DrawBoard();
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            } while (board.CheckForWin() != true);

        }
    }
}