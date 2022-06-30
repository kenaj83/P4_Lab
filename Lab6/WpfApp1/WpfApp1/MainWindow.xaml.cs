using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _login = "Janek";
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Powieksz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kliknij_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text == _login)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Login Poprawny");
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Login Nieprawidłowy");
            }
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }
    }
}
