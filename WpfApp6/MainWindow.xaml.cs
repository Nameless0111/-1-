using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.LIBRARYY1DataSetTableAdapters;

namespace WpfApp6
{
 
    public partial class MainWindow : Window
    {
        ReadersTableAdapter reader = new ReadersTableAdapter();
        GenresTableAdapter genre = new GenresTableAdapter();
        LIBRARYY1Entities entity = new LIBRARYY1Entities();
        public MainWindow()
        {
            InitializeComponent();
            ReaderGen.ItemsSource = reader.GetData();
            genreCbx.ItemsSource = genre.GetData();
        }

        private void ReaderGen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = (ReaderGen.SelectedItem as DataRowView).Row;
            nameTbx.Text = data[2].ToString();
            genreCbx.SelectedValue = Convert.ToInt32(data[5]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }
    }
    public partial class Window1 : Window
    {

        LIBRARYY1Entities entity = new LIBRARYY1Entities();
        public Window1()
        {
            InitializeComponent();
            Gen.ItemsSource = entity.Genres.ToList();

        }
    }
}
