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

namespace WPFmozi
{
    
      public class mozi
    {
        public string cim { get; set; }
        public DateTime idopont { get; set; }
        public string terem { get; set; }
        public int szabadhelyek { get; set; }
        public bool _3D { get; set; }

        public mozi(string cim, DateTime idopont, string terem, int szabadhelyek, bool _3D)
        {
            this.cim = cim;
            this.idopont = idopont;
            this.terem = terem;
            this.szabadhelyek = szabadhelyek;
            this._3D = _3D;
        }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<mozi> mozifilmek { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            mozifilmek = new ObservableCollection<mozi>()
            {
                new mozi("Hogy lettem zsídó?", new DateTime(2025,12,15,18,0,0), "1-es terem", 12, true),
                new mozi("FNAF 2", new DateTime(2026,12,15,18,0,0), "2-es terem", 5, false),
                new mozi("NagyFiúk", new DateTime(2027,12,15,18,0,0), "3-as terem", 0, true),
                new mozi("GyilkosJárat", new DateTime(2028,12,15,18,0,0), "4-es terem", 20, false),
                new mozi("Gyűrűk Úra", new DateTime(2028,12,15,18,0,0), "5-es terem", 20, false),
                new mozi("VillámMekvin", new DateTime(2028,12,15,18,0,0), "6-es terem", 20, false),
            };

        }

       
        private void adatokbetoltese(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = mozifilmek;
        }

        
        public void foglalas(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is mozi m)
            {
                if (m.szabadhelyek > 0)
                {
                    m.szabadhelyek--;
                    DataGrid.Items.Refresh();
                }
                else
                    MessageBox.Show("Nincs több szabad hely!");
            }
        }
        private void csakVanHely(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource =
                new ObservableCollection<mozi>(mozifilmek.Where(x => x.szabadhelyek > 0));
        }
        private void csak3D(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource =
                new ObservableCollection<mozi>(mozifilmek.Where(x => x._3D));
        }
        private void legnepszerubb(object sender, RoutedEventArgs e)
        {
            var film = mozifilmek.OrderBy(x => x.szabadhelyek).First();
            MessageBox.Show($"Legnépszerűbb film:\n{film.cim}");
        }
        private void atlagSzabadHely(object sender, RoutedEventArgs e)
        {
            double atlag = mozifilmek.Average(x => x.szabadhelyek);
            MessageBox.Show($"Átlagos szabad hely: {atlag:F1}");
        }
        private void hozzaadas(object sender, RoutedEventArgs e)
        {
            try
            {
                mozifilmek.Add(new mozi(
                    txtCim.Text,
                    DateTime.Parse(txtIdopont.Text),
                    txtTerem.Text,
                    int.Parse(txtSzabad.Text),
                    chk3D.IsChecked == true
                ));

                DataGrid.ItemsSource = mozifilmek;
            }
            catch
            {
                MessageBox.Show("Hibás adat!");
            }
        }
    }
}