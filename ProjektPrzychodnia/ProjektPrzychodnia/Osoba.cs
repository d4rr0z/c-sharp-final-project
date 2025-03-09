using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ProjektPrzychodnia
{
    /// <summary>
    /// Typ wyliczeniowy dla plci: M - mezczyzna, K - kobieta.
    /// </summary>
    public enum EnumPlec { M, K }

    /// <summary>
    /// Klasa abstrakcyjna reprezentujaca osobe. Po tej klasie dziedzicza pozostale klasy
    /// reprezentujace osoby.
    /// </summary>
    public abstract class Osoba : IEquatable<Osoba>, IComparable<Osoba>
    {
        string imie;
        string nazwisko;
        string pesel;
        string miasto;
        string numerTelefonu;
        DateTime dataUrodzenia;
        EnumPlec plec;

        /// <summary>
        /// Wlasciwosc dla pola imie.
        /// </summary>
        public string Imie 
        { 
            get => imie; 
            set
            {
                if (!CzyPrawidlowe(value))
                    throw new NiewlasciweDaneException("Upewnij sie, ze imie sklada sie wylacznie z liter!");
                imie = value;
            }
        }
        /// <summary>
        /// Wlasciwosc dla pola nazwisko.
        /// </summary>
        public string Nazwisko 
        { 
            get => nazwisko; 
            set
            {
                if (!CzyPrawidlowe(value))
                    throw new NiewlasciweDaneException("Upewnij sie, ze nazwisko sklada sie wylacznie z liter (i ew. spacji)!");
                nazwisko = value;
            }
        }
        /// <summary>
        /// Wlasciwosc dla pola pesel.
        /// </summary>
        public string Pesel 
        { 
            get => pesel; 
            set
            {
                if (value.Length != 11 || !value.All(char.IsDigit))
                {
                    throw new NiepoprawnyPeselException("Niepoprawny pesel!");
                }
                pesel = value; 
            }
        }
        /// <summary>
        /// Wlasciwosc dla pola miasto.
        /// </summary>
        public string Miasto 
        { 
            get => miasto;
            set 
            {
                if (!CzyPrawidlowe(value))
                    throw new NiewlasciweDaneException("Upewnij sie, ze miasto sklada sie wylacznie z liter (i ew. spacji)!");
                miasto = value; 
            } 
        }
        /// <summary>
        /// Wlasciwosc dla pola numerTelefonu.
        /// </summary>
        public string NumerTelefonu 
        { 
            get => numerTelefonu;
            set 
            {
                if (!Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{3}$"))
                    throw new ZlyNumerException("Niepoprawny format numeru telefonu!");
                numerTelefonu = value;
            }
        }
        /// <summary>
        /// Wlasciwosc dla pola dataUrodzenia.
        /// </summary>
        public DateTime DataUrodzenia 
        { 
            get => dataUrodzenia;
            set 
            {
                if (value == DateTime.MinValue)
                    throw new BlednaDataException("Niepoprawny format daty!");
                dataUrodzenia = value; 
            }
        }
        /// <summary>
        /// Wlasciwosc dla pola plec.
        /// </summary>
        public EnumPlec Plec { get => plec; set => plec = value; }

        /// <summary>
        /// Konstruktor nieparametryczny.
        /// </summary>
        public Osoba()
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
        public Osoba(string imie, string nazwisko, string pesel, string miasto, string numerTelefonu, string dataUrodzenia, EnumPlec plec) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            Miasto = miasto;
            NumerTelefonu = numerTelefonu;
            if (DateTime.TryParseExact(dataUrodzenia, new[] { "dd-MM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date))
                DataUrodzenia = date;
            Plec = plec;
        }

        /// <summary>
        /// Nadpisanie metody ToString().
        /// </summary>
        /// <returns>Zwraca napis reprezentujacy osobe.</returns>
        public override string ToString()
        {
            return $"{Imie} {Nazwisko.ToUpper()} ({Plec}), {Miasto}, ur. {DataUrodzenia:dd-MMM-yyyy} nr tel. {NumerTelefonu} (PESEL: {Pesel})";
        }

        /// <summary>
        /// Metoda, ktora po peselu sprawdza czy dwie osoby sa takie same.
        /// </summary>
        /// <param name="other">Osoba, z ktora chcemy porownac inna osobe.</param>
        /// <returns>True, jezeli osoby maja taki sam pesel, w przeciwnym wypadku False.</returns>
        public bool Equals(Osoba? other)
        {
            if (other == null) { return false; }
            return Pesel.Equals(other.Pesel);
        }

        /// <summary>
        /// Metoda, ktora najpierw na podstawie nazwiska, a nastepnie imienia 
        /// ustala kolejnosc dwoch osob.
        /// </summary>
        /// <param name="other">Osoba, z ktora chcemy porownac inna osobe.</param>
        /// <returns>Zwraca 1, jezeli other jest nullem, 0 jezeli obiekty maja to samo 
        /// imie i nazwisko, wartosc mniejsza od 0 jezeli osoba, ktora porownujemy z other
        /// wystepuje pierwsza w kolejnosci, a wartosc wieksza od 0 w przeciwnym wypadku.</returns>
        public int CompareTo(Osoba? other)
        {
            if (other == null) return 1;
            int result = Nazwisko.CompareTo(other.Nazwisko);
            if (result == 0) result = Imie.CompareTo(other.Imie);
            return result;
        }

        /// <summary>
        /// Delegat reprezentujacy metode CzyPrawidlowe.
        /// </summary>
        /// <param name="tekst">Ciag znakow.</param>
        /// <returns>Zwraca True albo False.</returns>
        public delegate bool CzyPrawidloweDelegat(string tekst);

        /// <summary>
        /// Metoda wykorzystujaca powyzszy delegat w celu okreslenia 
        /// czy podany parametr jest prawidlowy.
        /// </summary>
        /// <param name="tekst">Ciag znakow.</param>
        /// <returns>Zwraca wynik wywolania delegata.</returns>
        public bool CzyPrawidlowe(string tekst)
        {
            CzyPrawidloweDelegat delegat = tekst => tekst.All(c => char.IsLetter(c) || c == ' ');
            return delegat(tekst);
        }
    }
}