using p4_projekt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_projekt.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViemCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand MapViewCommand { get; set; }        
        public RelayCommand FavouriteRestaurantViewCommand { get; set; }        



        public HomeViewModel HomeVM { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }
        public MapViewModel MapVM { get; set; }
        public FavouriteRestaurantViewModel FavResVM { get; set; }

        private object _currentView;

        public object CurrentView 
        { 
            get { return _currentView; } 
            set { _currentView = value; 
            OnPropertyChanged();
            } 
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscoveryVM = new DiscoveryViewModel();
            MapVM = new MapViewModel();
            FavResVM = new FavouriteRestaurantViewModel();

            CurrentView = HomeVM;

            HomeViemCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVM;
            });
            MapViewCommand = new RelayCommand(o =>
            {
                CurrentView = MapVM;
            });
            FavouriteRestaurantViewCommand = new RelayCommand(o =>
            {
                CurrentView = FavResVM;
            });

        }
    }    
}
