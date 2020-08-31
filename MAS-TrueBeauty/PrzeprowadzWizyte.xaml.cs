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
    /// Logika interakcji dla klasy PrzeprowadzWizyte.xaml
    /// </summary>
    public partial class PrzeprowadzWizyte : Window
    {
        private ZabiegiDbService _service;
        public PrzeprowadzWizyte()
        {
            InitializeComponent();
            _service = new ZabiegiDbService();
            List<Lekarz> lekarzeList = _service.GetLekarze().ToList();
            for (int x = 0; x < lekarzeList.Count; x++)
            {
                lekarzInput.Items.Add(lekarzeList[x].OsobaId + " " + lekarzeList[x].imie + " " + lekarzeList[x].nazwisko);
            }

            List<Sala> saleList = _service.GetSale().ToList();
            for (int x = 0; x < saleList.Count; x++)
            {
                salaInput.Items.Add(saleList[x].SalaId);
            }
        }

        private void AddWizyta_Click(object sender, RoutedEventArgs e)
        {

            String[] godzRozp = godzRozpInput.Text.ToString().Split('.');
            String[] godzZak = godzZakInput.Text.ToString().Split('.');
            WizytaKonsultacyjna wizytaKonsultacyjna = new WizytaKonsultacyjna(dataInput.SelectedDate.Value, double.Parse(godzRozp[0]), double.Parse(godzZak[0]), opisProblemuInput.Text, decyzjaInput.Text);
            Klient klient = _service.GetKlient(int.Parse(klientIdInput.Text));
            _service.UpdateWizyteKlientNaTrue(klient);
            wizytaKonsultacyjna.setKlient(klient);
            String[] lekarzId = lekarzInput.SelectedItem.ToString().Split(' ');
            Lekarz lekarz = _service.GetLekarz(int.Parse(lekarzId[0]));
            wizytaKonsultacyjna.setLekarz(lekarz);
            Sala sala = _service.GetSala(int.Parse(salaInput.SelectedItem.ToString()));
            wizytaKonsultacyjna.setSala(sala);
            String[] sprz1 = sprzet1Input.SelectedItem.ToString().Split(' ');
            String[] sprz2 = sprzet1Input.SelectedItem.ToString().Split(' ');
            String[] sprz3 = sprzet1Input.SelectedItem.ToString().Split(' ');

            Sprzet sprzet1 = _service.GetSprzet(int.Parse(sprz1[0]));
            Sprzet sprzet2 = _service.GetSprzet(int.Parse(sprz2[0]));
            Sprzet sprzet3 = _service.GetSprzet(int.Parse(sprz1[0]));
            WizytaKonsultacyjnaSprzet wizytaKonsultacyjnaSprzet1 = new WizytaKonsultacyjnaSprzet(wizytaKonsultacyjna, sprzet1);
            WizytaKonsultacyjnaSprzet wizytaKonsultacyjnaSprzet2 = new WizytaKonsultacyjnaSprzet(wizytaKonsultacyjna, sprzet2);
            WizytaKonsultacyjnaSprzet wizytaKonsultacyjnaSprzet3 = new WizytaKonsultacyjnaSprzet(wizytaKonsultacyjna, sprzet3);

            wizytaKonsultacyjna.addWizytaKonsultacyjnaSprzet(wizytaKonsultacyjnaSprzet1);
            wizytaKonsultacyjna.addWizytaKonsultacyjnaSprzet(wizytaKonsultacyjnaSprzet2);
            wizytaKonsultacyjna.addWizytaKonsultacyjnaSprzet(wizytaKonsultacyjnaSprzet3);

            _service.AddWizytaKonsultacyjna(wizytaKonsultacyjna);

            Close();
        }

        private void SalaInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sprzet1Input.Items.Clear();
            sprzet2Input.Items.Clear();
            sprzet3Input.Items.Clear();

            List<Sprzet> sprzetList = _service.GetSprzetW(int.Parse(salaInput.SelectedItem.ToString())).ToList();
            for (int x = 0; x < sprzetList.Count; x++)
            {
                sprzet1Input.Items.Add(sprzetList[x].SprzetId + " " + sprzetList[x].opis);
                sprzet2Input.Items.Add(sprzetList[x].SprzetId + " " + sprzetList[x].opis);
                sprzet3Input.Items.Add(sprzetList[x].SprzetId + " " + sprzetList[x].opis);
            }
        }
    }
}
