using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;

namespace desktop_gui_Quiz_z_wyborami
{
    public class Pytanie
    {
        public string Tresc { get; set; } = string.Empty;
        public List<string> Opcje { get; set; } = new List<string>();
        public int PoprawnyIndeks { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Pytanie> bazaPytan = new List<Pytanie>();
        private int aktualnyIndeks = 0;
        private int punkty = 0;
        private int wybranyIndeksOdpowiedzi = -1;

        public MainWindow()
        {
            InitializeComponent();
            DeserializujPytaniaZTekstu();
        }

        private void DeserializujPytaniaZTekstu()
        {
            try
            {
                // Definiujemy poprawny, surowy tekst JSON bezpośrednio w pamięci programu
                string suroweDaneJson = @"
                [
                  {
                    ""Tresc"": ""Ktory jezyk jest domyslnym jezykiem dla WPF?"",
                    ""Opcje"": [""C++"", ""Java"", ""C#"", ""Python""],
                    ""PoprawnyIndeks"": 2
                  },
                  {
                    ""Tresc"": ""Ktory kontener WPF uklada elementy jeden pod drugim lub obok siebie?"",
                    ""Opcje"": [""Grid"", ""StackPanel"", ""Canvas"", ""WrapPanel""],
                    ""PoprawnyIndeks"": 1
                  },
                  {
                    ""Tresc"": ""Co oznacza skrot XAML?"",
                    ""Opcje"": [""Extensible Application Markup Language"", ""Extra Advanced Markup Language"", ""Example Application Model Language"", ""Extended Anchor Model Language""],
                    ""PoprawnyIndeks"": 0
                  }
                ]";

                // Wykonujemy pełną deserializację danych JSON na listę obiektów klasy Pytanie
                var opcjeKonfiguracji = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                bazaPytan = JsonSerializer.Deserialize<List<Pytanie>>(suroweDaneJson, opcjeKonfiguracji) ?? new List<Pytanie>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad deserializacji danych JSON: " + ex.Message, "Blad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRozpocznij_Click(object sender, RoutedEventArgs e)
        {
            if (bazaPytan.Count == 0)
            {
                MessageBox.Show("Brak pytan w bazie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            aktualnyIndeks = 0;
            punkty = 0;

            PanelStartowy.Visibility = Visibility.Collapsed;
            PanelWyniku.Visibility = Visibility.Collapsed;
            PanelGry.Visibility = Visibility.Visible;

            PokazPytanie();
        }

        private void PokazPytanie()
        {
            wybranyIndeksOdpowiedzi = -1;
            TxtPostep.Text = "Pytanie " + (aktualnyIndeks + 1) + " z " + bazaPytan.Count;
            PrezenterPytania.Content = bazaPytan[aktualnyIndeks];
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element != null && element.DataContext != null)
            {
                var pytanie = bazaPytan[aktualnyIndeks];
                string tekstOpcji = element.DataContext.ToString() ?? string.Empty;
                wybranyIndeksOdpowiedzi = pytanie.Opcje.IndexOf(tekstOpcji);
            }
        }

        private void BtnDalej_Click(object sender, RoutedEventArgs e)
        {
            if (wybranyIndeksOdpowiedzi == -1)
            {
                MessageBox.Show("Wybierz jedna z odpowiedzi przed przejsciem dalej.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (wybranyIndeksOdpowiedzi == bazaPytan[aktualnyIndeks].PoprawnyIndeks)
            {
                punkty++;
            }

            aktualnyIndeks++;

            if (aktualnyIndeks < bazaPytan.Count)
            {
                PokazPytanie();
            }
            else
            {
                PanelGry.Visibility = Visibility.Collapsed;
                PanelWyniku.Visibility = Visibility.Visible;
                TxtWynik.Text = "Koniec gry!\n\nTwoj laczny wynik to: " + punkty + " / " + bazaPytan.Count;
            }
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            PanelWyniku.Visibility = Visibility.Collapsed;
            PanelStartowy.Visibility = Visibility.Visible;
        }
    }
}
