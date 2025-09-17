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

        private void ArithmeticMean_Click(object sender, RoutedEventArgs e)
        {
           
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

            double mean = numbers.ArithmeticMean();
                meanTextBox.Text = mean.ToString("F2");           
        }
        private void MaxNumber_Click(object sender, RoutedEventArgs e)
        {

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
                    numbers.D= d;
                } 
                int max = numbers.MaxNumber();
                maxTextBox.Text = max.ToString();
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

