using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Kadry


{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            var db = new MyDBContext(); 
       
            InitializeComponent();
            

            // ********************************************* Tabela z danymi pracowników ****************************************


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

                this.gridPracowniczy.ItemsSource = pracownik.ToList();

            }


        }

        // ****************************************** Wyczyść Pola z komórek text *************************************
        public void wyczyscDane()
        {
            txtName.Clear();
            txtDzial.Clear();
            txtWynagrodzenie.Clear();
            txtName_2.Clear();
            txtDzial_2.Clear();
            txtWynagrodzenie_2.Clear();
            textBoxInError.Clear();
        }
     

        // ***********************************************  Button lista pracowników ************************************************
        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyDBContext();

            this.gridPracowniczy.ItemsSource = db.Pracownicy.ToList();
           
        }



        // ************************************************ Dodaj Pracownika *************************************** 
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Pole nie Imię i Nazwisko nie może być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else if (txtDzial.Text == string.Empty)
            {
                MessageBox.Show("Pole nie Dział nie może być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (txtWynagrodzenie.Text == String.Empty)
            {
                MessageBox.Show("Pole nie Wynagrodzenie nie może być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (textBoxInError.Text == String.Empty)
            {
                MessageBox.Show("Pole Wiek w latach nie moze być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var db = new MyDBContext();
                    var pracownik = new Pracownicy()
                    {

                        ImieNazwisko = txtName.Text,
                        Dział = txtDzial.Text,
                        Wynagrodzenie = txtWynagrodzenie.Text
                    };
                    db.Pracownicy.Add(pracownik);
                    db.SaveChanges();
               
                Wczytaj_Click(sender,e);
            }

        }

     


        // ****************************************** Wczytaj do tabeli przycisk Lista Pracowników ************************************
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


        //************************************** Aktualizuj dane pracownika *****************************************************

        private void Aktualizuj_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyDBContext();
            // *************************************Walidacja pustych pól ************************************************************
            if (txtName_2.Text == string.Empty)
            {
                MessageBox.Show("Pole nie Imię i Nazwisko nie może być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else if (txtDzial_2.Text == string.Empty)
            {
                MessageBox.Show("Pole nie Dział nie może być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (txtWynagrodzenie_2.Text == String.Empty)
            {
                MessageBox.Show("Pole nie Wynagrodzenie nie może być puste", "Niepowodzenie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var x = from p in db.Pracownicy
                    where p.Id == this.updateID
                    select p;
                Pracownicy prac = x.SingleOrDefault();

                if (prac != null)
                {
                    prac.ImieNazwisko = this.txtName_2.Text;
                    prac.Dział = this.txtDzial_2.Text;
                    prac.Wynagrodzenie = this.txtWynagrodzenie_2.Text;
                }

                db.SaveChanges();

                Wczytaj_Click(sender, e);
            }
        }


        // ***************************************************** Walidacja usunięcia pracownika *************************************
        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyDBContext();

            MessageBoxResult messageBoxResult = MessageBox.Show("Czy jestes pewien, że chcesz usunąc pracownika ???",
                "Usunięto pracownika",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var x = from p in db.Pracownicy
                    where p.Id == this.updateID
                    select p;
                Pracownicy prac = x.SingleOrDefault();

                if (prac != null)
                {
                    db.Pracownicy.Remove(prac);
                    db.SaveChanges();
                    Wczytaj_Click(sender, e);
                }
            }

        }

        private void WalidacjaWynagrodzenia(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);


        }

        private void loadGrid()
        {

            var db = new MyDBContext();
            var query2 =
                from p in db.Pracownicy
                where p.ImieNazwisko == Podaj_ImieNazwisko.Text
                select new
                {
                    ImieNazwisko = p.ImieNazwisko,
                    Wydzial = p.Dział,
                    Wynagrodzenie = p.Wynagrodzenie
                };

            GridWynagrodzenie.ItemsSource = query2.ToList();


        }

        // *********************************************** Przycisk Wyczyść pola danych *****************************************************************
        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            wyczyscDane();

        }

        
        private void Pokaż_Click(object sender, RoutedEventArgs e)
        {
            loadGrid();

        }


        private void GridWynagrodzenie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Podaj_ImieNazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OknoListPrac_Click(object sender, RoutedEventArgs e)
        {
            Window1 oknoWindow1 = new Window1();
            oknoWindow1.Show();
        }
    }
}



