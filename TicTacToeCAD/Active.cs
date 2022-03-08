using System;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace TicTacToeCAD
{
    internal static class Active
    {
        internal static Document Doc => Application.DocumentManager.MdiActiveDocument;
        internal static Editor Ed => Doc.Editor;
        internal static Database DB => Doc.Database;

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