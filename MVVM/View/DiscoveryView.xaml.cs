using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using p4;

namespace p4_projekt.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
        public DiscoveryView()
        {
            InitializeComponent();
            ShowLastTwentyRestaurants();
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
        //public class GoogleMapsConverter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        if (value is Restaurant restaurant)
        //        {
        //            // Utwórz URL Google Maps na podstawie współrzędnych geograficznych
        //            return new Uri($"https://www.google.com/maps/search/?api=1&query={restaurant.Latitude},{restaurant.Longtitude}");
        //        }

        //        return null;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        throw new NotImplementedException();
        //    }

        //}
    }
}
