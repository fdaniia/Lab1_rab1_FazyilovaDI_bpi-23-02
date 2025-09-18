using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Lab1_rab1_FazyilovaDI_bpi_23_02
{  
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Numbers numbers { get; set; }        
        public MainWindow()
        {
            InitializeComponent();
        }
        public Numbers num ()
        {
            if (string.IsNullOrWhiteSpace(aTextBox.Text) || string.IsNullOrWhiteSpace(bTextBox.Text) || string.IsNullOrWhiteSpace(cTextBox.Text) || string.IsNullOrWhiteSpace(dTextBox.Text))
            {
                MessageBox.Show("введите все числа");
                return null;
            }
            int a = int.Parse(aTextBox.Text);
            int b = int.Parse(bTextBox.Text);
            int c = int.Parse(cTextBox.Text);
            int d = int.Parse(dTextBox.Text);
            if (numbers == null) numbers = new Numbers(a, b, c, d);
            else
            {
                numbers.A = a;
                numbers.B = b;
                numbers.C = c;
                numbers.D = d;
            }
            return numbers;
        }
        private void ArithmeticMean_Click(object sender, RoutedEventArgs e)
        {
            Numbers n = num();
            if (n != null)
            {
                double mean = n.ArithmeticMean();
                meanTextBox.Text = mean.ToString("F2");
            }
        }
        private void MaxNumber_Click(object sender, RoutedEventArgs e)
        {
           Numbers n = num();
            if (n != null)
            {
                int max = n.MaxNumber();
                maxTextBox.Text = max.ToString();
            }
         }       
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) )
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
    }

}

