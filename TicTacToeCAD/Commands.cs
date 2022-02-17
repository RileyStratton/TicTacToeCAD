using System;
using Autodesk.AutoCAD.Runtime;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace TicTacToeCAD
{
    public class Commands
    {
        [CommandMethod("TICTACTOE")]
        public void TicTacToe()
        {
            DrawObjects.TextStyleSize();

            Board board = new Board();
            Player player = new Player();

            for (int i = 1; i <= 9; i++)
            {
                board.DisplayBoard();
                player.TakeTurn(board.Squares);
                if (board.WinCheck(player.Current)) { board.DisplayWinner(player.Current); return; }
                player.SwitchPlayer();
                DrawObjects.EraseAll();
            }

            board.DisplayTie();
        }

        [CommandMethod("HELLO")]
        public void Hello()
        {
            Active.Ed.WriteMessage("\nHello World!");
        }

        [CommandMethod("PRACTICE")]
        public void Practice()
        {
            DrawObjects.TextStyleSize();
            DrawObjects.DrawText("Hello World!", 0, 0);
        }


    }
}
