using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WBF_mozifoglalas
{
    public class mozi
    {
        public string cim { get; set; }
        public DateTime idopont { get; set; }
        public string terem { get; set; }
        public int szabadhelyek { get; set; }
        public bool _3D { get; set; }

        public mozi(string cím, DateTime idopont, string terem, int szabadhelyek, bool _3D)
        {
            this.cim = cím;
            this.idopont = idopont;
            this.terem = terem;
            this.szabadhelyek = szabadhelyek;
            this._3D = _3D;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<mozi> mozifilmek = new ObservableCollection<mozi>();
        public MainWindow()
        {
            InitializeComponent();
            mozifilmek.Add(new mozi("fnaf1", new DateTime(2025, 12, 15), "1-es terem", 12, true));
            mozifilmek.Add(new mozi("fnaf2", new DateTime(2026, 12, 15), "2-es terem", 12, true));
            mozifilmek.Add(new mozi("fnaf3", new DateTime(2027, 12, 15), "3-es terem", 12, true));
            mozifilmek.Add(new mozi("fnaf4", new DateTime(2028, 12, 15), "4-es terem", 12, true));
            mozifilmek.Add(new mozi("fnaf5", new DateTime(2029, 12, 15), "5-es terem", 12, true));
            mozifilmek.Add(new mozi("fnaf6", new DateTime(2030, 12, 15), "6-es terem", 12, true));

        }

        private void adatokbetoltese(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = mozifilmek;
        }

        private void foglalas(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is mozi)
            {
                ((mozi)DataGrid.SelectedItem).szabadhelyek
                    = ((mozi)DataGrid.SelectedItem).szabadhelyek - 1;
                DataGrid.Items.Refresh();
            }
            if (szabadhelyek in mozi is null)
           


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}