//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Checkers
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            new Game();
//        }
//    }



//    public class Checker
//    {
//        public string symbol;
//        public int[] position;
//        public string color;


//        public Checker(string color, int[] position)
//        {
//            int circleId;

//            if (color == "white")
//            {
//                circleId = int.Parse(" 25CE", System.Globalization.NumberStyles.HexNumber);
//                Color = "white";
//            }
//            else
//            {
//                circleId = int.Parse(" 25C9", System.Globalization.NumberStyles.HexNumber);
//                Color = "black";
//            }
//            this.Symbol = char.ConvertFromUtf32(circleId);
//            this.Position = position;
//        }

//        public string Symbol
//        {
//            get;
//            set;
//        }

//        public int[] Position
//        {
//            get;
//            set;
//        }

//        public string Color
//        {
//            get;
//            set;
//        }
//    }



//    public class Board
//    {
//        public string[][] grid;
//        public List<Checker> checkers;

//        public Board()
//        {
//            this.Checkers = new List<Checker>();
//            this.CreateBoard();
//            return;
//        }
//        public string[][] Grid
//        {
//            get;
//            set;
//        }
//        public List<Checker> Checkers
//        {
//            get;
//            set;
//        }


//        public void CreateBoard()
//        {
//            this.Grid = new string[][]
//            {
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
//            };
//            return;
//        }


//        public void GenerateCheckers()
//        {
//            int[][] whitePositions = new int[][]
//           {
//          new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0,  5 }, new int[] { 0, 7 },
//          new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1,  4 }, new int[] { 1,  6 },
//          new int[] { 2, 1 }, new int [] { 2, 3 }, new int[] { 2,  5 }, new int[] { 2, 7}
//           };

//            int[][] blackPositions = new int[][]
//            {
//          new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5,  6 },
//          new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 },
//          new int[] { 7, 0 }, new int[] { 7, 2 }, new int [] { 7, 4 }, new int[] { 7,  6 }
//            };

//            for (int i = 0; i < 12; i++)

//            {
//                Checker white = new Checker("white", whitePositions[i]);
//                Checker black = new Checker("black", blackPositions[i]);
//                Checkers.Add(white);
//                Checkers.Add(black);
//            }
//            return;
//        }



//        public void PlaceCheckers()
//        {
//            foreach (var checker in Checkers)
//            {
//                // Console.WriteLine(checker.Position[0] + " " + checker.Position[1]);
//                this.Grid[checker.Position[0]][checker.Position[1]] = checker.Symbol;
//            }
//            return;
//        }


//        public void DrawBoard()
//        {
//            CreateBoard();
//            PlaceCheckers();
//            Console.WriteLine("  0 1 2 3 4 5 6 7 ");
//            for (int i = 0; i < 8; i++)
//            {
//                Console.WriteLine(i + " " + String.Join(" ", this.Grid[i]));
//            }
//            return;
//        }


//        public Checker SelectChecker(int row, int column)
//        {
//            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
//        }


//        public void RemoveChecker(Checker checker)
//        {
//            Checkers.Remove(checker);
//            return;
//        }


//        public bool CheckForWin()
//        {
//            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
//        }
//    }



//    public class Game
//    {
//        public Game()
//        {
//            Board board = new Board();
//            board.GenerateCheckers();
//            board.DrawBoard();

//            Console.WriteLine("\nIf you want to move a checker one space diagonally forward, enter 'move'.");
//            Console.WriteLine("\nIf a jump is available for one of your checker, you must enter 'jump'.");

//            string choice = Console.ReadLine();

//            do
//            {
//                switch (choice)
//                {
//                    case "move":

//                        Console.WriteLine("Enter checker Row to move:");
//                        int row = int.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter checker Column:");
//                        int column = int.Parse(Console.ReadLine());

//                        if (board.SelectChecker(row, column) != null)
//                        {
//                            Checker checker = board.SelectChecker(row, column);
//                            Console.WriteLine("Move to which Row: ");
//                            int newRow = int.Parse(Console.ReadLine());
//                            Console.WriteLine("Move to which Column: ");
//                            int newColumn = int.Parse(Console.ReadLine());
//                            checker.Position = new int[] { newRow, newColumn };
//                            board.DrawBoard();
//                        }
//                        else
//                        {
//                            Console.WriteLine("Invalid input");
//                            Console.WriteLine("Enter a valid checker Row:");
//                            row = int.Parse(Console.ReadLine());
//                            Console.WriteLine("Enter a valid checker Column:");
//                            column = int.Parse(Console.ReadLine());
//                        }
//                        break;

//                    case "jump":

//                        Console.WriteLine("Select checker Row to remove:");
//                        int removeRow = int.Parse(Console.ReadLine());
//                        Console.WriteLine("Select checker Column to remove:");
//                        int removeColumn = int.Parse(Console.ReadLine());
//                        Checker changeChecker = board.SelectChecker(removeRow, removeColumn);
//                        board.RemoveChecker(changeChecker);
//                        board.DrawBoard();
//                        break;

//                    default:

//                        Console.WriteLine("Invalid input.");
//                        break;
//                }
//            }
//            while (board.CheckForWin() != true);
//        }
//    }
//}