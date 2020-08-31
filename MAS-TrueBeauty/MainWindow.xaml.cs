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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAS_TrueBeauty
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ZabiegiDbService _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new ZabiegiDbService();
        }

        private void Dzialaj_Click(object sender, RoutedEventArgs e)
        {
            ////Osoba osoba, string imie, string nazwisko, string daneKontaktowe, DateTime dataUrodzenia, string plec, string adresZamieszkania, Boolean pierwszaOperacjaPlastyczna
            //DateTime aDate = DateTime.Now;
            //var osoba = new Osoba(1, "Piotr", "Staszewski", "1234", aDate, "Mężczyzna", "dffv");
            //Klient klient = Klient.stworzKlienta(osoba, 1, "Piotr", "Staszewski", "1234", aDate, "Mężczyzna", "dffv", false);

            //_service.AddKlient(klient);

            //MessageBox.Show("Udało się");
        }

        private void Pracownik_Click(object sender, RoutedEventArgs e)
        {
            PracownikPanel pracownikPanel = new PracownikPanel();
            pracownikPanel.Show();
            Close();
        }

        private void Lekarz_Click(object sender, RoutedEventArgs e)
        {
            LekarzPanel lekarzPanel = new LekarzPanel();
            lekarzPanel.Show();
            Close();
        }
    }
}
