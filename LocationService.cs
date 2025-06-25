using System;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors; // Provides access to device geolocation APIs
using HeatMapApp.Models;               // Reference to your custom LocationData model

namespace HeatMapApp.Services
{
    // A service class that provides the functionality to get the current device location
    public class LocationService
    {
        // This asynchronous method returns the current location as a LocationData object.
        // It may return null if location retrieval fails.
        public static async Task<LocationData?> GetCurrentLocationAsync()
        {
            try
            {
                // Try to get the last known location (cached by the system)
                var location = await Geolocation.GetLastKnownLocationAsync();

                // If the cached location is not available, request a fresh location
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,  // Request high accuracy
                        Timeout = TimeSpan.FromSeconds(10)          // Set a timeout of 10 seconds
                    });
                }

                // If the location is still null, return null
                if (location == null)
                    return null;

                // Return the location wrapped in your custom LocationData model
                return new LocationData
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timestamp = DateTime.UtcNow // Store timestamp in UTC format
                };
            }
            catch (Exception ex)
            {
                // Log any exceptions (e.g., permission issues, GPS turned off)
                Console.WriteLine($"Location retrieval failed: {ex.Message}");
                return null;
            }
        }
    }
}
