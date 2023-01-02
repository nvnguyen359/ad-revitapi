using AD.Core;
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
            var annotateCommandsPanel = app.CreateRibbonPanel(tabName, "Lệnh Chú Thích");
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
        }

    }
}
