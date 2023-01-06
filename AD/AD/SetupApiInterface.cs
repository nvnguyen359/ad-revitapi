using AD.Core;
using AD.Core.Commands.AnnotatePanel;
using AD.UI;
using Autodesk.Revit.UI;

namespace AD
{
    public class SetupApiInterface
    {
        /**
           <summary>
                Initializes all interface elements on custom created Revit tab.
          </summary>
         <param name = "app">The application.</param>
        */
        public void Initialize(UIControlledApplication app)
        {
            // Create ribbon tab.
            string tabName = "AD";
            app.CreateRibbonTab(tabName);
            var annotateCommandsPanel = app.CreateRibbonPanel(tabName, TranslateGoogle.L("Annotation Commands"));
            // Create the ribbon panels.
            var TagWallButtonData = new RevitPushButtonDataModel
            {
                Label = "Gắn thẻ \n Tường",
                Tooltip = "Đây là một số văn bản chú giải công cụ mẫu,\n thay thế nó bằng một cái sau, ...",
                IconImageName = "icon_TagWallLayers_32x32.png",
                TooltipImageName = "tooltip_TagWallLayers_320x320.png",
                CommandNamespacePath = TagWallLayersCommand.GetPath,
                Panel= annotateCommandsPanel
            };

            // Create button from provided data.
            var TagWallButton = RevitPushButton.Create(TagWallButtonData);
            #region manager
            var annotateShowFamily = app.CreateRibbonPanel(tabName, TranslateGoogle.L("Family"));
            var familyManagerShowButtonData = new RevitPushButtonDataModel
            {
                Label = $"{TranslateGoogle.L("Show Family \n Manager")}",
                Panel = annotateShowFamily,
                Tooltip = TranslateGoogle.L("This is some sample tooltip text,\nreplace it with real one latter,..."),
                CommandNamespacePath = ShowFamily.GetPath,
                IconImageName = "icon_ShowFamilyManager_32x32.png",
                TooltipImageName = "tooltip_ShowFamilyManager_320x320.png"
            };
            RevitPushButton.Create(familyManagerShowButtonData);
            #endregion
        }

    }
}
