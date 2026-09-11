using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace desktop_gui_mini_notepad
{
    public partial class MainWindow : Window
    {
        private string aktualnaSciezkaPliku = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            AktualizujTytulOkna();
        }

        private void AktualizujTytulOkna()
        {
            if (string.IsNullOrEmpty(aktualnaSciezkaPliku))
            {
                this.Title = "Bez tytułu — Mini Notepad";
            }
            else
            {
                this.Title = Path.GetFileName(aktualnaSciezkaPliku) + " — Mini Notepad";
            }
        }

        private void Menu_Nowy_Click(object sender, RoutedEventArgs e)
        {
            TextBoxNotatnika.Clear();
            aktualnaSciezkaPliku = string.Empty;
            AktualizujTytulOkna();
        }

        private void Menu_Otworz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    TextBoxNotatnika.Text = File.ReadAllText(openFileDialog.FileName);
                    aktualnaSciezkaPliku = openFileDialog.FileName;
                    AktualizujTytulOkna();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można otworzyć pliku: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Menu_Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(aktualnaSciezkaPliku))
            {
                WykonajZapiszJako();
            }
            else
            {
                WykonajZapis(aktualnaSciezkaPliku);
            }
        }

        private void Menu_ZapiszJako_Click(object sender, RoutedEventArgs e)
        {
            WykonajZapiszJako();
        }

        private void WykonajZapiszJako()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                WykonajZapis(saveFileDialog.FileName);
            }
        }

        private void WykonajZapis(string sciezka)
        {
            try
            {
                File.WriteAllText(sciezka, TextBoxNotatnika.Text);
                aktualnaSciezkaPliku = sciezka;
                AktualizujTytulOkna();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można zapisać pliku: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Menu_Zamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
