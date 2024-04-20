using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using GMap.NET.MapProviders;
using Newtonsoft.Json.Linq;
using p4;
using RestSharp;

namespace p4_projekt.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
        private UserRegister loggedInUser;
        public DiscoveryView()
        {
            InitializeComponent();
            ShowLastTwentyRestaurants();
            loggedInUser = App.LoggedInUser;
        }
        private void ShowLastTwentyRestaurants()
        {
            using (var context = new AppDbContext())
            {
                var lastTwentyRestaurants = context.Restaurants.OrderByDescending(r => r.RestaurantID).Take(20).ToList();
                restaurantDataGrid.ItemsSource = lastTwentyRestaurants;
            }
        }

        public class AppDbContext : DbContext
        {
            public AppDbContext() : base("name=BloggingContext")
            {
            }

            public DbSet<Restaurant> Restaurants { get; set; }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
        //trzeba chyba zrobic okno co najpierw jest rejestracja i login i tak bedzie najprosciej zapisywac chyba
        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (loggedInUser != null)
            {
                using (var db = new p4.BloggingContext())
                {
                    // Pobierz zaznaczone restauracje z DataGrid
                    foreach (var selectedItem in restaurantDataGrid.SelectedItems)
                    {
                        try
                        {
                            if (selectedItem is Restaurant restaurant)
                            {
                                // Sprawdź, czy restauracja nie jest już dodana do ulubionych
                                if (loggedInUser.LikedRestaurants != restaurant.RestaurantID)
                                {
                                    // Utwórz nowy obiekt UserRegister i dodaj identyfikator restauracji
                                    UserRegister userRegister = new UserRegister()
                                    {
                                        Lastname= loggedInUser.Lastname,
                                        Email= loggedInUser.Email,
                                        Password= loggedInUser.Password,
                                        LikedRestaurants = restaurant.RestaurantID
                                    };

                                    // Dodaj nowego użytkownika do bazy danych
                                    db.UserData.Add(userRegister);
                                    MessageBox.Show("udalo sie");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Obsłuż wyjątek, jeśli to konieczne
                        }
                    }

                    // Zapisz zmiany w bazie danych
                    db.SaveChanges();

                    // Wyświetl ponownie ulubione restauracje po dodaniu nowych
                }
            }
            else
            {
                MessageBox.Show("Brak zalogowanego użytkownika.");
            }
        }
    }

}

