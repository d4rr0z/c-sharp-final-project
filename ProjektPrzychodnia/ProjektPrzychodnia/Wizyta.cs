using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    /// <summary>
    /// Klasa reprezentujaca wizyte w przychodni.
    /// </summary>
    public class Wizyta : ICloneable
    {
        #region BD
        [Key]
        public int WizytaId { get; set; }

        public int PrzychodniaId { get; set; }
        public virtual Przychodnia Przychodnia { get; set; }
        #endregion BD

        static int nr = 1;

        string idWizyty;
        Pacjent pacjent;
        Lekarz lekarz;
        DateTime termin;

        /// <summary>
        /// Numer wykorzystywany do stworzenia ID.
        /// </summary>
        public static int Nr { get => nr; set => nr = value; }
        /// <summary>
        /// ID wizyty.
        /// </summary>
        public string IdWizyty { get => idWizyty; set => idWizyty = value; }
        /// <summary>
        /// Pacjent.
        /// </summary>
        public Pacjent Pacjent { get => pacjent; set => pacjent = value; }
        /// <summary>
        /// Lekarz.
        /// </summary>
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        /// <summary>
        /// Termin wizyty.
        /// </summary>
        public DateTime Termin { get => termin; set => termin = value; }

        /// <summary>
        /// Konstruktor nieparametryczny inicjalizujacy ID wizyty.
        /// </summary>
        public Wizyta()
        {
            IdWizyty = $"WIZ-{Nr}";
        }

        /// <summary>
        /// Konstruktor parametryczny inicjalizujacy dodatkowo ID wizyty.
        /// </summary>
        /// <param name="pacjent">Pacjent.</param>
        /// <param name="lekarz">Lekarz.</param>
        /// <param name="termin">Termin wizyty.</param>
        public Wizyta(Pacjent pacjent, Lekarz lekarz, string termin)
        {
            IdWizyty = $"WIZ-{Nr}";
            Pacjent = pacjent;
            Lekarz = lekarz;
            if (DateTime.TryParseExact(termin, "HH:mm", null, DateTimeStyles.None, out DateTime date))
                Termin = date;
        }

        /// <summary>
        /// Nadpisanie metody ToString().
        /// </summary>
        /// <returns>Zwraca napis reprezentujacy wizyte.</returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"Wizyta: {IdWizyty}\n");
            sb.Append($"Pacjent: {Pacjent.Imie} {Pacjent.Nazwisko.ToUpper()}\n");
            sb.Append($"Lekarz: {Lekarz.Imie} {Lekarz.Nazwisko.ToUpper()}, {Lekarz.Specjalizacja}\n");
            sb.Append($"Termin: {Termin}");
            return sb.ToString();
        }

        /// <summary>
        /// Metoda do kopiowania wizyty.
        /// </summary>
        /// <returns>Zwraca kopie wizyty.</returns>
        public object Clone()
        {
            Wizyta kopia = (Wizyta)MemberwiseClone();
            kopia.Pacjent = (Pacjent)Pacjent.Clone();
            kopia.Lekarz = (Lekarz)Lekarz.Clone();
            return kopia;
        }
    }
}
