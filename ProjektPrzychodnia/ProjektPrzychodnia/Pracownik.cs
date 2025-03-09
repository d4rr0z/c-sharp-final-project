using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    /// <summary>
    /// Klasa reprezentujaca pracownika, pracujacego w rejestracji przychodni.
    /// </summary>
    public class Pracownik : Osoba, ICloneable
    {
        #region BD
        [Key]
        public int PracownikId { get; set; }

        public int PrzychodniaId { get; set; }
        public virtual Przychodnia Przychodnia { get; set; }
        #endregion BD

        static int nr;

        string idPracownika;
        string login;
        string haslo;

        /// <summary>
        /// Numer wykorzystywany do stworzenia ID.
        /// </summary>
        public static int Nr { get => nr; set => nr = value; }
        /// <summary>
        /// ID pracownika.
        /// </summary>
        public string IdPracownika { get => idPracownika; set => idPracownika = value; }
        /// <summary>
        /// Login pracownika do systemu.
        /// </summary>
        public string Login { get => login; set => login = value; }
        /// <summary>
        /// Haslo pracownika do systemu.
        /// </summary>
        public string Haslo { get => haslo; set => haslo = value; }

        /// <summary>
        /// Konstruktor statyczny inicjalizujacy nr na wartosc 1.
        /// </summary>
        static Pracownik()
        {
            Nr = 1;
        }

        /// <summary>
        /// Konstruktor nieparametryczny.
        /// </summary>
        public Pracownik()
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
        /// <param name="login">Login do systemu.</param>
        /// <param name="haslo">Haslo do systemu.</param>
        public Pracownik(string imie, string nazwisko, string pesel, string miasto, string numerTelefonu, string dataUrodzenia, EnumPlec plec, string login, string haslo) : base(imie, nazwisko, pesel, miasto, numerTelefonu, dataUrodzenia, plec)
        {
            IdPracownika = $"PRA-{Nr}";
            Login = login;
            Haslo = haslo;
            Nr++;
        }

        /// <summary>
        /// Nadpisanie metody ToString().
        /// </summary>
        /// <returns>Zwraca napis reprezentujacy pracownika.</returns>
        public override string ToString() => $"{IdPracownika} {base.ToString()}";

        /// <summary>
        /// Metoda do kopiowania pracownika.
        /// </summary>
        /// <returns>Zwraca kopie pracownika.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}