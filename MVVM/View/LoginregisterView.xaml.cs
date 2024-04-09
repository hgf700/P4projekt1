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
    /// Logika interakcji dla klasy LoginregisterView.xaml
    /// </summary>
    public partial class LoginregisterView : Window
    {
        public LoginregisterView()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterView register = new RegisterView();
            register.Show();
        }

    }
}
