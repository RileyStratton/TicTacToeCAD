using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;

namespace TicTacToeCAD
{

    internal static class DrawObjects
    {
        internal static double OriginX = 17.5;
        internal static double OriginY = 17.5;
        internal static double scale = 5;

        internal static void TextStyleSize()
        {
            try
            {
                using (Transaction Trans = Active.DB.TransactionManager.StartTransaction())
                {
                    //Active.Ed.WriteMessage("\nSetting text size");

                    TextStyleTable TST;
                    TST = Trans.GetObject(Active.DB.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                    TextStyleTableRecord TSTR = new TextStyleTableRecord();
                    TSTR = Trans.GetObject(TST["Standard"], OpenMode.ForWrite) as TextStyleTableRecord;
                    TSTR.TextSize = scale / 2;

                    Active.Ed.Regen();
                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Active.Ed.WriteMessage("\nError encountered while setting text size: " + ex.Message);
            }
        }
        
        internal static void DrawLine(double x1, double y1, double x2, double y2)
        {
            try
            {
                using (Transaction Trans = Active.DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(Active.DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //Active.Ed.WriteMessage("\nDrawing Line!");

                    Point3d point1 = new Point3d(OriginX + x1 * scale, OriginY + y1 * scale, 0);
                    Point3d point2 = new Point3d(OriginX + x2 * scale, OriginY + y2 * scale, 0);
                    Line newLine = new Line(point1, point2);

                    BTR.AppendEntity(newLine);
                    Trans.AddNewlyCreatedDBObject(newLine, true);
                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Active.Ed.WriteMessage("\nError encountered while drawing Line: " + ex.Message);
            }

        }

        internal static void DrawText(string text, double x, double y)
        {
            try
            {
                using (Transaction Trans = Active.DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(Active.DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //TextStyleTable TST;
                    //TST = Trans.GetObject(Active.DB.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                    //Active.Ed.WriteMessage("\nDrawing MText!");

                    Point3d point = new Point3d(OriginX + x * scale, OriginY + y * scale, 0);
                    MText mText = new MText
                    {
                        Contents = text,
                        Location = point,
                        Attachment = AttachmentPoint.MiddleCenter,
                        TextHeight = 2.5,
                        //TextStyleId = TST["TicTacToe"]
                    };


                    BTR.AppendEntity(mText);
                    Trans.AddNewlyCreatedDBObject(mText, true);
                    Trans.Commit();
                } 
            }
            catch (System.Exception ex)
            {
                Active.Ed.WriteMessage("\nError encountered while drawing MText: " + ex.Message);
            }
        }

        internal static void EraseAll()
        {
            try
            {
                using (Transaction Trans = Active.DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(Active.DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //Active.Ed.WriteMessage("\nErasing All!");

                    PromptSelectionResult PSR = Active.Ed.SelectAll();

                    SelectionSet SS = PSR.Value;

                    foreach (SelectedObject SO in SS)
                    {
                        DBObject OB = Trans.GetObject(SO.ObjectId, OpenMode.ForWrite) as DBObject;
                        OB.Erase();
                    }
                    
                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Active.Ed.WriteMessage("\nError encountered while erasing all: " + ex.Message);
            }
        }

        internal static int SelectSquare(string prompt)
        {
            while (true)
            {

                try
                {
                    using (Transaction Trans = Active.DB.TransactionManager.StartTransaction())
                    {
                        var options = new PromptSelectionOptions()
                        {
                            MessageForAdding = prompt,
                            SingleOnly = true,
                            SinglePickInSpace = true
                        };

                        var filter = new SelectionFilter(new TypedValue[]
                        {
                        new TypedValue((int)DxfCode.Start, "MTEXT")
                        });

                        PromptSelectionResult PSR = Active.Ed.GetSelection(options, filter);

                        if (!(PSR.Status == PromptStatus.OK))
                        {
                            Active.Ed.WriteMessage("\nUser selected a line or attempted to cancel the operation.");
                        }

                        else if (PSR.Value.Count != 1)
                        {
                            Active.Ed.WriteMessage("\nPlease select only one square.");
                        }

                        else
                        {
                            ObjectIdCollection ObjIds = new ObjectIdCollection(PSR.Value.GetObjectIds());

                            foreach (ObjectId ObjId in ObjIds)
                            {
                                MText mText = (MText)Trans.GetObject(ObjId, OpenMode.ForRead);
                                string contents = mText.Contents.ToString();
                                if (contents == "X" | contents == "O")
                                {
                                    Active.Ed.WriteMessage("\nPlease select a square not taken by a player.");
                                }

                                else
                                {
                                    return Convert.ToInt32(contents);
                                }
                            }
                        }

                    }
            }
                catch (System.Exception ex)
            {
                Active.Ed.WriteMessage("\nError while selecting square: " + ex.Message);
            }
        }
        }

    }
}
