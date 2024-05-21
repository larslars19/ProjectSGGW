using System;
namespace Projekt
{
    class Projekt
    {
        static int Choise(params string[] options)
        {
            for (int i = 1; i <= options.Length; i++)
            {
                Console.WriteLine($"{i}. {options[i - 1]}");
            }
            while (true)
            {
                int odpowiedz = Int32.Parse(Console.ReadLine());
                if (odpowiedz < 1 || odpowiedz > options.Length)
                {
                    Console.WriteLine("Wybierz wariant z powyższych");
                }
                else
                {
                    return odpowiedz;
                }
            }

        }

        public static void Main()
        {
            //Tworzymy 3 obiekty klasy Murder

            //MurdererFactory murder1 = new MurdererFactory();
            //murder1.SetName("Ireneusz", "Młot");
            //murder1.AddAliaces(new[] { "Kleszcz" });
            //murder1.SetStatus(CriminalStatus.Wanted);
            //murder1.SetMetadata(new Metadata(new DateOnly(1978, 07, 12), new Location(52.17905279755373, 20.995086120706485), "Polskie", 'M',
            //    185, 70, "Niebieskie", "Brązowe", "Tatuaż", "Nie znaleziono"));
            //murder1.SetKillCount(123);
            //var ireneusz_mlot = murder1.Build();


            //MurdererFactory murder2 = new MurdererFactory();
            //murder2.SetName("Bogdan Eugeniusz", "Arnold");
            //murder2.SetStatus(CriminalStatus.Killed);
            //murder2.SetMetadata(new Metadata(new DateOnly(1933, 02, 17), new Location(50.252939420233986, 19.034414888594963), "Polskie", 'M',
            //    165, 89, "Szare", "Brązowe", "Nie oznaczono", "Nie istnieje"));
            //murder2.SetVerdict("Kara śmierci");
            //murder2.AddLocation(new Location(50.22887453717144, 18.957017401094724));
            //murder2.SetKillCount(4);
            //murder2.AddKnownVictim("Maria B", "Stefania M.", "Helga S.");
            //var bogdan_arnold = murder2.Build();


            //MurdererFactory murder3 = new MurdererFactory();
            //murder3.SetName("Gary Leon", "Ridgway");
            //murder3.SetStatus(CriminalStatus.InPrison);
            //murder3.SetMetadata(new Metadata(new DateOnly(2000, 05, 01), new Location(50.70770857392239, 16.5856697912835), "Amerykańskie", 'M',
            //    193, 102, "Zielone", "Blondyn", "Kolczyk - prawa brew", "Nie znaleziono"));
            //murder3.SetVerdict("7 lat pozbawienia wolności");
            //murder3.SetKillCount(1);
            //var gary_ridgway = murder3.Build();


            ////Tworzymy 3 obiekty klasy Burglar

            //BurglarFactory burglar1 = new BurglarFactory();
            //burglar1.SetName("Sofia", "Rodriguez");
            //burglar1.SetMetadata(new Metadata(new DateOnly(2000, 12, 29), new Location(52.203770384116304, 21.021650377591413),
            //    "Portugalskie", 'K', 168, 54, "Piwne", "Kolorowe-różowe", "Kolorowe włosy", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fjoemonster.org%2Fart%2F65604&psig=AOvVaw2UkCmjv_VrxRyu30uG8dxQ&ust=1716050156985000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCPjW85GPlYYDFQAAAAAdAAAAABAv"));
            //burglar1.SetStolenValue(10000);
            //burglar1.SetSyndicate(new Syndicate("W POWER", 12, new Location(52.203770384116304, 21.021650377591413)));
            //burglar1.SetStatus(CriminalStatus.Custody);
            //burglar1.SetVerdict("W trakcie...");
            //var sofia_rodriguez = burglar1.Build();

            //BurglarFactory burglar2 = new BurglarFactory();
            //burglar2.SetName("Piotr", "Wiśniewski");
            //burglar2.SetMetadata(new Metadata(new DateOnly(1966, 04, 21), null,
            //    "Polskie", 'M', 164, 99, "Brązowe", "Czarne", "Ślepy na jedno oko", "Nie znaleziono"));
            //burglar2.SetStolenValue(1000);
            //burglar2.SetStatus(CriminalStatus.Released);
            //burglar2.SetVerdict("1 rok pozbawienia wolności");
            //var piotr_wisniewski = burglar2.Build();

            //BurglarFactory burglar3 = new BurglarFactory();
            //burglar3.SetName("Marta", "?");
            //burglar3.AddAliaces(new[] { "Jaskółka", "Ptaszek" });
            //burglar3.SetStolenValue(500000);
            //burglar3.SetStatus(CriminalStatus.Wanted);
            //var marta = burglar3.Build();

            var criminals = new Criminals();
            criminals.ReadCriminals();


            //Wpisywanie z klawiatury - MENU:

            int odpowiedz = Choise(
                "Dodać przestępcę",
                "Lista wszystkich przestępców",
                "Wyszukiwanie po nazwisku",
                "Wyjście"
            );
            //Dodanie nowego obiektu
            if (odpowiedz == 1)
            {
                Dodaj(criminals);
            }

            //Wypisywanie wszystkich obiektów
            else if (odpowiedz == 2)
            {
                foreach (var i in criminals.AllCriminals)
                {
                    i.Wypisz();
                }
            }

            //Wyszukiwanie po nazwisku
            else if(odpowiedz == 3)
            {
                Console.WriteLine("\nPodaj nazwisko");
                BasicCriminal? criminal = criminals.FindCriminalByLastName(Console.ReadLine());
                if(criminal == null)
                {
                    Console.WriteLine("Nie znaleziono");
                }
                else
                {
                    criminal.Wypisz();
                }
            }

            //Wyjście
            else if (odpowiedz == 4)
            {
                Console.WriteLine("\nKoniec pracy na dzisiaj");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();

        }

        private static void Dodaj(Criminals criminals)
        {
            Console.WriteLine("\nPodaj specjalizację: ");
            int specjalizacja = Choise("Morderca", "Złodziej");
            CriminalFactory factory = new MurdererFactory();
            if (specjalizacja == 2)
            {
                factory = new BurglarFactory();
            }
            Console.WriteLine("\nImię i nazwisko: ");
            factory.SetName(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine("\nKsywa: ");
            factory.AddAliaces(new[] { Console.ReadLine() });
            Console.WriteLine("\nStatus:");

            int status = Choise("Poszukiwany", "Zatrzymany", "W więzieniu", "Zabity", "Zwolniony");
            switch (status)
            {
                case 1: factory.SetStatus(CriminalStatus.Wanted); break;
                case 2: factory.SetStatus(CriminalStatus.Custody); break;
                case 3: factory.SetStatus(CriminalStatus.InPrison); break;
                case 4: factory.SetStatus(CriminalStatus.Killed); break;
                case 5: factory.SetStatus(CriminalStatus.Released); break;
                default: Console.WriteLine("Wybierz wariant z powyższych"); break;
            }
            if (specjalizacja == 1)
            {
                Console.WriteLine("Iłość ofiar: ");
                ((MurdererFactory)factory).SetKillCount(int.Parse(Console.ReadLine()));
                Console.WriteLine("Znane ofiary (jeśli nie ma, to wpisać '-'): ");
                ((MurdererFactory)factory).AddKnownVictim(Console.ReadLine());
            }
            else if (specjalizacja == 2)
            {
                Console.WriteLine("Skradziona suma: ");
                ((BurglarFactory)factory).SetStolenValue(double.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Werdykt: ");
            factory.SetVerdict(Console.ReadLine());
            Console.WriteLine("Lokacja, w której ostatni raz widziano przestępcę: ");
            double lat = double.Parse(Console.ReadLine());
            double lon = double.Parse(Console.ReadLine());
            factory.AddLocation(new Location(lat, lon));


            Console.WriteLine("\nDodatkowe dane");

            var met = new Metadata();

            Console.WriteLine("Data urodzenia w formacie (yyyy, mm, dd): ");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            met.dateOfBirth = new DateOnly(year, month, day);

            Console.WriteLine("Miejsce urodzenia: szerokość i długość geograficzna: ");
            lat = double.Parse(Console.ReadLine());
            lon = double.Parse(Console.ReadLine());
            met.placeOfBirth = new Location(lat, lon);

            Console.WriteLine("Narodowość: ");
            met.citizenship = Console.ReadLine();

            Console.WriteLine("Płeć: ");
            met.sex = char.Parse(Console.ReadLine());

            Console.WriteLine("Wzrost i waga: ");
            met.height = int.Parse(Console.ReadLine());
            met.weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Kolor oczy: ");
            met.eyeColor = Console.ReadLine();


            Console.WriteLine("Kolor włosów: ");
            met.hairColor = Console.ReadLine();

            Console.WriteLine("Dodatkowe cechy: ");
            met.features = Console.ReadLine();

            Console.WriteLine("Zdjęcie, link: ");
            met.photo = Console.ReadLine();

            factory.SetMetadata(met);
            criminals.AddCriminals(factory.Build());
            criminals.SaveCriminals();
        }
    }

}