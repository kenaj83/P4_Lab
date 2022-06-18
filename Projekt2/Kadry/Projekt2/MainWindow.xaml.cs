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

namespace Projekt2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PracownicyEntities db = new PracownicyEntities();
            var pracownik = from p in db.Pracownicies
                            select new
                            {
                                FullName = p.ImieNazwisko,
                                Department = p.Dział,
                                Salary = p.Wynagrodzenie
                            };

            foreach (var item in pracownik)
            {
                Console.WriteLine(item.FullName);
                Console.WriteLine(item.Department);
                Console.WriteLine(item.Salary);
            }
            this.gridPracowniczy.ItemsSource = pracownik.ToList();

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            PracownicyEntities db = new PracownicyEntities();

            Pracownicy pracownik = new Pracownicy()
            {
                ImieNazwisko = txtName.Text,
                Dział = txtDzial.Text,
                Wynagrodzenie = txtWynagrodzenie.Text
            };

            db.Pracownicies.Add(pracownik);
            db.SaveChanges();

        }

        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {

            PracownicyEntities db = new PracownicyEntities();

            this.gridPracowniczy.ItemsSource = db.Pracownicies.ToList();

        }

        int updateID = 0;
        private void gridPracowniczy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridPracowniczy.SelectedIndex >= 0)
            {
                if (this.gridPracowniczy.SelectedItems.Count >= 0)
                {
                    if (this.gridPracowniczy.SelectedItems[0].GetType() == typeof(Pracownicy))
                    {
                        Pracownicy p = (Pracownicy)this.gridPracowniczy.SelectedItems[0];
                        this.txtName_2.Text = p.ImieNazwisko;
                        this.txtDzial_2.Text = p.Dział;
                        this.txtWynagrodzenie_2.Text = p.Wynagrodzenie;
                        this.updateID = p.Id;
                    }
                }
            }

        }

        private void Aktualizuj_Click(object sender, RoutedEventArgs e)
        {
            PracownicyEntities db = new PracownicyEntities();

            var x = from p in db.Pracownicies
                    where p.Id == this.updateID
                    select p;
            Pracownicy prac = x.SingleOrDefault();

            if(prac != null)
            {
                prac.ImieNazwisko = this.txtName_2.Text;
                prac.Dział=this.txtDzial_2.Text;
                prac.Wynagrodzenie = this.txtWynagrodzenie_2.Text;
            }

            db.SaveChanges();

        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            PracownicyEntities db = new PracownicyEntities();

            MessageBoxResult messageBoxResult = MessageBox.Show("Czy jestes pewien, że chcesz usunąc pracownika ???", "Usunięto pracownika",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var x = from p in db.Pracownicies
                        where p.Id == this.updateID
                        select p;
                Pracownicy prac = x.SingleOrDefault();

                if (prac != null)
                {
                    db.Pracownicies.Remove(prac);
                    db.SaveChanges();
                }
            }
        }
    }
}
