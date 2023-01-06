using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace AD.Core.Commands.AnnotatePanel
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ShowFamily : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //var getDoc = AppContextRevit.GetDocument(commandData);
            var id = new DockablePaneId(EnumId.DocPaneId);
            var dp = commandData.Application.GetDockablePane(id);
            dp.Show();
            return Result.Succeeded;
        }
        public static string GetPath => $"{typeof(ShowFamily).Namespace}.{nameof(ShowFamily)}";
    }
}
