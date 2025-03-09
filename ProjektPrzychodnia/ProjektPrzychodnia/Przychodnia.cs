using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektPrzychodnia
{
    interface IZapisXML
    {
        void ZapiszXML(string nazwa);
    }

    /// <summary>
    /// Klasa reprezentujaca przychodnie.
    /// </summary>
    public class Przychodnia : IZapisXML, ICloneable
    {
        #region BD
        [Key]
        public int PrzychodniaId { get; set; }

        public virtual List<Pacjent> PacjenciPrzychodni { get; set; }
        public virtual List<Lekarz> LekarzePrzychodni { get; set; }
        public virtual List<Wizyta> WizytyPrzychodni { get; set; }
        public virtual List<Pracownik> PracownicyPrzychodni { get; set; }
        
        /// <summary>
        /// Metoda zapisujaca przychodnie do bazy SQL. Dziala.
        /// </summary>
        public void ZapiszDoBazy()
        {
            using var db = new PrzychodniaDbContext();
            db.Przychodnie.Add(this);
            db.SaveChanges();
        }

        /// <summary>
        /// Metoda sluzaca do odczytu przychodni z bazy SQL. Nie do konca dziala...
        /// </summary>
        /// <returns>Zwraca z bazy danych obiekt przychodnia.</returns>
        public static Przychodnia? OdczytajPrzychodnie()
        {
            var db = new PrzychodniaDbContext();
            Przychodnia p = new Przychodnia();
            int przychodniaId = db.Przychodnie.Max(p => p.PrzychodniaId);
            var pbaza = db.Przychodnie.Find(przychodniaId);
            p.Nazwa = pbaza.Nazwa;
            p.PacNr = pbaza.PacNr;
            p.WizNr = pbaza.WizNr;
            p.Pacjenci = pbaza.Pacjenci;
            p.Lekarze = pbaza.Lekarze;
            p.Pracownicy = pbaza.Pracownicy;
            p.Wizyty = pbaza.Wizyty;
            return p;
        }
        #endregion BD

        string nazwa;
        int pacNr = 1;
        int wizNr = 1;
        List<Pacjent> pacjenci = new();
        List<Lekarz> lekarze = new();
        List<Pracownik> pracownicy = new();
        List<Wizyta> wizyty = new();

        /// <summary>
        /// Nazwa przychodni.
        /// </summary>
        public string Nazwa { get => nazwa; set => nazwa = value; }
        /// <summary>
        /// Numer wykorzystywany do dalszego tworzenia ID pacjenta w GUI.
        /// </summary>
        public int PacNr { get => pacNr; set => pacNr = value; }
        /// <summary>
        /// Numer wykorzystywany do dalszego tworzenia ID wizyty w GUI.
        /// </summary>
        public int WizNr { get => wizNr; set => wizNr = value; }
        /// <summary>
        /// Lista pacjentow przychodni.
        /// </summary>
        public List<Pacjent> Pacjenci { get => pacjenci; set => pacjenci = value; }
        /// <summary>
        /// Lista lekarzy przychodni.
        /// </summary>
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }
        /// <summary>
        /// Lista pracownikow przychodni.
        /// </summary>
        public List<Pracownik> Pracownicy { get => pracownicy; set => pracownicy = value; }
        /// <summary>
        /// Lista zarejestrowanych w przychodni wizyt.
        /// </summary>
        public List<Wizyta> Wizyty { get => wizyty; set => wizyty = value; }

        /// <summary>
        /// Konstruktor nieparametryczny inicjalizujacy nazwe przychodni.
        /// </summary>
        public Przychodnia()
        {
            Nazwa = "Arkham Asylum";
        }

        /// <summary>
        /// Konstruktor parametryczny.
        /// </summary>
        /// <param name="nazwa">Nazwa przychodni.</param>
        public Przychodnia(string nazwa)
        {
            Nazwa = nazwa;
        }

        /// <summary>
        /// Metoda dodajaca odpowiednia osobe do odpowiedniej listy. W przypadku pacjentow
        /// sa tez zwiekszane odpowiednie numery do ID.
        /// </summary>
        /// <typeparam name="T">Typ dziedziczacy po klasie Osoba (razem z ta klasa).
        /// W tym przypadku Pacjent, Lekarz lub Pracownik.</typeparam>
        /// <param name="lista">Odpowiednia lista.</param>
        /// <param name="osoba">Osoba, ktora chcemy dodac.</param>
        public void Dodaj<T>(List<T> lista, T osoba) where T : Osoba
        {
            foreach (var item in lista)
            {
                if (item.Equals(osoba))
                {
                    if (osoba.GetType() == typeof(Pacjent))
                        Console.WriteLine("Pacjent o takim numerze PESEL jest juz zarejestrowany w przychodni.");
                    return;
                }
            }
            lista.Add(osoba);
            if (osoba.GetType() == typeof(Pacjent))
            {
                Console.WriteLine("Pomyślnie zarejestrowano osobe w przychodni.");
                Pacjent.Nr++;
                PacNr++;
            }
        }

        /// <summary>
        /// Metoda usuwajaca odpowiednia osobe z odpowiedniej listy.
        /// </summary>
        /// <typeparam name="T">Typ dziedziczacy po klasie Osoba (razem z ta klasa).
        /// W tym przypadku Pacjent, Lekarz lub Pracownik.</typeparam>
        /// <param name="lista">Odpowiednia lista.</param>
        /// <param name="osoba">Osoba, ktora chcemy usunac.</param>
        public void Usun<T>(List<T> lista, T osoba) where T : Osoba
        {
            if (lista.Contains(osoba))
                lista.Remove(osoba);
                if (osoba.GetType() == typeof(Pacjent))
                    Console.WriteLine("Pomyślnie wyrejestrowano osobe z przychodni.");
        }

        /// <summary>
        /// Metoda aktualizujaca dane odpowiedniej osoby na odpowiedniej liscie.
        /// </summary>
        /// <typeparam name="T">Typ dziedziczacy po klasie Osoba (razem z ta klasa).
        /// W tym przypadku Pacjent, Lekarz lub Pracownik.</typeparam>
        /// <param name="lista">Odpowiednia lista.</param>
        /// <param name="nowyObiekt">Osoba, ktorej dane chcemy zaktualizowac.</param>
        public void Aktualizuj<T>(List<T> lista, T nowyObiekt) where T : Osoba
        {
            T? staryObiekt = lista.Find(o => o.Equals(nowyObiekt));
            if (staryObiekt != null)
            {
                foreach (var item in typeof(T).GetProperties())
                {
                    var wlasciwosc = nowyObiekt.GetType().GetProperty(item.Name);
                    if (wlasciwosc != null && item.CanWrite)
                    {
                        item.SetValue(staryObiekt, wlasciwosc.GetValue(nowyObiekt));
                        Console.WriteLine("Pomyslnie zaktualizowano dane pacjenta.");
                    }
                }
            }
        }

        /// <summary>
        /// Metoda sluzaca do rejestracji wizyt.
        /// </summary>
        /// <param name="wizyta">Wizyta, ktora zarejestrowac chcemy.</param>
        public void ZarejestrujWizyte(Wizyta wizyta)
        {
            if (wizyta.Lekarz.TerminyPrzyjec.Contains(wizyta.Termin))
            {
                Wizyty.Add(wizyta);
                wizyta.Lekarz.TerminyPrzyjec.Remove(wizyta.Termin);
                Console.WriteLine("Pomyslnie zarajestrowano wizyte.");
                Wizyta.Nr++;
                WizNr++;
                return;
            }
            Console.WriteLine("Wybrana termin jest juz zajety.");
        }

        /// <summary>
        /// Metoda do usuwania wizyt.
        /// </summary>
        /// <param name="wizyta">Wizyta, ktora chcemy usunac.</param>
        public void UsunWizyte(Wizyta wizyta)
        {
            Wizyty.Remove(wizyta);
            wizyta.Lekarz.TerminyPrzyjec.Add(wizyta.Termin);
            wizyta.Lekarz.TerminyPrzyjec.Sort();
            Console.WriteLine("Pomyslnie usunieto wizyte.");
        }

        /// <summary>
        /// Metoda do sortowania pacjentow. Wykorzystuje metode CompareTo z klasy Osoba,
        /// czyli najpierw sortuje po nazwisku, a potem po imieniu.
        /// </summary>
        public void Sortuj()
        {
            Pacjenci.Sort();
        }

        /// <summary>
        /// Metoda sortujaca pacjentow wedlug ID.
        /// </summary>
        public void SortujPoId()
        {
            Pacjenci = Pacjenci.OrderBy(n => CzescNumerycznaId(n)).ToList();
        }

        /// <summary>
        /// Metoda pomocnicza, wykorzystywana w metodzie sortujacej po ID.
        /// </summary>
        /// <param name="pacjent">Pacjent.</param>
        /// <returns>Zwraca numer z ID.</returns>
        public int CzescNumerycznaId(Pacjent pacjent)
        {
            string[] parts = pacjent.IdPacjenta.Split('-');
            if (int.TryParse(parts[1], out int result))
                return result;
            return 0;
        }

        /// <summary>
        /// Nadpisanie metody ToString().
        /// </summary>
        /// <returns>Zwraca napis reprezentujacy przychodnie.</returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(nazwa + "\n");
            sb.Append($"Pacjenci: {Pacjenci.Count}\n");
            sb.Append($"Lekarze: {Lekarze.Count}\n");
            sb.Append($"Pracownicy: {Pracownicy.Count}\n");
            sb.Append($"Wizyty: {Wizyty.Count}");
            return sb.ToString();
        }

        /// <summary>
        /// Metoda serializujaca przychodnie do XML.
        /// </summary>
        /// <param name="nazwa">Nazwa pliku, do ktorego chcemy zapisac wynik serializacji.</param>
        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Przychodnia));
            xs.Serialize(sw, this);
        }

        /// <summary>
        /// Metoda sluzaca do odczytu przychodni z pliku XML.
        /// </summary>
        /// <param name="nazwa">Nazwa pliku, w ktorym zapisana jest przychodnia.</param>
        /// <returns>Zwraca obiekt Przychodnia.</returns>
        public static Przychodnia? OdczytXml(string nazwa)
        {
            if (!File.Exists(nazwa))
                return null;
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Przychodnia));
            return xs.Deserialize(sw) as Przychodnia;
        }

        /// <summary>
        /// Metoda do kopiowania przychodni.
        /// </summary>
        /// <returns>Zwraca kopie przychodni.</returns>
        public object Clone()
        {
            Przychodnia kopia = (Przychodnia)MemberwiseClone();
            kopia.Pacjenci = new();
            foreach (var pacjent in Pacjenci)
                kopia.Pacjenci.Add((Pacjent)pacjent.Clone());
            kopia.Lekarze = new();
            foreach (var lekarz in Lekarze)
                kopia.Lekarze.Add((Lekarz)lekarz.Clone());
            kopia.Pracownicy = new();
            foreach (var pracownik in Pracownicy)
                kopia.Pracownicy.Add((Pracownik)pracownik.Clone());
            kopia.Wizyty = new();
            foreach (var wizyta in Wizyty)
                kopia.Wizyty.Add((Wizyta)wizyta.Clone());
            return kopia;
        }
    }
}