using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    /// <summary>
    /// Klasa reprezentujaca lekarza przychodni.
    /// </summary>
    public class Lekarz : Osoba, ICloneable
    {
        #region BD
        [Key]
        public int LekarzId { get; set; }

        public int PrzychodniaId { get; set; }
        public virtual Przychodnia Przychodnia { get; set; }
        #endregion BD

        static int nr;

        string idLekarza;
        string specjalizacja;
        string zdjecieSciezka;
        List<DateTime> terminyPrzyjec;

        /// <summary>
        /// Numer wykorzystywany do stworzenia ID.
        /// </summary>
        public static int Nr { get => nr; set => nr = value; }
        /// <summary>
        /// ID lekarza.
        /// </summary>
        public string IdLekarza { get => idLekarza; set => idLekarza = value; }
        /// <summary>
        /// Specjalizacja lekarza.
        /// </summary>
        public string Specjalizacja { get => specjalizacja; set => specjalizacja = value; }
        /// <summary>
        /// Sciezka do zdjecia lekarza.
        /// </summary>
        public string ZdjecieSciezka { get => zdjecieSciezka; set => zdjecieSciezka = value; }
        /// <summary>
        /// Lista z terminami przyjec lekarza.
        /// </summary>
        public List<DateTime> TerminyPrzyjec { get => terminyPrzyjec; set => terminyPrzyjec = value; }

        /// <summary>
        /// Konstruktor statyczny inicjalizujacy nr na wartosc 1.
        /// </summary>
        static Lekarz()
        {
            Nr = 1;
        }

        /// <summary>
        /// Konstruktor nieparametryczny.
        /// </summary>
        public Lekarz()
        {
            
        }

        /// <summary>
        /// Konstruktor parametryczny.
        /// </summary>
        /// <param name="imie">Imie.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="pesel">Numer PESEL.</param>
        /// <param name="miasto">Miasto.</param>
        /// <param name="numerTelefonu">Numer telefonu.</param>
        /// <param name="dataUrodzenia">Data urodzenia.</param>
        /// <param name="plec">Plec.</param>
        /// <param name="specjalizacja">Specjalizacja.</param>
        /// <param name="zdjecieSciezka">Sciezka do zdjecia.</param>
        public Lekarz(string imie, string nazwisko, string pesel, string miasto, string numerTelefonu, string dataUrodzenia, EnumPlec plec, string specjalizacja, string zdjecieSciezka) : base(imie, nazwisko, pesel, miasto, numerTelefonu, dataUrodzenia, plec)
        {
            IdLekarza = $"LEK-{Nr}";
            Specjalizacja = specjalizacja;
            Nr++;
            ZdjecieSciezka = zdjecieSciezka;
            TerminyPrzyjec = GenerujTerminy();
        }

        /// <summary>
        /// Funkcja, ktora tworzy liste terminow przyjec.
        /// </summary>
        /// <returns>Zwraca liste z terminami przyjec.</returns>
        public List<DateTime> GenerujTerminy()
        {
            List<DateTime> lista = new();
            DateTime start = DateTime.Today.AddHours(8);
            for (int i = 0; i < 480; i += 30)
            {
                DateTime godzina = start.AddMinutes(i);
                lista.Add(godzina);
            }
            return lista;
        }

        /// <summary>
        /// Nadpisanie metody ToString().
        /// </summary>
        /// <returns>Zwraca napis reprezentujacy lekarza.</returns>
        public override string ToString() => $"{IdLekarza} {base.ToString()}, {Specjalizacja}";

        /// <summary>
        /// Metoda do kopiowania lekarza.
        /// </summary>
        /// <returns>Zwraca kopie lekarza.</returns>
        public object Clone()
        {
            Lekarz kopia = (Lekarz)MemberwiseClone();
            kopia.TerminyPrzyjec = new();
            foreach (var godzina in TerminyPrzyjec)
                kopia.TerminyPrzyjec.Add(godzina);
            return kopia;
        }
    }
}