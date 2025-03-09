using System;

namespace ProjektPrzychodnia;

internal class Program
{
    static void Main(string[] args)
    {
        Przychodnia przychodnia = new();
        try
        {
            #region Pacjenci
            Pacjent pac1 = new("Victor", "Zsasz", "83949563271", "Gotham", "466-321-654", "17-08-1995", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac1);
            Pacjent pac2 = new("Harvey", "Dent", "72938501842", "New York", "784-423-642", "25-03-1971", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac2);
            Pacjent pac3 = new("Solomon", "Grundy", "63856437921", "Salem", "328-887-234", "06-12-1939", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac3);
            Pacjent pac4 = new("Waylon", "Jones", "77338293743", "Gotham", "325-423-909", "19-02-1988", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac4);
            Pacjent pac5 = new("Thomas", "Elliot", "19029387465", "Boston", "464-230-989", "22-11-1979", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac5);
            Pacjent pac6 = new("Garfield", "Lynns", "18882936723", "Gotham", "899-997-429", "30-01-2002", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac6);
            Pacjent pac7 = new("Jervis", "Tetch", "98990872091", "Metropolis", "329-993-249", "02-07-2000", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac7);
            Pacjent pac8 = new("Nora", "Fries", "99728364771", "Salem", "998-499-984", "08-08-1999", EnumPlec.K);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac8);
            Pacjent pac9 = new("Helena", "Bertinelli", "63728394066", "Salem", "235-345-235", "11-10-1993", EnumPlec.K);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac9);
            Pacjent pac10 = new("Julian", "Day", "00192378467", "New York", "377-820-883", "27-04-1983", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac10);
            Pacjent pac11 = new("Michael", "Lane", "26374836372", "Boston", "283-204-929", "21-06-1968", EnumPlec.M);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac11);
            Pacjent pac12 = new("Dinah", "Lance", "07283948732", "Metropolis", "112-405-876", "14-05-1965", EnumPlec.K);
            przychodnia.Dodaj(przychodnia.Pacjenci, pac12);
            #endregion Pacjenci
            #region Pracownicy
            Pracownik pra1 = new("Quincy", "Sharp", "74938754429", "Arkham", "234-543-235", "30-09-1967", EnumPlec.M, "user1", "pass1");
            przychodnia.Dodaj(przychodnia.Pracownicy, pra1);
            Pracownik pra2 = new("Vicki", "Vale", "89765342899", "Gotham", "987-345-123", "15-06-1984", EnumPlec.K, "user2", "pass2");
            przychodnia.Dodaj(przychodnia.Pracownicy, pra2);
            Pracownik pra3 = new("Penelope", "Young", "26374839212", "New York", "983-645-992", "01-02-1987", EnumPlec.K, "user3", "pass3");
            przychodnia.Dodaj(przychodnia.Pracownicy, pra3);
            #endregion Pracownicy
            #region Lekarze
            Lekarz lek1 = new("Harleen", "Quinzel", "10293847563", "Arkham", "234-523-678", "27-05-1983", EnumPlec.K, "psychiatra", "doctorHarleen.png");
            przychodnia.Dodaj(przychodnia.Lekarze, lek1);
            Lekarz lek2 = new("Pamela", "Isley", "48394756473", "Metropolis", "654-234-323", "18-07-1980", EnumPlec.K, "neurolog", "doctorPamela.png");
            przychodnia.Dodaj(przychodnia.Lekarze, lek2);
            Lekarz lek3 = new("Jonathan", "Crane", "18493026751", "Boston", "138-664-556", "03-06-1991", EnumPlec.M, "psychiatra", "doctorCrane.png");
            przychodnia.Dodaj(przychodnia.Lekarze, lek3);
            Lekarz lek4 = new("Hugo", "Strange", "12634749390", "Arkham", "567-346-347", "12-02-1978", EnumPlec.M, "okulista", "doctorStrange.png");
            przychodnia.Dodaj(przychodnia.Lekarze, lek4);
            Lekarz lek5 = new("Edward", "Nigma", "22183940593", "Gotham", "128-874-342", "23-03-1992", EnumPlec.M, "stomatolog", "doctorNigma.png");
            przychodnia.Dodaj(przychodnia.Lekarze, lek5);
            Lekarz lek6 = new("Selina", "Kyle", "01918234671", "New York", "564-554-121", "09-11-1989", EnumPlec.K, "laryngolog", "doctorSelina.png");
            przychodnia.Dodaj(przychodnia.Lekarze, lek6);
            #endregion Lekarze
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        foreach (var item in przychodnia.Pacjenci)
            Console.WriteLine(item);
        foreach (var item in przychodnia.Pracownicy)
            Console.WriteLine(item);
        foreach (var item in przychodnia.Lekarze)
            Console.WriteLine(item);

        //przychodnia.ZapiszDoBazy();
        /*Console.WriteLine();
        Przychodnia? przychodnia2 = Przychodnia.OdczytajPrzychodnie();
        Console.WriteLine(przychodnia2);*/

        /*Console.WriteLine();
        przychodnia.Sortuj();
        foreach (var item in przychodnia.Pacjenci)
        {
            Console.WriteLine(item);
            Console.WriteLine(przychodnia.CzescNumerycznaId(item));
        }
        Console.WriteLine();
        przychodnia.SortujPoId();
        foreach (var item in przychodnia.Pacjenci)
            Console.WriteLine(item);*/

        /*foreach(var termin in przychodnia.Lekarze[0].TerminyPrzyjec)
            Console.WriteLine(termin);*/

        /*Console.WriteLine();
        przychodnia.Pacjenci.Sort();
        foreach (var item in przychodnia.Pacjenci)
            Console.WriteLine(item);*/

        przychodnia.ZapiszXML("baza.xml");
        /*Przychodnia? przychodnia2 = Przychodnia.OdczytXml("baza.xml");
        Console.WriteLine(przychodnia2);*/

        /*Wizyta wizyta = new(przychodnia.Pacjenci[1], przychodnia.Lekarze[1], "08:00");
        przychodnia.ZarejestrujWizyte(wizyta);
        Wizyta wizyta2 = new(przychodnia.Pacjenci[1], przychodnia.Lekarze[1], "08:30");
        przychodnia.ZarejestrujWizyte(wizyta2);
        Console.WriteLine(wizyta);
        Console.WriteLine(wizyta2);
        Console.WriteLine(przychodnia.Lekarze[1].TerminyPrzyjec[0]);
        Console.WriteLine(przychodnia.Lekarze[1].TerminyPrzyjec[1]);
        Console.WriteLine(przychodnia);
        przychodnia.UsunWizyte(wizyta);
        Console.WriteLine(przychodnia.Lekarze[1].TerminyPrzyjec[0]);
        Console.WriteLine(przychodnia);
        przychodnia.UsunWizyte(wizyta2);
        Console.WriteLine(przychodnia.Lekarze[1].TerminyPrzyjec[1]);
        Console.WriteLine(przychodnia);*/
    }
}