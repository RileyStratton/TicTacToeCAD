using System;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace TicTacToeCAD
{
    public static class Active
    {
        public static Document Doc => Application.DocumentManager.MdiActiveDocument;
        public static Editor Ed => Doc.Editor;
        public static Database DB => Doc.Database;

        //public static void UsingTransaction(Action<Transaction> action)
        //{
        //    using (var transaction = DB.TransactionManager.StartTransaction())
        //    {
        //        action(transaction);

        //        transaction.Commit();
        //    }
        //}
    }
}