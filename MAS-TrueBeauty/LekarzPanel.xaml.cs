using MAS_TrueBeauty.DAL;
using MAS_TrueBeauty.Models;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace MAS_TrueBeauty
{
    /// <summary>
    /// Logika interakcji dla klasy LekarzPanel.xaml
    /// </summary>
    public partial class LekarzPanel : Window
    {
        ZabiegiDbService _service;
        public LekarzPanel()
        {
            InitializeComponent();
            _service = new ZabiegiDbService();
            KlienciOczekujacyDataGrid.ItemsSource = _service.GetKlienciOczekujacy();
            KlienciZrealizowaniDataGrid.ItemsSource = _service.GetKlienciZrealizowani();
        }

        private void PrzeprowadzWizyte_Click(object sender, RoutedEventArgs e)
        {

            if (KlienciOczekujacyDataGrid.SelectedValue != null) {
                PrzeprowadzWizyte przeprowadzWizyte = new PrzeprowadzWizyte();

                Klient klient = (Klient)KlienciOczekujacyDataGrid.SelectedItem;

                przeprowadzWizyte.klientIdInput.Text = _service.GetKlient(klient.OsobaId).OsobaId.ToString();
                przeprowadzWizyte.Show();
            }
            else
            {
                MessageBox.Show("Żaden klient nie został wybrany.");
            }
        }

        private void SzczegolyWizyty_Click(object sender, RoutedEventArgs e)
        {
            if (KlienciZrealizowaniDataGrid.SelectedValue != null)
            {
                SzczegolyWizyty szczegolyWizyty = new SzczegolyWizyty();

                string[] dane = KlienciZrealizowaniDataGrid.SelectedItem.ToString().Split(' ');
                string[] id1 = dane[3].Split(',');
                int id2 = int.Parse(id1[0]);

                WizytaKonsultacyjna wizytaKonsultacyjna = _service.GetWizytaKonsultacyjna(id2);
                //IEnumerable<WizytaKonsultacyjnaSprzet> wizytaKonsultacyjnaSprzetLista = _service.GetSprzetWizyty(wizytaKonsultacyjna.WizytaKonsultacyjnaId);

                szczegolyWizyty.wizytaIdInput.Text = wizytaKonsultacyjna.WizytaKonsultacyjnaId.ToString();
                szczegolyWizyty.lekarzInput.Content = _service.GetLekarz(wizytaKonsultacyjna.lekarz.OsobaId).OsobaId + " " + _service.GetLekarz(wizytaKonsultacyjna.lekarz.OsobaId).imie + " " + _service.GetLekarz(wizytaKonsultacyjna.lekarz.OsobaId).nazwisko;
                szczegolyWizyty.salaInput.Content = _service.GetSala(wizytaKonsultacyjna.sala.SalaId).SalaId;
                szczegolyWizyty.godzRozpInput.Content = wizytaKonsultacyjna.godzinaPrzyjecia.ToString() + ".00";
                szczegolyWizyty.godzZakInput.Content = wizytaKonsultacyjna.godzinaZakonczenia.ToString() + ".00";
                szczegolyWizyty.dataInput.SelectedDate = wizytaKonsultacyjna.data;
                //MessageBox.Show("",_service.GetSprzetWizyty(1).First().ToString());
               // szczegolyWizyty.sprzet1Input.Content = _service.GetSprzet(int.Parse(_service.GetSprzetWizyty(wizytaKonsultacyjna.WizytaKonsultacyjnaId).ElementAt(0).ToString())).opis;
               // szczegolyWizyty.sprzet2Input.Content = _service.GetSprzet(int.Parse(_service.GetSprzetWizyty(wizytaKonsultacyjna.WizytaKonsultacyjnaId).ElementAt(1).ToString())).opis;
               // szczegolyWizyty.sprzet3Input.Content = _service.GetSprzet(int.Parse(_service.GetSprzetWizyty(wizytaKonsultacyjna.WizytaKonsultacyjnaId).ElementAt(2).ToString())).opis;
                szczegolyWizyty.opisProblemuInput.Text = wizytaKonsultacyjna.opisProblemu;
                szczegolyWizyty.decyzjaInput.Content = wizytaKonsultacyjna.decyzja;
                szczegolyWizyty.Show();
            }
            else
            {
                MessageBox.Show("Żaden klient nie został wybrany.");
            }

        }

        private void OdswierzKlientowOczekujacych_Click(object sender, RoutedEventArgs e)
        {
            KlienciOczekujacyDataGrid.ItemsSource = _service.GetKlienciOczekujacy();
        }

        private void OdswierzKlientowZrealizowanych_Click(object sender, RoutedEventArgs e)
        {
            KlienciZrealizowaniDataGrid.ItemsSource = _service.GetKlienciZrealizowani();
        }

        private void WylogujSie_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void UsunKlientaOczekujacego_Click(object sender, RoutedEventArgs e)
        {
            if (KlienciOczekujacyDataGrid.SelectedValue != null)
            {
                Klient klient = (Klient)KlienciOczekujacyDataGrid.SelectedItem;
                _service.DeleteKlient(klient);
            }
            else
            {
                MessageBox.Show("Żaden klient nie został wybrany");
            }
        }
    }
}
