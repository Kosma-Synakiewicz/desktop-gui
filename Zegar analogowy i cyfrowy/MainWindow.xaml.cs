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
using System.Windows.Threading;

namespace desktop_gui_zegar_analogowy_i_cyfrowy
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            UruchomZegar();
        }

        private void UruchomZegar()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            OdswiezCzas();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            OdswiezCzas();
        }

        private void OdswiezCzas()
        {
            DateTime teraz = DateTime.Now;

            TextBlockCyfrowy.Text = teraz.ToString("HH:mm:ss");
            TextBlockData.Text = teraz.ToString("dd MMMM yyyy");

            double sekundyAngle = teraz.Second * 6;
            double minutyAngle = (teraz.Minute * 6) + (teraz.Second * 0.1);
            double godzinyAngle = (teraz.Hour % 12 * 30) + (teraz.Minute * 0.5);

            ObrotSekundy.Angle = sekundyAngle;
            ObrotMinuty.Angle = minutyAngle;
            ObrotGodziny.Angle = godzinyAngle;
        }
    }
}