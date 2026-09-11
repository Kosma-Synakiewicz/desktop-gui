using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace desktop_gui_Formularz_rejestracyjny_z_walidacją
{
    public partial class MainWindow : Window, INotifyPropertyChanged, IDataErrorInfo
    {
        private string _imie = string.Empty;
        private string _nazwisko = string.Empty;
        private string _email = string.Empty;
        private string _haslo = string.Empty;
        private string _potwierdzenieHasla = string.Empty;
        private bool _czyRegulaminZaakceptowany;

        public string Imie
        {
            get => _imie;
            set { _imie = value; OnPropertyChanged(); }
        }

        public string Nazwisko
        {
            get => _nazwisko;
            set { _nazwisko = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Haslo
        {
            get => _haslo;
            set { _haslo = value; OnPropertyChanged(); OnPropertyChanged(nameof(PotwierdzenieHasla)); }
        }

        public string PotwierdzenieHasla
        {
            get => _potwierdzenieHasla;
            set { _potwierdzenieHasla = value; OnPropertyChanged(); }
        }

        public bool CzyRegulaminZaakceptowany
        {
            get => _czyRegulaminZaakceptowany;
            set { _czyRegulaminZaakceptowany = value; OnPropertyChanged(); }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string wynikBledu = string.Empty;

                if (columnName == nameof(Imie))
                {
                    if (string.IsNullOrWhiteSpace(Imie))
                        wynikBledu = "Imię nie może być puste.";
                }
                else if (columnName == nameof(Nazwisko))
                {
                    if (string.IsNullOrWhiteSpace(Nazwisko))
                        wynikBledu = "Nazwisko nie może być puste.";
                }
                else if (columnName == nameof(Email))
                {
                    if (string.IsNullOrWhiteSpace(Email))
                        wynikBledu = "Adres e-mail nie może być pusty.";
                    else if (!Email.Contains("@") || !Email.Contains("."))
                        wynikBledu = "Niepoprawny format adresu e-mail.";
                }
                else if (columnName == nameof(Haslo))
                {
                    if (string.IsNullOrWhiteSpace(Haslo))
                        wynikBledu = "Hasło nie może być puste.";
                    else if (Haslo.Length < 6)
                        wynikBledu = "Hasło musi mieć co najmniej 6 znaków.";
                }
                else if (columnName == nameof(PotwierdzenieHasla))
                {
                    if (PotwierdzenieHasla != Haslo)
                        wynikBledu = "Hasła muszą być identyczne.";
                }

                return wynikBledu;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Zarejestruj_Click(object sender, RoutedEventArgs e)
        {
            bool saBledy = !string.IsNullOrEmpty(this[nameof(Imie)]) ||
                           !string.IsNullOrEmpty(this[nameof(Nazwisko)]) ||
                           !string.IsNullOrEmpty(this[nameof(Email)]) ||
                           !string.IsNullOrEmpty(this[nameof(Haslo)]) ||
                           !string.IsNullOrEmpty(this[nameof(PotwierdzenieHasla)]);

            if (saBledy)
            {
                MessageBox.Show("Popraw błędy w formularzu przed rejestracją.", "Błąd walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!CzyRegulaminZaakceptowany)
            {
                MessageBox.Show("Musisz zaakceptować regulamin.", "Błąd walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Rejestracja przebiegła pomyślnie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}