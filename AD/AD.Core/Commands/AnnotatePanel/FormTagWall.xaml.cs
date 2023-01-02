using AD.Core.Models;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows;


namespace AD.Core.Commands.AnnotatePanel
{
    /// <summary>
    /// Interaction logic for FormTagWall.xaml
    /// </summary>
    public partial class FormTagWall : Window
    {
        private UIDocument _uIDocument;
        private Document _doc;
        private ElementId textTypeId = null;

        /// <summary>
        /// The unit type to convert to.
        /// </summary>
        private LengthUnitType unitType = LengthUnitType.milimeter;

        /// <summary>
        /// The decimal places precision.
        /// </summary>
        private int decimals = 1;
        public FormTagWall()
        {
            InitializeComponent();
        }
        /**
<summary>init form and load data</summary>
<param name="uIDocument">uiDocument</param>
*/
        public FormTagWall(UIDocument uIDocument)
        {
            this._uIDocument = uIDocument;
            this._doc= uIDocument.Document;

            InitializeComponent();
        }
        /**
        * init
*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetTypeList();
            cbUnitType.ItemsSource = Enum.GetValues(typeof(LengthUnitType));
            cbUnitType.SelectedIndex = 1;

            cbDecimalPlaces.ItemsSource= new List<int>() { 0, 1, 2, 3 };
            cbDecimalPlaces.SelectedIndex = 2;
        }
        private void GetTypeList()
        {
            var colector = new FilteredElementCollector(this._doc).OfClass(typeof(TextElementType));
            var list = new List<KeyValuePair<string, ElementId>>();
            foreach (var e in colector)
            {
                list.Add(new KeyValuePair<string, ElementId>(e.Name, e.Id));
            }
            cbTextNoteTypes.ItemsSource = list;
            cbTextNoteTypes.SelectedIndex = 0;


        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult= false;
            this.Close();
        }

        private void cbTextNoteTypes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // var t = (KeyValuePair<string, ElementId>)e.Source;

        }
        public FormTagWallData GetSelections => new FormTagWallData()
        {
            Function = (bool)cbFn.IsChecked,
            Name = (bool)cbName.IsChecked,
            Thickness = (bool)cbThick.IsChecked,
            TextTypeId = ((KeyValuePair<string, ElementId>)cbTextNoteTypes.SelectedItem).Value,
            UnitType = (LengthUnitType)cbUnitType.SelectedValue,
            Decimals = (int)cbDecimalPlaces.SelectedValue
        };
        public FormTagWallData GetData()
        {
            var t1 = new FormTagWallData()
            {
                Function = (bool)cbFn.IsChecked,
                Name = (bool)cbName.IsChecked,
                Thickness = (bool)cbThick.IsChecked,
                TextTypeId = ((KeyValuePair<string, ElementId>)cbTextNoteTypes.SelectedItem).Value,
                UnitType = (LengthUnitType)cbUnitType.SelectedValue,
                Decimals = (int)cbDecimalPlaces.SelectedValue
            };
            return t1;
        }
    }
}
