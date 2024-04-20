using Newtonsoft.Json;
using p4;
using p4_projekt.MVVM.View;
using RestSharp;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace p4_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Latitude { get; set; }
        public static string Longitude { get; set; }
        public static string SearchTerm { get; set; }
        public static event EventHandler RestaurantsDownloaded;

        public static UserRegister LoggedInUser { get; set; }
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                await SaveRestaurantsFromYelpToDatabase(SearchTerm);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania danych do bazy danych: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        public static async Task<string> HandleFailedResponse(HttpResponseMessage response)
        {
            string errorMessage = string.Empty;

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                    RestaurantsDownloaded?.Invoke(null, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    errorMessage = $"Failed to read response content: {ex.Message}";
                }

                MessageBox.Show($"Yelp API. Status code: {response.StatusCode}\nError message: {errorMessage}");
            }

            return errorMessage;
        }

        public static class ExceptionHandler
        {
            public static void ShowExceptionMessage(Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static async Task<dynamic> SaveRestaurantsFromYelpToDatabase(string searchTerm)
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
                    string jsonString = response.Content;
                    dynamic data = JsonConvert.DeserializeObject(jsonString);

                    using (var context = new BloggingContext())
                    {

                        //var existingRestaurants = context.Restaurants.ToList();
                        //context.Restaurants.RemoveRange(existingRestaurants);

                        foreach (var business in data.businesses)
                        {
                            try
                            {

                               

                                var latitude = business.coordinates.latitude.ToString(CultureInfo.InvariantCulture);
                                var longitude = business.coordinates.longitude.ToString(CultureInfo.InvariantCulture);
                                App.Latitude = latitude;
                                App.Longitude = longitude;
                                var localization_map_url = $"https://www.google.com/maps/search/?api=1&query={latitude},{longitude}";

                                Restaurant restaurant = new Restaurant
                                {
                                    Nameofrestaurant = business.name,
                                    Imageurlofrestaurant = business.image_url,
                                    Urlofrestaurant = business.url,
                                    Reviewcount = business.review_count,
                                    Rating = business.rating,
                                    Price = business.price,
                                    Adressofrestaurant = business.location.address1,
                                    City = business.location.city,
                                    Phonenumber = business.phone,
                                    Latitude = latitude,
                                    Longtitude = longitude,
                                    LocalizationMapURL = localization_map_url,
                                };
                                context.Restaurants.Add(restaurant);
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler.ShowExceptionMessage(ex);
                            }
                        }
                        context.SaveChanges();
                    }

                    return data; // Zwróć dane
                }
                else
                {
                    //Console.WriteLine
                    //MessageBox.Show
                    Console.WriteLine($"Yelp API. Status code: {response.StatusCode}");
                    //MessageBox.Show($" Yelp API. Status code: {response.StatusCode}");
                    return null; // Zwróć null w przypadku błędu
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; // Zwróć null w przypadku błędu
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