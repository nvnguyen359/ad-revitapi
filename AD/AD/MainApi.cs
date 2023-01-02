using AD.Res;
using Autodesk.Revit.UI;

namespace AD
{
    public class MainApi : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var t = ResourceAssembly.GetAssembly;
            var ui = new SetupApiInterface();
            ui.Initialize(application);
            return Result.Succeeded;
        }
    }
}
