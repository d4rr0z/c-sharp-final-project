using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    /// <summary>
    /// Klasa reprezentujaca pacjenta przychodni.
    /// </summary>
    public class Pacjent : Osoba, ICloneable
    {
        #region BD
        [Key]
        public int PacjentId { get; set; }

        public int PrzychodniaId { get; set; }
        public virtual Przychodnia Przychodnia { get; set; }
        #endregion BD

        static int nr = 1;

        string idPacjenta;

        /// <summary>
        /// Numer wykorzystywany do stworzenia ID.
        /// </summary>
        public static int Nr { get => nr; set => nr = value; }
        /// <summary>
        /// ID pacjenta.
        /// </summary>
        public string IdPacjenta { get => idPacjenta; set => idPacjenta = value; }

        /// <summary>
        /// Konstruktor nieparametryczny inicjalizujacy ID pacjenta.
        /// </summary>
        public Pacjent()
        {
            IdPacjenta = $"PAC-{Nr}";
        }

        /// <summary>
        /// Konstruktor parametryczny inicjalizujacy dodatkowo ID pacjenta.
        /// </summary>
        /// <param name="imie">Imie.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="pesel">Numer PESEL.</param>
        /// <param name="miasto">Miasto.</param>
        /// <param name="numerTelefonu">Numer telefonu.</param>
        /// <param name="dataUrodzenia">Data urodzenia.</param>
        /// <param name="plec">Plec.</param>
        public Pacjent(string imie, string nazwisko, string pesel, string miasto, string numerTelefonu, string dataUrodzenia, EnumPlec plec) : base(imie, nazwisko, pesel, miasto, numerTelefonu, dataUrodzenia, plec)
        {
            IdPacjenta = $"PAC-{Nr}";
        }

        /// <summary>
        /// Nadpisanie metody ToString().
        /// </summary>
        /// <returns>Zwraca napis reprezentujacy pacjenta.</returns>
        public override string ToString() => $"{IdPacjenta} {base.ToString()}";

        /// <summary>
        /// Metoda do kopiowania pacjenta.
        /// </summary>
        /// <returns>Zwraca kopie pacjenta.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}