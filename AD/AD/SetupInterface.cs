using AD.Ui;
using Autodesk.Revit.UI;

namespace AD
{
    public class SetupInterface
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
            var annotateCommandsPanel = app.CreateRibbonPanel(tabName, "Annotation Commands");
            // Create the ribbon panels.
            var TagWallButtonData = new RevitPushButtonDataModel
            {
                Label = "Tag Wall\nLayers",
                Tooltip = "This is some sample tooltip text,\nreplace it with real one latter,...",
                IconImageName = "tag.png",
                TooltipImageName = "tooltip_TagWallLayers_320x320.png",
                CommandNamespacePath="AD.Core.TagWallLayers",
                Panel= annotateCommandsPanel
            };

            // Create button from provided data.
            var TagWallButton = RevitPushButton.Create(TagWallButtonData);
        }

    }
}
