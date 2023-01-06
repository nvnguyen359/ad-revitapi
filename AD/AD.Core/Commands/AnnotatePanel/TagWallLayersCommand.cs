using AD.Core.Commands.AnnotatePanel;
using AD.Core.Utility;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Text;

namespace AD.Core
{
    [Transaction(TransactionMode.Manual)]
    public class TagWallLayersCommand : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Application context.
            var getDoc = AppContextRevit.GetDocument(commandData);
            var docUi = getDoc.AdUiDoc;
            var doc = docUi.Document;
            // Check if we are in the Project, not in family one
            if (getDoc.AdDocument.IsFamilyDocument)
            {
                DialogBox.Display(TranslateGoogle.L("Can't use command in family document"), WindowType.Warning);
                return Result.Cancelled;
            }
            // Get access to current view.
            var activeView = getDoc.ActiveView;

            // Check if Text Note can be created in currently active project view.
            bool canCreateTextNoteInView = false;
            switch (activeView.ViewType)
            {
                case ViewType.FloorPlan:
                case ViewType.CeilingPlan:
                case ViewType.Detail:
                case ViewType.Elevation:
                case ViewType.Section:
                    canCreateTextNoteInView = true;
                    break;
            }
            if (!canCreateTextNoteInView)
            {
                DialogBox.Display(TranslateGoogle.L("Text Note element can't be created in the current view."), WindowType.Error);
                return Result.Cancelled;
            }
            // itit form and load data
            var form = new FormTagWall(getDoc.AdUiDoc);
            form.ShowDialog();
            if (form.DialogResult==false) { return Result.Cancelled; }
            var userInf = form.GetSelections;
            // ask user select one wall
            var obType = ObjectType.Element;
            var selectionFilter = new ADSelectionFilterByCategory("Walls");
            string status = TranslateGoogle.L("Select one base wall.");
            var selectionReference = getDoc.AdUiDoc.Selection.PickObject(obType, selectionFilter, status);
            var selectionElement = getDoc.AdDocument.GetElement(selectionReference);
            if (selectionElement is Wall wall && wall.IsStackedWall)
            {
                DialogBox.Display("Wall you selected is category of the Stacked Wall.\nIt's not supported by this command.", WindowType.Warning);
                return Result.Cancelled;
            }
            var layers = (selectionElement as Wall).WallType.GetCompoundStructure().GetLayers();
            // get layer information 
            var meg = new StringBuilder();
            foreach (var layer in layers)
            {
                var material = doc.GetElement(layer.MaterialId) as Material;
                meg.AppendLine();
                if (userInf.Function)
                {
                    meg.Append(layer.Function.ToString());
                }
                if (userInf.Name)
                {
                    var m = material!=null ? $" {TranslateGoogle.L(material.Name)}" : $" <by category>";
                    meg.Append(m);
                }
                //  Convert units to metric.
                if (userInf.Thickness)
                {
                    double m = LengthUnitConverter.ConvertToMetric(layer.Width, userInf.UnitType, userInf.Decimals);
                    meg.Append($" {m} {userInf.UnitType}");
                }

            }
            // create text note options
            var textNote = new TextNoteOptions()
            {
                HorizontalAlignment= HorizontalTextAlignment.Left,
                VerticalAlignment= VerticalTextAlignment.Top,
                TypeId= userInf.TextTypeId
            };
            using (Transaction tran = new Transaction(doc))
            {
                tran.Start("Tag Wall Layers Command");
                var point = new XYZ();
                if (activeView.ViewType == ViewType.Elevation
                    || activeView.ViewType == ViewType.Section)
                {
                    var plane = Plane.CreateByNormalAndOrigin(activeView.ViewDirection, activeView.Origin);
                    activeView.SketchPlane = SketchPlane.Create(doc, plane);
                    point = docUi.Selection.PickPoint("Pick text note location point");
                }
                else
                {
                    point = docUi.Selection.PickPoint("Pick text note location point");
                }
                var textNoteO = TextNote.Create(doc, activeView.Id, point, meg.ToString(), textNote);
                tran.Commit();
            }
            return Result.Succeeded;
        }
        public static string GetPath => $"{typeof(TagWallLayersCommand).Namespace}.{nameof(TagWallLayersCommand)}";

    }
}
