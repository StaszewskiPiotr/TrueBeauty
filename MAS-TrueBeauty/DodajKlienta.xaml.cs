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

namespace MAS_TrueBeauty
{
    /// <summary>
    /// Logika interakcji dla klasy DodajKlienta.xaml
    /// </summary>
    public partial class DodajKlienta : Window
    {
        private ZabiegiDbService _service;
        public DodajKlienta()
        {
            InitializeComponent();
            _service = new ZabiegiDbService();
            List<Lekarz> lekarzeList = _service.GetLekarze().ToList();
            for (int x = 0; x < lekarzeList.Count; x++)
            {
                lekarzInput.Items.Add(lekarzeList[x].OsobaId + " " + lekarzeList[x].imie + " " + lekarzeList[x].nazwisko);
            }
        }

        private void CheckJestLekarzem_Click(object sender, RoutedEventArgs e)
        {
            if((bool)checkJestLekarzem.IsChecked == true)
            {
                lekarzInput.IsEnabled = true;
                imieInput.IsEnabled = false;
                nazwiskoInput.IsEnabled = false;
                daneKontaktoweInput.IsEnabled = false;
                dataUrodzeniaInput.IsEnabled = false;
                plecInput.IsEnabled = false;
                adresInput.IsEnabled = false;
            }
            else
            {
                lekarzInput.IsEnabled = false;
                imieInput.IsEnabled = true;
                nazwiskoInput.IsEnabled = true;
                daneKontaktoweInput.IsEnabled = true;
                dataUrodzeniaInput.IsEnabled = true;
                plecInput.IsEnabled = true;
                adresInput.IsEnabled = true;
            }
        }

        private void AddKlient_Click(object sender, RoutedEventArgs e)
        {

            if (!checkJestLekarzem.IsChecked.Value)
            {
                Osoba osoba = new Osoba(imieInput.Text, nazwiskoInput.Text, daneKontaktoweInput.Text, dataUrodzeniaInput.SelectedDate.Value, plecInput.Text, adresInput.Text);
                _service.AddOsoba(osoba);
                Klient klient = Klient.stworzKlienta(osoba, imieInput.Text, nazwiskoInput.Text, daneKontaktoweInput.Text, dataUrodzeniaInput.SelectedDate.Value, plecInput.Text, adresInput.Text, false,(bool)pierwszyZabiegCheck.IsChecked);
                _service.AddKlient(klient);
            }
            else
            {
                string osoba = lekarzInput.Text;
                string[] dane = osoba.Split(' ');
                int id = int.Parse(dane[0]);

                Osoba osoba2 = _service.GetOsoba(id);
                Klient klient2 = Klient.stworzKlienta(osoba2, osoba2.imie, osoba2.nazwisko, osoba2.daneKontaktowe, osoba2.dataUrodzenia, osoba2.plec, osoba2.adresZamieszkania, false,(bool)pierwszyZabiegCheck.IsChecked);
                _service.AddKlient(klient2);
            }
            
            Close();
        }
    }
}
