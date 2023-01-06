using AD.Core;
using System.IO;
using System.Windows;
namespace AD.Setup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string rootPath = @"C:\ProgramData\Autodesk\Revit\Addins";
            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            ADCommon.FilterFolder(@"Autodesk\Revit\Addins", "C:");

        }

    }
}
