using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
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

namespace desktop_gui_galeria_obrazow
{
    public class ElementGalerii
    {
        public string Sciezka { get; set; } = string.Empty;
        public string NazwaPliku { get; set; } = string.Empty;
    }

    public partial class MainWindow : Window
    {
        private ObservableCollection<ElementGalerii> listaZdjec;

        public MainWindow()
        {
            InitializeComponent();
            listaZdjec = new ObservableCollection<ElementGalerii>();
            ListBoxMiniaturki.ItemsSource = listaZdjec;
        }

        private void ButtonWybierzFolder_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = "Wybierz folder zawierający obrazy";

            if (openFolderDialog.ShowDialog() == true)
            {
                listaZdjec.Clear();
                ImageDuzyPodglad.Source = null;
                TextBlockInformacja.Visibility = Visibility.Visible;

                string wybranyFolder = openFolderDialog.FolderName;
                string[] rozszerzenia = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" };

                try
                {
                    foreach (string rozszerzenie in rozszerzenia)
                    {
                        string[] pliki = Directory.GetFiles(wybranyFolder, rozszerzenie);
                        foreach (string plik in pliki)
                        {
                            listaZdjec.Add(new ElementGalerii
                            {
                                Sciezka = plik,
                                NazwaPliku = System.IO.Path.GetFileName(plik)
                            });
                        }
                    }

                    if (listaZdjec.Count == 0)
                    {
                        MessageBox.Show("W wybranym folderze nie znaleziono żadnych plików graficznych.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można odczytać zawartości folderu: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ListBoxMiniaturki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ElementGalerii? zaznaczony = ListBoxMiniaturki.SelectedItem as ElementGalerii;

            if (zaznaczony != null && File.Exists(zaznaczony.Sciezka))
            {
                try
                {
                    BitmapImage bitmapa = new BitmapImage();
                    bitmapa.BeginInit();
                    bitmapa.UriSource = new Uri(zaznaczony.Sciezka);
                    bitmapa.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapa.EndInit();

                    ImageDuzyPodglad.Source = bitmapa;
                    TextBlockInformacja.Visibility = Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można załadować podglądu obrazu: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}