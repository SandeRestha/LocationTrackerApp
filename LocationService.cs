using System;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using HeatMapApp.Models;

namespace HeatMapApp.Services
{
    public class LocationService
    {
        public static async Task<LocationData?> GetCurrentLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(10)
                    });
                }

                // Explicit null check and nullable return
                if (location == null)
                    return null;

                return new LocationData
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timestamp = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Location retrieval failed: {ex.Message}");
                return null;
            }
        }
    }
}
