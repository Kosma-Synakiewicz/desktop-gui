using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace desktop_gui_Baza_kontaktów_z_bazą_danych
{
    public class ObiektKontakt
    {
        public string Imie { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public partial class MainWindow : Window
    {
        private ObservableCollection<ObiektKontakt> listaKontakty;

        public MainWindow()
        {
            InitializeComponent();
            listaKontakty = new ObservableCollection<ObiektKontakt>();
            GridKontakty.ItemsSource = listaKontakty;
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtImie.Text))
            {
                MessageBox.Show("Imię nie może być puste.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            listaKontakty.Add(new ObiektKontakt
            {
                Imie = TxtImie.Text.Trim(),
                Telefon = TxtTelefon.Text.Trim(),
                Email = TxtEmail.Text.Trim()
            });

            WyczyscPola();
        }

        private void BtnEdytuj_Click(object sender, RoutedEventArgs e)
        {
            var zaznaczony = GridKontakty.SelectedItem as ObiektKontakt;
            if (zaznaczony != null)
            {
                if (string.IsNullOrWhiteSpace(TxtImie.Text))
                {
                    MessageBox.Show("Imię nie może być puste.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                zaznaczony.Imie = TxtImie.Text.Trim();
                zaznaczony.Telefon = TxtTelefon.Text.Trim();
                zaznaczony.Email = TxtEmail.Text.Trim();

                GridKontakty.Items.Refresh();
                WyczyscPola();
            }
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            var zaznaczony = GridKontakty.SelectedItem as ObiektKontakt;
            if (zaznaczony != null)
            {
                listaKontakty.Remove(zaznaczony);
                WyczyscPola();
            }
        }

        private void GridKontakty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var zaznaczony = GridKontakty.SelectedItem as ObiektKontakt;
            if (zaznaczony != null)
            {
                TxtImie.Text = zaznaczony.Imie;
                TxtTelefon.Text = zaznaczony.Telefon;
                TxtEmail.Text = zaznaczony.Email;
            }
        }

        private void WyczyscPola()
        {
            TxtImie.Clear();
            TxtTelefon.Clear();
            TxtEmail.Clear();
            GridKontakty.SelectedItem = null;
        }
    }
}
