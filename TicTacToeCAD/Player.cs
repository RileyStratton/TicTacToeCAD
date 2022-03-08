using System;

namespace TicTacToeCAD
{
    internal class Player
    {

        internal char Current = 'X';


        internal void TakeTurn(char[] squares)
        {
            DrawObjects.DrawText("Player " + Current + "'s turn.", 1.5, 0.5);

            int results;
            results = DrawObjects.SelectSquare("\nSelect a square to claim: ");
            squares[results] = Current;
        }

        internal void SwitchPlayer()
        {
            if (Current == 'X') { Current = 'O'; }
            else if (Current == 'O') { Current = 'X'; }
        }
    }
}