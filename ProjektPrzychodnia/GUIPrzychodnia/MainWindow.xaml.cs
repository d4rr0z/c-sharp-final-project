using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektPrzychodnia;

namespace GUIPrzychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string path = "baza.xml";
        Przychodnia przychodnia = new Przychodnia();
        MediaPlayer player = new MediaPlayer();        
        public static string ZalogowanyUzytkownik { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            player.Open(new Uri("pack://siteoforigin:,,,/Sound/music.wav", UriKind.RelativeOrAbsolute));
            player.Play();
            przychodnia = (Przychodnia)Przychodnia.OdczytXml(path);
            if (przychodnia.Lekarze[0].TerminyPrzyjec[0].Date != DateTime.Now.Date)
            {
                //player.Stop();
                foreach (var item in przychodnia.Lekarze)
                {
                    item.TerminyPrzyjec = item.GenerujTerminy();
                    przychodnia.ZapiszXML(path);
                }
            }
            Pacjent.Nr = przychodnia.PacNr;
            Wizyta.Nr = przychodnia.WizNr;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            String username = txtUsername.Text;
            String password = PasswordBox.Password;

            if (przychodnia != null && przychodnia.Pracownicy != null)
            {
                Pracownik zalogowanyPracownik = przychodnia.Pracownicy.FirstOrDefault(p => p.Login == username && p.Haslo == password);

                if (zalogowanyPracownik != null)
                {
                    ZalogowanyUzytkownik = $"{zalogowanyPracownik.Imie} {zalogowanyPracownik.Nazwisko}";
                    this.Hide();
                    player.Stop();
                    PacjenciWindow pacjenciWindow = new PacjenciWindow();
                    pacjenciWindow.Show();
                }
                else
                {
                    MessageBox.Show("Niepoprawne hasło lub login.");
                }
            }
            else
            {
                MessageBox.Show($"przychodnia is {(przychodnia == null ? "null" : "not null")}");
                MessageBox.Show($"przychodnia.Pracownicy is {(przychodnia?.Pracownicy == null ? "null" : "not null")}");

            }
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                PasswordBox.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Text = PasswordBox.Password;
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            this.Close();
        }

    }
}
