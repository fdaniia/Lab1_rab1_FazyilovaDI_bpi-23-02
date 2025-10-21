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
        private bool isDarkTheme = false;
        public MainWindow()
        {
            InitializeComponent();
            ApplyLightTheme();
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
        public Numbers AA (string q, TextBox textBox)
        {
            if (!proverka(textBox, q)) return null;
            int value = int.Parse(textBox.Text);
            if (numbers == null) numbers = new Numbers(0, 0 , 0 , 0);
            switch (q.ToLower())
            {
                case "a": numbers.A = value; break;
                case "b": numbers.B = value; break;
                case "c": numbers.C = value; break;
                case "d": numbers.D = value; break;
            }          
            return numbers;            
        }
        public Numbers Check(string q, TextBox textBox)
        {
            return AA(q, textBox);
        }
        public Numbers Num()
        {
            if (!proverka(aTextBox, "a")) return null;
            if (!proverka(bTextBox, "b")) return null;
            if (!proverka(cTextBox, "c")) return null;
            if (!proverka(dTextBox, "d")) return null;
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
            Numbers n = Num();
            if (n != null)
            {
                double mean = n.ArithmeticMean();
                meanTextBox.Text = mean.ToString();
            }
        }
        private void maxNumber_Click(object sender, RoutedEventArgs e)
        {
           Numbers n = Num();
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
        private void ThemeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            if (isDarkTheme) ApplyDarkTheme();
            else ApplyLightTheme(); 
        }
        private void ApplyLightTheme()
        {
            var uri = new Uri("LightTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            ThemeToggleButton.Content = "темная тема";
        }
        private void ApplyDarkTheme()
        {
            var uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            ThemeToggleButton.Content = "светлая тема";
        }
    }

}

