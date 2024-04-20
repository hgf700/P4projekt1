using p4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace p4_projekt.MVVM.View
{
    public partial class LoginView : Window
    {
        public static UserRegister LoggedInUser { get; set; }

        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new p4.BloggingContext())
                {
                    string checkemail = this.checkemail.Text;
                    string checkpassword = this.checkpassword.Text;

                    // Sprawdź, czy istnieje użytkownik o podanym emailu i haśle
                    var users = db.UserData.Where(u => u.Email == checkemail && u.Password == checkpassword).ToList();

                    if (users.Any())
                    {
                        // Znaleziono co najmniej jednego użytkownika spełniającego warunek
                        // Tutaj możesz obsłużyć wszystkich znalezionych użytkowników
                        foreach (var user in users)
                        {
                            // Zaloguj użytkownika
                            App.LoggedInUser = user;
                        }
                        MessageBox.Show("Zalogowano pomyślnie!");
                    }
                    else
                    {
                        MessageBox.Show("Błąd logowania. Sprawdź dane logowania.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

