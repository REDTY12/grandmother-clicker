using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading; 

namespace ClickerWPF
{
    public partial class MainWindow : Window
    {
        double num = 4;
        double price = 2;
        int upgrade = 0;
        double boost = 1;
        int Rebirth = 0;
        int aim_rebirth = 100000;

        DispatcherTimer timer = new DispatcherTimer();
        double passiveIncome = 0;
        double passivePrice = 50;

        public MainWindow()
        {
            InitializeComponent();
            label1.Text = num.ToString("F2");
            button2.Content = "Улучшение - " + price.ToString("F0");
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (passiveIncome > 0)
            {
                num += passiveIncome;
                label1.Text = num.ToString("F2");
            }
        }
        private void btnAutoClick_Click(object sender, RoutedEventArgs e)
        {
            if (num >= passivePrice)
            {
                num -= passivePrice;
                passiveIncome += 1;
                passivePrice *= 1.5;

                btnAutoClick.Content = $"Бабушка (+{passiveIncome}/сек) - {passivePrice:F0}";
                label1.Text = num.ToString("F2");
            }
            else
            {
                MessageBox.Show($"Нужно {passivePrice:F0} закаток для найма бабушки!");
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (upgrade == 0) num++;
            else num = num * boost;
            label1.Text = num.ToString("F2");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (num >= price)
            {
                num -= price;
                price *= 1.4;
                button2.Content = "Улучшение - " + price.ToString("F0");
                upgrade++;
                label1.Text = num.ToString("F2");
                boost *= 1.01;

                if (upgrade >= 15)
                {
                    button3.Visibility = Visibility.Visible;
                    button3.IsEnabled = true;
                    button2.IsEnabled = false;
                }
            }
            else MessageBox.Show("Недостаточно закаток!!!");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (num >= price)
            {
                num -= price;
                price *= 1.4;
                button3.Content = "Улучшение " + price.ToString("F2");

                upgrade++;
                label1.Text = num.ToString("F2");
                boost *= 1.1;
            }
            else
            {
                MessageBox.Show("Недостаточно закаток!!!");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (num >= aim_rebirth)
            {
                aim_rebirth = aim_rebirth * 10;
                Rebirth++;
                upgrade = 0;
                price = 2;
                num = 0;
                boost = 1.5;

                passiveIncome = 0;
                passivePrice = 50;
                btnAutoClick.Content = "Бабушка (Авто) - 50";
                label2.Text = "Rebirth: " + Rebirth.ToString();
                button2.IsEnabled = true;
                button3.Visibility = Visibility.Collapsed;
                button2.Content = "Улучшение - " + price.ToString("F0");
                label1.Text = "0,00";
            }
            else MessageBox.Show("Нужно "+aim_rebirth + " закаток");
        }

        private void label1_Click(object sender, MouseButtonEventArgs e) { }
    }
}