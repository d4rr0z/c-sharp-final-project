using Microsoft.Win32;
using ProjektPrzychodnia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Interaction logic for PacjenciWindow.xaml
    /// </summary>
    public partial class PacjenciWindow : Window
    {
        static string path = "baza.xml";
        Pacjent pacjentToChange = new Pacjent();
        Przychodnia przychodnia = new Przychodnia();
        public PacjenciWindow()
        {
            InitializeComponent();
            przychodnia = (Przychodnia)Przychodnia.OdczytXml(path);
            if (przychodnia is object)
            {
                lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
            }

            NameAndSurname.Content = MainWindow.ZalogowanyUzytkownik;
            
        }

        private void btn_Add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtSurname.Text != "" && txtPesel.Text != ""
                    && txtDateOfBirth.Text != "" && txtTelephone.Text != "" && txtCity.Text != "")
                {
                    Pacjent pacjentNowy = new Pacjent();
                    pacjentNowy.Imie = txtName.Text;
                    pacjentNowy.Nazwisko = txtSurname.Text;
                    pacjentNowy.Pesel = txtPesel.Text;
                    pacjentNowy.NumerTelefonu = txtTelephone.Text;
                    pacjentNowy.Miasto = txtCity.Text;
                    if (DateTime.TryParseExact(txtDateOfBirth.Text, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out DateTime date))
                    {
                        pacjentNowy.DataUrodzenia = date;
                    }
                    else
                    {
                        throw new BlednaDataException("Niepoprawny format daty!");
                    }
                    pacjentNowy.Plec = (comboGender.Text == "Kobieta") ? EnumPlec.K : EnumPlec.M;
                    
                    przychodnia.Dodaj(przychodnia.Pacjenci, pacjentNowy);
                    przychodnia.ZapiszXML(path);
                    lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                    ClearTextBoxes();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstPacjenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pacjent selectedPacjent = lstPacjenci.SelectedItem as Pacjent;

            if (selectedPacjent != null)
            {
                pacjentToChange = selectedPacjent;
                txtName.Text = pacjentToChange.Imie;
                txtSurname.Text = pacjentToChange.Nazwisko;                
                txtPesel.Text = pacjentToChange.Pesel;
                txtDateOfBirth.Text = pacjentToChange.DataUrodzenia.ToString("dd-MM-yyyy");
                txtTelephone.Text = pacjentToChange.NumerTelefonu;
                txtCity.Text = pacjentToChange.Miasto;
                comboGender.Text = (pacjentToChange.Plec == EnumPlec.K) ? "Kobieta" : "Mężczyzna";
            }
        }
        private void btn_Update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pacjentToChange != null)
                {
                    pacjentToChange.Imie = txtName.Text;
                    pacjentToChange.Nazwisko = txtSurname.Text;
                    pacjentToChange.Pesel = txtPesel.Text;
                    if (DateTime.TryParseExact(txtDateOfBirth.Text, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out DateTime date))
                    {
                        pacjentToChange.DataUrodzenia = date;
                    }

                    pacjentToChange.NumerTelefonu = txtTelephone.Text;
                    pacjentToChange.Miasto = txtCity.Text;
                    pacjentToChange.Plec = (comboGender.Text == "Kobieta") ? EnumPlec.K : EnumPlec.M;
                    przychodnia.ZapiszXML(path);
                    przychodnia.Aktualizuj(przychodnia.Pacjenci, pacjentToChange);
                    lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delate_click(object sender, RoutedEventArgs e)
        {
            if (pacjentToChange != null)
            {
                przychodnia.Usun(przychodnia.Pacjenci, pacjentToChange);
                przychodnia.ZapiszXML(path);
                lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
                ClearTextBoxes();
            }
        }

        private void btn_Sort_click(object sender, RoutedEventArgs e)
        {
            przychodnia.Sortuj();
            lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
        }

        private void btn_Sort_Id_click(object sender, RoutedEventArgs e)
        {
            przychodnia.SortujPoId();
            lstPacjenci.ItemsSource = new ObservableCollection<Pacjent>(przychodnia.Pacjenci);
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
        private void ClearTextBoxes()
        {
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtPesel.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtCity.Text = string.Empty;
            pacjentToChange = null;
        }

        private void btn_Clear_click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }
        private void btn_Pacient_click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Appointments_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DodajWizyteWindow dodajWizyteWindow = new DodajWizyteWindow();
            dodajWizyteWindow.Show();
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
