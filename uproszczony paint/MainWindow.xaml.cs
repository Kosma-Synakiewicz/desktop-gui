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

namespace desktop_gui_Paint_uproszczony
{
    public partial class MainWindow : Window
    {
        private bool czyRysuje = false;
        private Point punktStartowy;
        private Shape? aktualnyKsztalt;

        public MainWindow()
        {
            InitializeComponent();
        }

        private Brush PobierzWybranyKolor()
        {
            if (ComboKolor == null) return Brushes.Black;

            int indeks = ComboKolor.SelectedIndex;
            if (indeks == 1) return Brushes.Red;
            if (indeks == 2) return Brushes.Blue;
            if (indeks == 3) return Brushes.Green;

            return Brushes.Black;
        }

        private double PobierzWybranaGrubosc()
        {
            if (ComboGrubosc == null) return 3;

            int indeks = ComboGrubosc.SelectedIndex;
            if (indeks == 0) return 1;
            if (indeks == 2) return 5;
            if (indeks == 3) return 8;

            return 3;
        }

        private void ObszarRysowania_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                czyRysuje = true;
                punktStartowy = e.GetPosition(ObszarRysowania);

                Brush kolor = PobierzWybranyKolor();
                double grubosc = PobierzWybranaGrubosc();
                int typKsztaltu = ComboKsztalt.SelectedIndex;

                if (typKsztaltu == 0)
                {
                    aktualnyKsztalt = new Line
                    {
                        X1 = punktStartowy.X,
                        Y1 = punktStartowy.Y,
                        X2 = punktStartowy.X,
                        Y2 = punktStartowy.Y,
                        Stroke = kolor,
                        StrokeThickness = grubosc
                    };
                }
                else if (typKsztaltu == 1)
                {
                    aktualnyKsztalt = new Rectangle
                    {
                        Stroke = kolor,
                        StrokeThickness = grubosc
                    };
                    Canvas.SetLeft(aktualnyKsztalt, punktStartowy.X);
                    Canvas.SetTop(aktualnyKsztalt, punktStartowy.Y);
                }
                else if (typKsztaltu == 2)
                {
                    aktualnyKsztalt = new Ellipse
                    {
                        Stroke = kolor,
                        StrokeThickness = grubosc
                    };
                    Canvas.SetLeft(aktualnyKsztalt, punktStartowy.X);
                    Canvas.SetTop(aktualnyKsztalt, punktStartowy.Y);
                }

                if (aktualnyKsztalt != null)
                {
                    ObszarRysowania.Children.Add(aktualnyKsztalt);
                }
            }
        }

        private void ObszarRysowania_MouseMove(object sender, MouseEventArgs e)
        {
            if (czyRysuje && aktualnyKsztalt != null)
            {
                Point punktBiezacy = e.GetPosition(ObszarRysowania);

                if (aktualnyKsztalt is Line linia)
                {
                    linia.X2 = punktBiezacy.X;
                    linia.Y2 = punktBiezacy.Y;
                }
                else
                {
                    double x = Math.Min(punktStartowy.X, punktBiezacy.X);
                    double y = Math.Min(punktStartowy.Y, punktBiezacy.Y);
                    double szerokosc = Math.Abs(punktBiezacy.X - punktStartowy.X);
                    double wysokosc = Math.Abs(punktBiezacy.Y - punktStartowy.Y);

                    aktualnyKsztalt.Width = szerokosc;
                    aktualnyKsztalt.Height = wysokosc;

                    Canvas.SetLeft(aktualnyKsztalt, x);
                    Canvas.SetTop(aktualnyKsztalt, y);
                }
            }
        }

        private void ObszarRysowania_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                czyRysuje = false;
                aktualnyKsztalt = null;
            }
        }

        private void BtnWyczysc_Click(object sender, RoutedEventArgs e)
        {
            ObszarRysowania.Children.Clear();
        }
    }
}