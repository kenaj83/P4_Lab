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
using System.Windows.Shapes;

namespace Kadry
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            var db = new MyDBContext();
            InitializeComponent();




            if (true)
            {
                var pracownik = from p in db.Pracownicy
                    select new
                    {
                        ImieNazwisko = p.ImieNazwisko,
                        Wydzial = p.Dział,
                        Wynagrodzenie = p.Wynagrodzenie
                    };

                foreach (var item in pracownik)
                {
                    Console.WriteLine(item.ImieNazwisko);
                    Console.WriteLine(item.Wydzial);
                    Console.WriteLine(item.Wynagrodzenie);
                }

                this.ListPrac.ItemsSource = pracownik.ToList();

            }
        }


        private void GridListPrac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
