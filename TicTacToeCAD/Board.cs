using System;
using System.Collections.Generic;

namespace TicTacToeCAD
{
    public class Board
    {

        public char[] Squares = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public Dictionary<int, double[]> SquareXY = new Dictionary<int, double[]>();

        

        public int Win1;
        public int Win2;

        public Board()
        {
            SquareXY.Add(1, new double[2] { 0.5, -0.5 });
            SquareXY.Add(2, new double[2] { 1.5, -0.5 });
            SquareXY.Add(3, new double[2] { 2.5, -0.5 });
            SquareXY.Add(4, new double[2] { 0.5, -1.5 });
            SquareXY.Add(5, new double[2] { 1.5, -1.5 });
            SquareXY.Add(6, new double[2] { 2.5, -1.5 });
            SquareXY.Add(7, new double[2] { 0.5, -2.5 });
            SquareXY.Add(8, new double[2] { 1.5, -2.5 });
            SquareXY.Add(9, new double[2] { 2.5, -2.5 });
        }



        public void DisplayBoard()
        {
            // Vertical lines
            DrawObjects.DrawLine(1, 0, 1, -3);
            DrawObjects.DrawLine(2, 0, 2, -3);

            // Horizontal lines
            DrawObjects.DrawLine(0, -1, 3, -1);
            DrawObjects.DrawLine(0, -2, 3, -2);

            // Display Square numbers
            for (int i = 1; i <= 9; i++)
            {
                DrawObjects.DrawText(Convert.ToString(Squares[i]), SquareXY[i][0], SquareXY[i][1]);
            }
        }

        public bool WinCheck(char Current)
        {
            if (Squares[1] == Current & Squares[2] == Current & Squares[3] == Current) { Win1 = 1; Win2 = 3; return true;}
            else if (Squares[4] == Current & Squares[5] == Current & Squares[6] == Current) { Win1 = 4; Win2 = 6; return true; }
            else if (Squares[7] == Current & Squares[8] == Current & Squares[9] == Current) { Win1 = 7; Win2 = 9; return true; }

            // Vertical win conditions
            else if (Squares[1] == Current & Squares[4] == Current & Squares[7] == Current) { Win1 = 1; Win2 = 7; return true; }
            else if (Squares[2] == Current & Squares[5] == Current & Squares[8] == Current) { Win1 = 2; Win2 = 8; return true; }
            else if (Squares[3] == Current & Squares[6] == Current & Squares[9] == Current) { Win1 = 3; Win2 = 9; return true; }

            // Diagonal win conditions
            else if (Squares[1] == Current & Squares[5] == Current & Squares[9] == Current) { Win1 = 1; Win2 = 9; return true; }
            else if (Squares[3] == Current & Squares[5] == Current & Squares[7] == Current) { Win1 = 3; Win2 = 7; return true; }

            // No win conditions
            else { return false; }
        }

        public void DisplayWinner(char Current)
        {
            DrawObjects.EraseAll();
            DisplayBoard();
            DrawObjects.DrawLine(SquareXY[Win1][0], SquareXY[Win1][1], SquareXY[Win2][0], SquareXY[Win2][1]);
            DrawObjects.DrawText("Player " + Current + " wins!", 1.5, 0.5);
        }

        public void DisplayTie()
        {
            DrawObjects.EraseAll();
            DisplayBoard();
            DrawObjects.DrawText("Cat. No one wins.", 1.5, 0.5);
        }

    }
}
