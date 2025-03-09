using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    internal class PrzychodniaDbContext : DbContext
    {
        public DbSet<Przychodnia> Przychodnie { get; set; }
        public DbSet<Pacjent> Pacjenci { get; set; }
        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
    }
}
