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
using Microsoft.SqlServer.Server;


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
        private bool proverka(TextBox textBox, string ABCD)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"{ABCD} не может быть пустым");
                    return false;
                }
                if (textBox.Text.Trim() == "-")
                {
                    MessageBox.Show($"{ABCD} введите число, а не только знак");
                    return false;
                }
                int.Parse(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show($"{ABCD} некорретный ввод");
                return false;
            }
        } 
        public Numbers num ()
        {
            if (!Proverka(aTextBox, "a")) return null;
            if (!Proverka(bTextBox, "b")) return null;
            if (!Proverka(cTextBox, "c")) return null;
            if (!Proverka(dTextBox, "d")) return null;
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
        private void arithmeticMean_Click(object sender, RoutedEventArgs e)
        {
            Numbers n = num();
            if (n != null)
            {
                double mean = n.ArithmeticMean();
                meanTextBox.Text = mean.ToString("F2");
            }
        }
        private void maxNumber_Click(object sender, RoutedEventArgs e)
        {
           Numbers n = num();
            if (n != null)
            {
                int max = n.MaxNumber();
                maxTextBox.Text = max.ToString();
            }
         }       
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            if (e.Text == "-")
            {
                if (textBox.Text.Contains('-') || textBox.CaretIndex != 0)
                {
                    e.Handled = true;
                }
                return;
            }
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) )
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
    }

}

