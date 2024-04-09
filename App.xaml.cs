using Newtonsoft.Json;
using p4;
using RestSharp;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace p4_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static string SearchTerm { get; set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                // Wywołaj metodę z odpowiedniej przestrzeni nazw
                await SaveRestaurantsFromYelpToDatabase(SearchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania danych do bazy danych: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static async Task SaveRestaurantsFromYelpToDatabase(string searchTerm)
        {
            try
            {
                var options = new RestClientOptions($"https://api.yelp.com/v3/businesses/search?location={searchTerm}&sort_by=best_match&limit=20");
                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("Authorization", "Bearer dfoxuvvHO3lxxJDg3HMugWV_1CyrVQqqkuYYRy2uYK7wlXJ-bNRuQKFmAIG8b3Dpz5FSz9eW68fGtCzNPJCEREahvs0lYkoIe3k9lVAa9Zx4SZMTBw1XH6jaBkwDZnYx");
                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    // Implementacja kodu obsługującego udane zapytanie
                    string jsonString = response.Content;
                    dynamic data = JsonConvert.DeserializeObject(jsonString);

                    using (var context = new BloggingContext())
                    {
                        foreach (var business in data.businesses)
                        {
                            Restaurant restaurant = new Restaurant
                            {
                                Nameofrestaurant = business.name,
                                Imageurlofrestaurant = business.image_url,
                                Urlofrestaurant = business.url,
                                Reviewcount = business.review_count,
                                Price = business.price,
                                Adressofrestaurant = business.location.address1,
                                City = business.location.city,
                                Phonenumber = business.phone,
                                Latitude = business.coordinates.latitude,
                                Longtitude = business.coordinates.longitude
                            };

                            context.Restaurants.Add(restaurant);
                        }

                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" ex {ex.Message}", "Brak wyszukiwanego terminu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ShowLastTwentyRestaurants()
        {
            using (var context = new BloggingContext())
            {
                var lastTwentyRestaurants = context.Restaurants.OrderByDescending(r => r.RestaurantID).Take(20).ToList();
                //restaurantDataGrid.ItemsSource = lastTwentyRestaurants;
            }
        }
        public class BloggingContext : DbContext
        {
            public BloggingContext() : base("name=BloggingContext")
            {
            }

            public DbSet<Restaurant> Restaurants { get; set; }
        }
    }
}
