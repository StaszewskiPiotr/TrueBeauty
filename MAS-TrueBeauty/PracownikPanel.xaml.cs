using MAS_TrueBeauty.DAL;
using MAS_TrueBeauty.Models;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MAS_TrueBeauty
{
    /// <summary>
    /// Logika interakcji dla klasy PracownikPanel.xaml
    /// </summary>
    public partial class PracownikPanel : Window
    {
        private ZabiegiDbService _service;

        public PracownikPanel()
        {
            InitializeComponent();
            _service = new ZabiegiDbService();
            KlienciDataGrid.ItemsSource = _service.GetKlienci();
            LekarzeDataGrid.ItemsSource = _service.GetLekarze();

        }

        private void DodajKlienta_Click(object sender, RoutedEventArgs e)
        {
            DodajKlienta dodajKlienta = new DodajKlienta();
            dodajKlienta.Show();
        }

        private void UsunKlienta_Click(object sender, RoutedEventArgs e)
        {
            if (KlienciDataGrid.SelectedValue != null)
            {
                Klient klient = (Klient)KlienciDataGrid.SelectedItem;
                _service.DeleteKlient(klient);
            }
            else
            {
                MessageBox.Show("Żaden klient nie został wybrany");
            }
        }

        private void DodajLekarza_Click(object sender, RoutedEventArgs e)
        {
            DodajLekarza dodajLekarza = new DodajLekarza();
            dodajLekarza.Show();
        }

        private void UsunLekarza_Click(object sender, RoutedEventArgs e)
        {
            if (LekarzeDataGrid.SelectedValue != null)
            {
                Lekarz lekarz = (Lekarz)LekarzeDataGrid.SelectedItem;
                _service.DeleteLekarz(lekarz);
            }
            else
            {
                MessageBox.Show("Żaden lekarz nie został wybrany");
            }
        }

        private void WylogujSie_Click(object sender, RoutedEventArgs e)
        {      
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void OdswierzKlientow_Click(object sender, RoutedEventArgs e)
        {
            KlienciDataGrid.ItemsSource = _service.GetKlienci();
        }

        private void OdswierzLekarzy_Click(object sender, RoutedEventArgs e)
        {
            LekarzeDataGrid.ItemsSource = _service.GetLekarze();
        }
    }
}
