using System.Collections.ObjectModel;
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

namespace desktop_gui_lista_zadan
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> ListaZadan { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListaZadan = new ObservableCollection<string>();
            ListBoxZadania.ItemsSource = ListaZadan;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tekstZadania = TextBoxNoweZadanie.Text.Trim();

            if (!string.IsNullOrEmpty(tekstZadania))
            {
                ListaZadan.Add(tekstZadania);
                TextBoxNoweZadanie.Clear();
                TextBoxNoweZadanie.Focus();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string zaznaczone = ListBoxZadania.SelectedItem as string;

            if (zaznaczone != null)
            {
                ListaZadan.Remove(zaznaczone);
            }
        }
    }
}