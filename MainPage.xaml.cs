using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Threading.Tasks;
using HeatMapApp.Data;
using HeatMapApp.Models;
using HeatMapApp.Services;

namespace HeatMapApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();    // Load XAML UI components
            InitializeAsync();        // Start the database and location tracking
        }

        // Main initializer method: sets up the database and starts location polling
        private async void InitializeAsync()
        {
            // Ensure the database is created and ready
            await AppDatabase.InitAsync();

            // Start a repeating timer using Dispatcher (modern MAUI approach)
            Dispatcher.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                // Fire-and-forget async method to avoid CS4010 error
                _ = TrackAndStoreLocationAsync();
                return true; // Keep the timer running
            });
        }

        // This method handles getting the location, saving it, and updating the map
        private async Task TrackAndStoreLocationAsync()
        {
            var location = await LocationService.GetCurrentLocationAsync();
            if (location != null)
            {
                await AppDatabase.AddLocationAsync(location);
                await UpdateHeatMapAsync();
            }
        }

        // Updates the map by clearing existing pins and re-adding all stored locations
        private async Task UpdateHeatMapAsync()
        {
            var locations = await AppDatabase.GetLocationsAsync();

            // Remove existing pins to prevent duplication
            MapView.Pins.Clear();

            // Add a pin for each saved location
            foreach (var loc in locations)
            {
                MapView.Pins.Add(new Pin
                {
                    Label = $"Visited at {loc.Timestamp:t}", // Show time only
                    Location = new Location(loc.Latitude, loc.Longitude),
                    Type = PinType.Place
                });
            }
        }
    }
}
