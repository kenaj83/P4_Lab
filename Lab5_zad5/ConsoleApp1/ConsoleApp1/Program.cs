using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApp1;

var context = new MyDBContext();

context.Database.EnsureCreated();

//petla dodawania 3 pozycji ksiazki do autora

//for (int i = 0; i < 15; i++)
//{
//    // dodanie autora 
//    var autor = new Autor()
//    {
//        Imie = "Jan" + i,
//        Nazwisko = "Głuch" + i
//    };

//    //dodanie ksiazki 1 do autora
//    autor.SpisKsiazek.Add(new Ksiazka()
//    {
//        Tytul = "Tytul" + i,
//        RokWydania = 2000,

//    });
//    //dodanie ksiazki 2 do autora
//    autor.SpisKsiazek.Add(new Ksiazka()
//    {
//        Tytul = "Tytul 2" + i,
//        RokWydania = 1950,

//    });
//    //dodanie ksiazki 3 do autora

//    autor.SpisKsiazek.Add(new Ksiazka()
//    {
//        Tytul = "Tytul 3" + i,
//        RokWydania = 1983,

//    });

//    context.Autor.Add(autor);
//}

//context.SaveChanges();

int wybór = 0;
while (wybór != 4)
{
    Console.WriteLine();
    Console.WriteLine("***********************************************");
    Console.WriteLine("1. Znajdź nazwisko autora");
    Console.WriteLine("2. Znajdź imię autora");
    Console.WriteLine("3. Znajdź tytuł ksiazki");
    Console.WriteLine("4. Koniec");
    Console.WriteLine("***********************************************");
    Console.WriteLine();

    Console.Write($"Wybierz co chcesz zrobić: ");
    wybór = Int32.Parse(Console.ReadLine());
    Console.WriteLine();
    

    switch (wybór)
    {
        case 1:

            Console.Write($"Podaj nazwisko autora: ");
            string nazwisko = Console.ReadLine();

            var query = context.Autor
                                .Where(n => n.Nazwisko == nazwisko)
                                .Include(s => s.SpisKsiazek)
                                .ToList();
            Console.WriteLine();
            foreach (var item in query)
            {
                Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko} ");

                foreach (var itemKsiazki in item.SpisKsiazek)
                {
                    Console.WriteLine($"\t Tytuł: {itemKsiazki.Tytul}, Rok wydania: {itemKsiazki.RokWydania}");
                }
            }
            break;

        case 2:
            {
                Console.Write($"Podaj imię autora: ");
              

                string imię = Console.ReadLine();

                var query2 = context.Autor
                                    .Where(i => i.Imie == imię)
                                    .Include(s => s.SpisKsiazek)
                                    .ToList();

                Console.WriteLine();
                foreach (var item in query2)
                {
                    Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko} ");

                    foreach (var itemKsiazki in item.SpisKsiazek)
                    {
                        Console.WriteLine($"\t Tytuł: {itemKsiazki.Tytul}, Rok wydania: {itemKsiazki.RokWydania}");
                    }
                }
                break;
            }
            case 3:
            {

                Console.Write($"Podaj tytuł książki: ");
                string tytul = Console.ReadLine();
                Console.WriteLine();

                var query3 = context.Ksiazka
                                    .Where(t => t.Tytul == tytul)
                                    .Include(a => a.Autor)
                                    .ToList();

                foreach (var itemKsiazki in query3)
                {
                    Console.WriteLine($"Tytuł: {itemKsiazki.Tytul}, Rok wydania: {itemKsiazki.RokWydania}, Imie autora: {itemKsiazki.Autor.Imie}, Nazwisko autora: {itemKsiazki.Autor.Nazwisko}");
                }

                break;
            }
        case 4:
            {
                
                Console.WriteLine("Koniec");
                Console.WriteLine();

                break;
            }

        default:
            Console.WriteLine($"Nie ma takiego numeru");
            break;
    }
}

    //if (wybór == 1)
    //{
    //    Console.WriteLine($"Podaj nazwisko autora");

    //    string nazwisko = Console.ReadLine();

    //    var query = context.Autor
    //                        .Where(n => n.Nazwisko == nazwisko)
    //                        .Include(s => s.SpisKsiazek)
    //                        .ToList();

    //    foreach (var item in query)
    //    {
    //        Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko} ");

    //        foreach (var itemKsiazki in item.SpisKsiazek)
    //        {
    //            Console.WriteLine($"\t Tytuł: {itemKsiazki.Tytul}, Rok wydania: {itemKsiazki.RokWydania}");
    //        }
    //    }
    //}
    //if (wybór == 2)
    //{
    //    Console.WriteLine($"Podaj imię autora");

    //    string imię = Console.ReadLine();

    //    var query = context.Autor
    //                        .Where(i => i.Imie == imię)
    //                        .Include(s => s.SpisKsiazek)
    //                        .ToList();

    //    foreach (var item in query)
    //    {
    //        Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko} ");

    //        foreach (var itemKsiazki in item.SpisKsiazek)
    //        {
    //            Console.WriteLine($"\t Tytuł: {itemKsiazki.Tytul}, Rok wydania: {itemKsiazki.RokWydania}");
    //        }
    //    }
    //}
    //else if (wybór == 3)
    //{
    //    Console.WriteLine($"Podaj tytuł książki");
    //    string tytul = Console.ReadLine();

    //    var query = context.Ksiazka
    //                        .Where(t => t.Tytul == tytul)
    //                        .Include(a => a.Autor)
    //                        .ToList();

    //    foreach (var itemKsiazki in query)
    //    {
    //        Console.WriteLine($"Tytuł: {itemKsiazki.Tytul}, Rok wydania: {itemKsiazki.RokWydania}, Imie autora: {itemKsiazki.Autor.Imie}, Nazwisko autora: {itemKsiazki.Autor.Nazwisko}");
    //    }

    //}
    //else if (wybór == 4)
    //{
    //    Console.WriteLine("Koniec");

    //}
    //else
    //{
    //    Console.WriteLine("Nie ma takiego numeru");
    //}



