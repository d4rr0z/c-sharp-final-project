using ProjektPrzychodnia;

namespace TestPrzychodni
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InicjalizacjaListyTest()
        {
            // Arrange
            Lekarz lekarz;

            // Act
            lekarz = new("Jonathan", "Crane", "18493026751", "Boston", "138-664-556", "03-06-1991", EnumPlec.M, "psychiatra", "doctorCrane.png");

            //Assert
            Assert.IsNotNull(lekarz.TerminyPrzyjec);
        }

        [TestMethod]
        public void NiewlasciweDaneExceptionTest()
        {
            // Arrange
            Pacjent pacjent = new();
            string miasto = "Dystrykt9";

            // Act

            //Assert
            Assert.ThrowsException<NiewlasciweDaneException>(() => pacjent.Miasto = miasto);
        }

        [TestMethod]
        public void SprawdzCompareToTest()
        {
            // Arrange
            Pracownik pracownik1 = new()
            {
                Imie = "James",
                Nazwisko = "Gordon"
            };
            Pracownik pracownik2 = new()
            {
                Imie = "Barbara",
                Nazwisko = "Gordon"
            };

            // Act
            int result = pracownik1.CompareTo(pracownik2);

            //Assert
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DodawanieWizytyTest()
        {
            // Arrange
            Przychodnia przychodnia = new();
            Wizyta wizyta = new(new Pacjent(), new Lekarz("Edward", "Nigma", "22183940593", "Gotham", "128-874-342", "23-03-1992", EnumPlec.M, "stomatolog", "doctorNigma.png"), "08:00");

            // Act
            przychodnia.ZarejestrujWizyte(wizyta);

            //Assert
            Assert.IsTrue(przychodnia.Wizyty.Count == 1);
        }

        [TestMethod]
        public void SprawdzenieEqualsTest()
        {
            // Arrange
            Lekarz lekarz1 = new()
            {
                Pesel = new('9', 11)
            };
            Lekarz lekarz2 = new()
            {
                Pesel = new('9', 11)
            };

            // Act
            bool result = lekarz1.Equals(lekarz2);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void KlonowanieTest()
        {
            // Arrange
            Lekarz lekarz = new("Harleen", "Quinzel", "10293847563", "Arkham", "234-523-678", "27-05-1983", EnumPlec.K, "psychiatra", "doctorHarleen.png");

            // Act
            Lekarz kopia = (Lekarz)lekarz.Clone();

            //Assert
            CollectionAssert.AreEqual(lekarz.TerminyPrzyjec, kopia.TerminyPrzyjec);
            Assert.AreNotSame(lekarz.TerminyPrzyjec, kopia.TerminyPrzyjec);
        }
    }
}