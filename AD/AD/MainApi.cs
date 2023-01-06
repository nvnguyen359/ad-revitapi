using AD.Core;
using AD.Res;
using AD.Views;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using System;
using System.IO;

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
            // Register dockable
            application.ControlledApplication.ApplicationInitialized +=ControlledApplication_ApplicationInitialized;
            CopyCurrentfileToSetup();
            return Result.Succeeded;
        }
        private void CopyCurrentfileToSetup()
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(currentDir);
            Uri folder = new Uri(directory.FullName);
            var allFiles = Directory.GetFiles(currentDir, "*.*", SearchOption.AllDirectories);
            //E:\WPF\ad-revitapi\AD\AD\bin\Debug
            //E:\WPF\ad-revitapi\AD\AD.Setup\AD\
            var destDir = $"{ADCommon.SplitPath(currentDir)[0]}AD\\AD.Setup\\AD";
            ADCommon.CopyFolder(currentDir, destDir);
            // DirectoryCopy(currentDir, destDir);
        }

        /// <summary>
        /// Register dockable panes in zero state document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlledApplication_ApplicationInitialized(object sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e)
        {
            var managerFamily = new RegisterFamilyCommand();
            managerFamily.Execute(new UIApplication(sender as Application));
        }
    }
}
