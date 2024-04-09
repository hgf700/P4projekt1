using p4_projekt.SavingData;
using System;
using System.Collections.Generic;
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

namespace p4_projekt.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lastname = this.lastname.Text;
                string email = this.email.Text;
                string password = this.password.Text;
                string checkkpassword = this.checkkpassword.Text;

                if (checkkpassword == password)
                {
                    if (string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    {
                        // Display Message
                        MessageBox.Show("All fields are required. Please fill in all the fields.", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);

                        // Info
                        return;
                    }
                    // Save Info.
                    InsertingData.SaveInfo(lastname, email, password);

                    // Display Message
                    MessageBox.Show("You are Successfully Registered!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    MessageBox.Show("Incorrect password", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                // Display Message
                MessageBox.Show("Something went wrong. Please try again later.", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
