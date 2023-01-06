using AD.Core;
using AD.Views.Pages;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows;

namespace AD.Views
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class RegisterFamilyCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Execute(commandData.Application);
        }
        public Result Execute(UIApplication application)
        {
            if (application != null)
            {
                var data = new DockablePaneProviderData();
                var mainpage = new FamilyMainPage();
                data.FrameworkElement = mainpage as FrameworkElement;
                // Setup initial state.
                var state = new DockablePaneState
                {
                    DockPosition = DockPosition.Right,
                };
                var id = new DockablePaneId(EnumId.DocPaneId);
                application.RegisterDockablePane(id, "Family Manager", mainpage);
            }
            return Result.Succeeded;
        }
    }
}
