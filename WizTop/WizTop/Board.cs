using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizTop
{
    public class Board
    {
        public string[][] grid;
        public List<Checker> checkers;

        public Board()
        {
            this.Checkers = new List<Checker>();
            this.CreateBoard();
            return;
        }
        public string[][] Grid
        {
            get;
            set;
        }
        public List<Checker> Checkers
        {
            get;
            set;
        }


        public void CreateBoard()
        {
            this.Grid = new string[][]
            {
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
          new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
            };
            return;
        }


        public void GenerateCheckers()
        {
            int[][] whitePositions = new int[][]
           {
          new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0,  5 }, new int[] { 0, 7 },
          new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1,  4 }, new int[] { 1,  6 },
          new int[] { 2, 1 }, new int [] { 2, 3 }, new int[] { 2,  5 }, new int[] { 2, 7}
           };

            int[][] blackPositions = new int[][]
            {
          new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5,  6 },
          new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 },
          new int[] { 7, 0 }, new int[] { 7, 2 }, new int [] { 7, 4 }, new int[] { 7,  6 }
            };

            for (int i = 0; i < 12; i++)

            {
                Checker white = new Checker("white", whitePositions[i]);
                Checker black = new Checker("black", blackPositions[i]);
                Checkers.Add(white);
                Checkers.Add(black);
            }
            return;
        }



        public void PlaceCheckers()
        {
            foreach (var checker in Checkers)
            {
                // Console.WriteLine(checker.Position[0] + " " + checker.Position[1]);
                this.Grid[checker.Position[0]][checker.Position[1]] = checker.Symbol;
            }
            return;
        }


        public void DrawBoard()
        {
            CreateBoard();
            PlaceCheckers();
            Console.WriteLine("  0 1 2 3 4 5 6 7 ");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i + " " + String.Join(" ", this.Grid[i]));
            }
            return;
        }


        public Checker SelectChecker(int row, int column)
        {
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }


        public void RemoveChecker(Checker checker)
        {
            Checkers.Remove(checker);
            return;
        }


        public bool CheckForWin()
        {
            return Checkers.All(x => x.Colour == "white") || !Checkers.Exists(x => x.Colour == "white");
        }
    }
}
