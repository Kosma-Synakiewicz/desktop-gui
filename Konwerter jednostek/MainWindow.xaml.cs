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

namespace desktop_gui_Konwerter_jednostek
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Przelicz()
        {
            if (TextBoxWejscie == null || TextBoxWyjscie == null || ComboBoxTryb == null)
            {
                return;
            }

            string tekst = TextBoxWejscie.Text.Trim();

            if (string.IsNullOrEmpty(tekst))
            {
                TextBoxWyjscie.Text = string.Empty;
                return;
            }

            tekst = tekst.Replace('.', ',');

            if (!double.TryParse(tekst, out double wartoscWejsciowa))
            {
                TextBoxWyjscie.Text = "Błędna liczba";
                return;
            }

            double wynik = 0;
            int indeks = ComboBoxTryb.SelectedIndex;

            if (indeks == 0)
            {
                wynik = wartoscWejsciowa * 0.621371;
            }
            else if (indeks == 1)
            {
                wynik = wartoscWejsciowa * 2.20462;
            }
            else if (indeks == 2)
            {
                wynik = (wartoscWejsciowa * 9 / 5) + 32;
            }

            TextBoxWyjscie.Text = Math.Round(wynik, 4).ToString();
        }

        private void TextBoxWejscie_TextChanged(object sender, TextChangedEventArgs e)
        {
            Przelicz();
        }

        private void ComboBoxTryb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LabelWejscie == null || LabelWyjscie == null || ComboBoxTryb == null)
            {
                return;
            }

            int indeks = ComboBoxTryb.SelectedIndex;

            if (indeks == 0)
            {
                LabelWejscie.Content = "Wartość (km):";
                LabelWyjscie.Content = "Wynik (mile):";
            }
            else if (indeks == 1)
            {
                LabelWejscie.Content = "Wartość (kg):";
                LabelWyjscie.Content = "Wynik (lb):";
            }
            else if (indeks == 2)
            {
                LabelWejscie.Content = "Wartość (°C):";
                LabelWyjscie.Content = "Wynik (°F):";
            }

            Przelicz();
        }
    }
}