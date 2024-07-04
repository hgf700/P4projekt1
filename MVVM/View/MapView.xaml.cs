using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using p4;
using System.Data.Entity;
using System.Linq;
using System.Globalization;
using System.Windows.Markup;
using Newtonsoft.Json;
using System.Collections.Generic;



namespace p4_projekt.MVVM.View
{
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();
            
            LoadMapAPIAsync(App.Latitude, App.Longitude);
            //App.RestaurantsDownloaded += InitializeMapWhenRestaurantsDownloaded;
        }

        //private void InitializeMapWhenRestaurantsDownloaded(object sender, EventArgs e)
        //{
        //    double latitude = double.Parse(App.Latitude);
        //    double longitude = double.Parse(App.Longitude);
        //    //InitializeMap(latitude, longitude);
        //}

        public static readonly DependencyProperty LatitudeProperty =
            DependencyProperty.Register("Latitude", typeof(string), typeof(MapView), new PropertyMetadata("0.0"));

        public string Latitude
        {
            get { return (string)GetValue(LatitudeProperty); }
            set { SetValue(LatitudeProperty, value); }
        }

        public static readonly DependencyProperty LongitudeProperty =
            DependencyProperty.Register("Longitude", typeof(string), typeof(MapView), new PropertyMetadata("0.0"));

        public string Longitude
        {
            get { return (string)GetValue(LongitudeProperty); }
            set { SetValue(LongitudeProperty, value); }
        }

        private async Task LoadMapAPIAsync(string latitude, string longitude)
        {
            try
            {
                string apiKey = "kRW81dRUcLVtxjEotX38TZlnCtZn_VTu1J0x5LX41Ik";
                string url = $"https://image.maps.ls.hereapi.com/mia/1.6/mapview?apiKey={apiKey}&c={latitude},{longitude}&z=11&w=500&h=500";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.StreamSource = stream;
                            bitmap.EndInit();
                            MapImage.Source = bitmap;

                            // Tutaj można dodać markery do mapy
                            //AddMarkers(latitude, longitude);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Błąd podczas pobierania mapy: {response.StatusCode} - {response.ReasonPhrase}");
                        return; // Nie ma sensu kontynuować, jeśli pobieranie mapy nie powiodło się
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

        private void AddMarkers()
        {
            using (var context = new BloggingContext())
            {
                try
                {
                    var restaurants = context.Restaurants.ToList();

                    foreach (var restaurant in restaurants)
                    {
                        string latitude = restaurant.Latitude;
                        string longitude = restaurant.Longtitude;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
        }

        //private void AddMarkers(string latitude, string longitude)
        //{
        //    // Utwórz nowy marker dla podanych współrzędnych
        //    GMapMarker marker = new GMapMarker(new PointLatLng(double.Parse(latitude, CultureInfo.InvariantCulture), double.Parse(longitude, CultureInfo.InvariantCulture)));

        //    // Dostosuj wygląd markera, na przykład jego kolor, ikonę itp.
        //    // marker.Shape = new Ellipse { Width = 10, Height = 10, Fill = Brushes.Red };

        //    // Dodaj marker do kontrolki mapy
        //    privateGMapControl.Markers.Add(marker);
        //}
        //private void AddMarkers()
        //{
        //    using (var context = new BloggingContext())
        //    {
        //        try
        //        {
        //            // Pobierz wszystkie restauracje z bazy danych
        //            var restaurants = context.Restaurants.ToList();

        //            // Dodaj markery dla każdej restauracji
        //            foreach (var restaurant in restaurants)
        //            {
        //                // Pobierz współrzędne latitude i longitude
        //                double latitude = double.Parse(restaurant.Latitude, CultureInfo.InvariantCulture);
        //                double longitude = double.Parse(restaurant.Longtitude, CultureInfo.InvariantCulture);

        //                // Utwórz nowy marker dla tej restauracji
        //                GMapMarker marker = new GMapMarker(new PointLatLng(latitude, longitude));

        //                // Tutaj możesz dostosować wygląd markera, np. ikonę, kolor itp.
        //                //marker.Shape = new Ellipse { Width = 10, Height = 10, Fill = Brushes.Red };

        //                // Dodaj marker do kontrolki mapy
        //                privateGMapControl.Markers.Add(marker);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Wystąpił błąd podczas dodawania markerów: {ex.Message}");
        //        }
        //    }
        //}



    }
}
