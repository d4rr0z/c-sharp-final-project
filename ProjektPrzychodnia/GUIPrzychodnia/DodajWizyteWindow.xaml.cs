using ProjektPrzychodnia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GUIPrzychodnia
{
    /// <summary>
    /// Interaction logic for DodajWizyteWindow.xaml
    /// </summary>
    public partial class DodajWizyteWindow : Window
    {
        static string path = "baza.xml";
        Przychodnia przychodnia = new Przychodnia();
        public DodajWizyteWindow()
        {
            InitializeComponent();
            przychodnia = (Przychodnia)Przychodnia.OdczytXml(path);
            if (przychodnia is object)
            {
                lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                lstWizyty.ItemsSource = new ObservableCollection<Wizyta>(przychodnia.Wizyty);
            }
            NameUser.Content = MainWindow.ZalogowanyUzytkownik;
            ComboBoxSpecializationInit();
        }

        private void lstPacjenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pacjent selectedPacjent = lstPacjenci.SelectedItem as Pacjent;

            if (selectedPacjent != null)
            {
                WybranyPacjent.Content = $"{selectedPacjent.Imie} {selectedPacjent.Nazwisko}"; 
            }
        }
        private void ComboBoxSpecializationInit()
        {
            List<string> unikalneSpecjalizacje = przychodnia.Lekarze.Select(lekarz => lekarz.Specjalizacja).Distinct().ToList();
            unikalneSpecjalizacje.Insert(0, "");
            ComboBoxSpecialization.ItemsSource = unikalneSpecjalizacje;
            ComboBoxSpecialization.SelectedIndex = 0;
        }

        private void ComboBoxSpecialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedSpecialization = ComboBoxSpecialization.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedSpecialization))
            {
                var filteredLekarze = przychodnia.Lekarze
                    .Where(lekarz => lekarz.Specjalizacja == selectedSpecialization)
                    .ToList();

                lstLekarzyBox.ItemsSource = filteredLekarze;
            }
            else
            {
                lstLekarzyBox.ItemsSource = przychodnia.Lekarze;

            }
        }

        private void lstLekarzyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstLekarzyBox.SelectedItem is Lekarz selectedLekarz)
            {
                ComboBoxHours.ItemsSource = selectedLekarz.TerminyPrzyjec;
            }
        }


        private void btn_Add_click(object sender, RoutedEventArgs e)
        {
            Pacjent selectedPacjent = (Pacjent)lstPacjenci.SelectedItem;
            Lekarz selectedLekarz = (Lekarz)lstLekarzyBox.SelectedItem;

            if (selectedPacjent != null && selectedLekarz != null && ComboBoxHours.SelectedItem is DateTime selectedGodzina)
            {
                Wizyta nowaWizyta = new Wizyta
                {
                    Pacjent = selectedPacjent,
                    Lekarz = selectedLekarz,
                    Termin = selectedGodzina
                };

                przychodnia.ZarejestrujWizyte(nowaWizyta);
                przychodnia.ZapiszXML(path);
                lstWizyty.ItemsSource = new ObservableCollection<Wizyta>(przychodnia.Wizyty);

                // Odświeżanie ComboBoxHours
                lstLekarzyBox.SelectedIndex = -1;
                ComboBoxHours.ItemsSource = null; // Usunięcie starych danych               
                ComboBoxHours.ItemsSource = selectedLekarz.TerminyPrzyjec;

                MessageBox.Show("Wizyta została dodana.");

                lstPacjenci.SelectedIndex = -1;
                ComboBoxSpecialization.SelectedIndex = 0;
                ComboBoxHours.SelectedIndex = -1;
                WybranyPacjent.Content = string.Empty;
            }
            else
            {
                MessageBox.Show("Proszę wybrać pacjenta, lekarza i godzinę.");
            }
        }

        private void btn_Search_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                return;
            }

            List<Pacjent> znalezieniPacjenci = przychodnia.Pacjenci.Where(p => p.Pesel == txtSearch.Text || p.Nazwisko == txtSearch.Text).ToList();
            if (znalezieniPacjenci != null)
            {
                lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(znalezieniPacjenci);
                txtSearch.Text = string.Empty;
            }
            else if (znalezieniPacjenci.Any())
            {
                MessageBox.Show("Nie znaleziono pacjenta o podanym PESELu bądź nazwisku.", "Informacja");
                lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                txtSearch.Text = string.Empty;
            }
        }

        private void btn_Delate_click(object sender, RoutedEventArgs e)
        {
            if (lstWizyty.SelectedItem != null)
            {
                Wizyta selectedWizyta = (Wizyta)lstWizyty.SelectedItem;
                przychodnia.UsunWizyte(selectedWizyta);
                przychodnia.ZapiszXML(path);
                // Odświeżanie ComboBoxHours po usunięciu wizyty
                lstLekarzyBox.SelectedIndex = -1;
                ComboBoxHours.ItemsSource = null; // Usunięcie starych danych
                ComboBoxHours.ItemsSource = ((Lekarz)lstLekarzyBox.SelectedItem)?.TerminyPrzyjec; // Ustawienie nowych danych

                lstWizyty.ItemsSource = new ObservableCollection<Wizyta>(przychodnia.Wizyty);
            }
        }
        private void btn_Pacient_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PacjenciWindow pacjenci = new PacjenciWindow();
            pacjenci.Show();
        }
        private void btn_Appointments_click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Doctors_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LekarzeWindow lekarzeWindow = new LekarzeWindow();
            lekarzeWindow.Show();
        }
        private void btn_LoggOut_click(object sender, RoutedEventArgs e)
        {
            przychodnia.ZapiszXML(path);
            this.Hide();
            MainWindow logIn = new MainWindow();
            logIn.Show();
        }
        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
