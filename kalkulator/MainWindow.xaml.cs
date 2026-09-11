using System;
using System.Windows;
using System.Windows.Controls;

namespace desktop_gui
{
    public partial class MainWindow : Window
    {
        private double pierwszaLiczba = 0;
        private string wybranyOperator = "";
        private bool czyCzyscicEkran = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Cyfra_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            string cyfra = przycisk.Content.ToString();

            if (TextBoxWynik.Text == "0" || czyCzyscicEkran)
            {
                TextBoxWynik.Text = cyfra;
                czyCzyscicEkran = false;
            }
            else
            {
                TextBoxWynik.Text += cyfra;
            }
        }

        private void Button_Operator_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            pierwszaLiczba = Convert.ToDouble(TextBoxWynik.Text);
            wybranyOperator = przycisk.Content.ToString();
            czyCzyscicEkran = true;
        }

        private void Button_Wynik_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(wybranyOperator))
            {
                return;
            }

            double drugaLiczba = Convert.ToDouble(TextBoxWynik.Text);
            double wynik = 0;

            if (wybranyOperator == "+")
            {
                wynik = pierwszaLiczba + drugaLiczba;
            }
            else if (wybranyOperator == "-")
            {
                wynik = pierwszaLiczba - drugaLiczba;
            }
            else if (wybranyOperator == "*")
            {
                wynik = pierwszaLiczba * drugaLiczba;
            }
            else if (wybranyOperator == "/")
            {
                if (drugaLiczba != 0)
                {
                    wynik = pierwszaLiczba / drugaLiczba;
                }
                else
                {
                    TextBoxWynik.Text = "Blad";
                    wybranyOperator = "";
                    czyCzyscicEkran = true;
                    return;
                }
            }

            TextBoxWynik.Text = wynik.ToString();
            wybranyOperator = "";
            czyCzyscicEkran = true;
        }

        private void Button_Czysc_Click(object sender, RoutedEventArgs e)
        {
            TextBoxWynik.Text = "0";
            pierwszaLiczba = 0;
            wybranyOperator = "";
            czyCzyscicEkran = false;
        }
    }
}
