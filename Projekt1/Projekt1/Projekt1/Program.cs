using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Projekt1;

var db = new MyDBContext();

db.Database.EnsureCreated();

//***************** Tworzenie danych do tabel ********************************//

//Osoba osoba = new Osoba()
//{
//    Imie = "Jan",
//    Nazwisko = "Głuch"
//};

//db.Osoba.Add(osoba);

//Osoba osoba = new Osoba()
//{
//    Imie = "Marcin",
//    Nazwisko = "Kowalski"
//};

//db.Osoba.Add(osoba);

//Osoba osoba = new Osoba()
//{
//    Imie = "Kamil",
//    Nazwisko = "Terlich"
//};

//db.Osoba.Add(osoba);
//db.SaveChanges();

//db.Osoba.Add(osoba);

//Dostawca dostawca = new Dostawca()
//{
//    NazwaFirmy = "Sony Corporation"
//};
//db.Dostawca.Add(dostawca);

//Dostawca dostawca = new Dostawca()
//{
//    NazwaFirmy = "Dell Corporation"
//};
//db.Dostawca.Add(dostawca);

//Dostawca dostawca = new Dostawca()
//{
//    NazwaFirmy = "Devcom Incorporation"
//};
//db.Dostawca.Add(dostawca);

//**************************************Dodawanie gotowego zestawu************************************//
//var sprzet = new Sprzet()
//{
//    NazwaSprzetu = "Iphone 13 Pro",
//    Dział = "Dyrektor",
//    Osoba = new Osoba()
//    {
//        Imie = "Wojciech",
//        Nazwisko = "Milczyński",

//    },
//    Dostawcy = new List<Dostawca>
//    { new Dostawca() { NazwaFirmy = "Apple Sp. z .o.o.",
//        Faktury =new List<Faktury>()
//    {
//            new Faktury() {NumerFaktury = "12/2/2021"}
//    }
//    }}

//};
//db.Sprzet.Add(sprzet);
//db.SaveChanges();

//var result = db.Sprzet.SingleOrDefault(x => x.NazwaSprzetu == "Iphone 13 Pro");
//if (result != null)
//{
//    result.NazwaSprzetu = " Iphone 12 Pro";
//    db.SaveChanges();
//}

//using (var db1 = new MyDBContext())
//{
//    var result = db1.Sprzet.Where(b => b.NazwaSprzetu == " Iphone 12 Pro").First();
//    if (result != null)
//    {
//        // result.NazwaSprzetu = "Iphoneb12 Pro";
//        //.Id = result.Id;
//        Sprzet nowy = new Sprzet { Id = result.Id, NazwaSprzetu = "Iphone 10 Pro", Dział = result.Dział, OsobaID=result.OsobaID };
//        db1.Entry(result).CurrentValues.SetValues(nowy);
//        db1.SaveChanges();
//    }
//}


int wybór = 0;

while (wybór != 5)
{

    Console.WriteLine();
    Console.WriteLine("***********************************************");
    Console.WriteLine("1. Znajdź osobę");
    Console.WriteLine("2. Dodaj zestaw do ewidencji");
    Console.WriteLine("3. Usuń Osobę z ewidencji");
    Console.WriteLine("4. Zmiana nazwy sprzętu");
    Console.WriteLine("5. Koniec");
    Console.WriteLine("***********************************************");
    Console.WriteLine();

    Console.Write($"Wybierz co chcesz zrobić: ");
    wybór = Int32.Parse(Console.ReadLine());
    Console.WriteLine();


    switch (wybór)
    {
        case 1:

            Console.WriteLine($"Podaj Nazwisko osoby poszukiwanej");
            string nazwisko = Console.ReadLine();

            var zapytanie = db.Osoba
                                .Where(n => n.Nazwisko == nazwisko)
                                .Include(s => s.Sprzety)
                                .ToList();
            Console.WriteLine();
            foreach (var item in zapytanie)
            {
                Console.WriteLine($"Osoba: {item.Imie} {item.Nazwisko}, posiada: ");

                foreach (var itemSprzet in item.Sprzety)
                {
                    Console.WriteLine($"Nazwa urzadzenia:{itemSprzet.NazwaSprzetu}, w dziale: {itemSprzet.Dział}");
                }
            }

            break;

        case 2:

            Console.WriteLine($"Podaj Nazwę sprzętu: ");
            string NS = Console.ReadLine();

            Console.WriteLine($"Podaj Nazwę Działu: ");
            string dział = Console.ReadLine();

            Console.WriteLine($"Podaj Imię osoby: ");
            string imie = Console.ReadLine();

            Console.WriteLine($"Podaj Nazwisko osoby: ");
            string nazw = Console.ReadLine();

            Console.WriteLine($"Podaj Nazwę Firmy Dostawcy");
            string NazDost = Console.ReadLine();

            Console.WriteLine($"Podaj numer faktury");
            string NrFaktury = Console.ReadLine();



            var sprzet = new Sprzet()
            {


                NazwaSprzetu = NS,
                Dział = dział,
                Osoba = new Osoba()
                {
                    Imie = imie,
                    Nazwisko = nazw

                },
                Dostawcy = new List<Dostawca>
                { new Dostawca() { NazwaFirmy = NazDost,
                    Faktury =new List<Faktury>()
                {
                        new Faktury() {NumerFaktury = NrFaktury}
                }
                }}

            };
            db.Sprzet.Add(sprzet);
            db.SaveChanges();

            break;

        case 3:

            Console.Write("Podaj id użytkownika którego chcesz usunąć: ");
            int idUzytkownika = Convert.ToInt32(Console.ReadLine());

            var osoba1 = await db.Osoba
                .FirstAsync(u => u.Id == idUzytkownika);
            db.Osoba.Remove(osoba1);
            db.SaveChanges();

            Console.Write($"Usunięto użytkownika o id:{idUzytkownika} ");

            // ******* W tym przypadku można usunąć użytkownika numer 7 ponieważ nie ma powiązanych innych tabel ze sobą, chciałem maksymalnie uprościć usuwanie z pominięciem usuwania kaskadowego tabel

            break;
        case 4:
            // ****** Przykładowa zmiana nazwy sprzetu ******

            Console.WriteLine("Podaj dotychczasową nazwę sprzetu :");
            string nazwa1 = Console.ReadLine();
            Console.WriteLine("Podaj nową nazwę sprzetu: ");
            string nazwa2 = Console.ReadLine();

            using (var db1 = new MyDBContext())
            {
                var result = db1.Sprzet.Where(b => b.NazwaSprzetu == nazwa1).First();
                if (result != null)
                {

                    Sprzet nowy = new Sprzet { Id = result.Id, NazwaSprzetu = nazwa2, Dział = result.Dział, OsobaID = result.OsobaID };
                    db1.Entry(result).CurrentValues.SetValues(nowy);
                    db1.SaveChanges();
                }
            }
            break;
    }
}

