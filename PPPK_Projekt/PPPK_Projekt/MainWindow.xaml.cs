using System;
using System.Collections.Generic;
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

namespace PPPK_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_vozaci_Click(object sender, RoutedEventArgs e)
        {
            Vozaci vozaci = new Vozaci();
            vozaci.Show();
        }

        private void btn_vozila_Click(object sender, RoutedEventArgs e)
        {
            Vozila vozila = new Vozila();
            vozila.Show();
        }

        private void btn_putniNalozi_Click(object sender, RoutedEventArgs e)
        {
            PutniNalozi putniNalozi = new PutniNalozi();
            putniNalozi.Show();
        }
    }
}
