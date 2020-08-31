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
    /// Logika interakcji dla klasy DodajLekarza.xaml
    /// </summary>
    public partial class DodajLekarza : Window
    {
        ZabiegiDbService _service;
        public DodajLekarza()
        {
            InitializeComponent();
            _service = new ZabiegiDbService();
        }

        private void AddLekarz_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = new Osoba(imieInput.Text, nazwiskoInput.Text, daneKontaktoweInput.Text, dataUrodzeniaInput.SelectedDate.Value, plecInput.Text, adresInput.Text);
            _service.AddOsoba(osoba);
            Lekarz lekarz = Lekarz.stworzLekarza(osoba, imieInput.Text, nazwiskoInput.Text, daneKontaktoweInput.Text, dataUrodzeniaInput.SelectedDate.Value, plecInput.Text, adresInput.Text, false,specjalizacjaInput.Text);
            _service.AddLekarz(lekarz);
            Close();
        }
    }
}
