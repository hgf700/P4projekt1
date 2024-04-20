using System;
using System.Linq;
using System.Windows;
using p4;
using p4_projekt.Core;
using p4_projekt.MVVM.View;

namespace p4_projekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Loginregister_Click(object sender, RoutedEventArgs e)
        {
            LoginregisterView loginregister = new LoginregisterView();
            loginregister.Show();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTermTextBox.Text;


            await App.SaveRestaurantsFromYelpToDatabase(searchTerm);


        }

    }
}
