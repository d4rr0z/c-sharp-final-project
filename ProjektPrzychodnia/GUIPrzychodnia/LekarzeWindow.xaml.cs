using Microsoft.Win32;
using ProjektPrzychodnia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUIPrzychodnia
{
    /// <summary>
    /// Interaction logic for LekarzeWindow.xaml
    /// </summary>
    public partial class LekarzeWindow : Window
    {
        static string path = "baza.xml";
        Przychodnia przychodnia = new Przychodnia();
        public LekarzeWindow()
        {
            InitializeComponent();
            przychodnia = (Przychodnia)Przychodnia.OdczytXml(path);
            if (przychodnia is object)
            {
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(przychodnia.Lekarze);
                
            }
            NameUser.Content = MainWindow.ZalogowanyUzytkownik;
            ComboBoxSpecializationInit();
        }

        private void lstLekarze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lekarz selectedLekarz = lstLekarze.SelectedItem as Lekarz;
            if (selectedLekarz != null)
            {
                NameDoctor.Content = selectedLekarz.Imie + " " + selectedLekarz.Nazwisko;
                NameSpecialization.Content = selectedLekarz.Specjalizacja;
                NameTelephone.Content = "Tel: " + selectedLekarz.NumerTelefonu;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri($"pack://siteoforigin:,,,/Images/{selectedLekarz.ZdjecieSciezka}", UriKind.RelativeOrAbsolute);
                bitmap.DecodePixelWidth = 130;
                bitmap.EndInit();
                imageDoctor.Source = bitmap;
                List<Wizyta> wizytyLekarz = przychodnia.Wizyty.Where(wizyta => wizyta.Lekarz.Nazwisko == selectedLekarz.Nazwisko).ToList();
                lstWizyt.ItemsSource = new ObservableCollection<Wizyta>(wizytyLekarz);
            }
        }


        private void btn_Search_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(przychodnia.Lekarze);
                return;
            }

            List<Lekarz> znalezieniLekarze = przychodnia.Lekarze.Where(p => p.Nazwisko.Contains(txtSearch.Text) || 
            $"{p.Imie} {p.Nazwisko}".Contains(txtSearch.Text)).ToList();
            if (znalezieniLekarze != null)
            {
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(znalezieniLekarze);
                txtSearch.Text = string.Empty;
            }
            else if (znalezieniLekarze.Any())
            {
                MessageBox.Show("Nie znaleziono lekarza o podanej nazwie.", "Informacja");
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(przychodnia.Lekarze);
                txtSearch.Text = string.Empty;
            }
        }

        private void ComboBoxSpecializationInit()
        {
            List<string> unikalneSpecjalizacje = przychodnia.Lekarze.Select(lekarz => lekarz.Specjalizacja).Distinct().ToList();
            unikalneSpecjalizacje.Insert(0, "");
            ComboBoxSpecialization.ItemsSource = unikalneSpecjalizacje;
        }

        private void ComboBoxSpecialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSpecialization.SelectedItem == null)
            {
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(przychodnia.Lekarze);
                return;
            }

            string selectedSpecialization = ComboBoxSpecialization.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedSpecialization))
            {
                var filteredLekarze = przychodnia.Lekarze.Where(lekarz => lekarz.Specjalizacja == selectedSpecialization).ToList();
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(filteredLekarze);
            }
            else
            {
                lstLekarze.ItemsSource = new ObservableCollection<Lekarz>(przychodnia.Lekarze);
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
            this.Hide();
            DodajWizyteWindow dodajWizyteWindow = new DodajWizyteWindow();
            dodajWizyteWindow.Show();
        }
        private void btn_Doctors_click(object sender, RoutedEventArgs e)
        {

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