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
    /// Logika interakcji dla klasy SzczegolyWizyty.xaml
    /// </summary>
    public partial class SzczegolyWizyty : Window
    {
        public SzczegolyWizyty()
        {
            InitializeComponent();
        }

        private void Zamknij_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
