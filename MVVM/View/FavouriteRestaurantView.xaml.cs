using p4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace p4_projekt.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy FavouriteRestaurantView.xaml
    /// </summary>
    public partial class FavouriteRestaurantView : UserControl
    {
        private UserRegister loggedInUser;

        public FavouriteRestaurantView()
        {
            InitializeComponent();
            loggedInUser = App.LoggedInUser;

            // Jeśli zalogowany użytkownik nie jest null, możemy wyświetlić jego polubione restauracje
            if (loggedInUser != null)
            {
                ShowFavouriteRestaurant();
            }
            else
            {
                MessageBox.Show("Brak zalogowanego użytkownika.");
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }




        private void ShowFavouriteRestaurant()
        {
            if (loggedInUser != null)
            {
                using (var db = new p4.BloggingContext())
                {
                    // Pobierz adres e-mail i hasło zalogowanego użytkownika
                    var email = loggedInUser.Email;
                    var password = loggedInUser.Password;

                    // Sprawdź, czy użytkownik o podanych danych logowania istnieje w bazie danych
                    var user = db.UserData.FirstOrDefault(u => u.Email == email && u.Password == password);
                    if (user != null)
                    {
                        // Utwórz listę przechowującą ulubione restauracje dla zalogowanego użytkownika
                        var allRestaurants = new List<Restaurant>();

                        // Pobierz identyfikatory ulubionych restauracji dla zalogowanego użytkownika
                        var allLikedRestaurantIDs = db.UserData.Where(u => u.Email == email && u.Password == password)
                                                                .Select(u => u.LikedRestaurants)
                                                                .ToList();

                        // Pobierz ulubione restauracje na podstawie identyfikatorów
                        var favouriteRestaurants = db.Restaurants.Where(r => allLikedRestaurantIDs.Contains(r.RestaurantID))
                                                                  .ToList();

                        // Dodaj ulubione restauracje do ogólnej listy
                        allRestaurants.AddRange(favouriteRestaurants);

                        if (allRestaurants.Any())
                        {
                            // Wyświetl ulubione restauracje w DataGrid
                            favouriteRestaurantsDataGrid.ItemsSource = allRestaurants;
                        }
                        else
                        {
                            MessageBox.Show("Brak ulubionych restauracji.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Błąd logowania. Sprawdź dane logowania.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak zalogowanego użytkownika.");
            }
        }




    }
}