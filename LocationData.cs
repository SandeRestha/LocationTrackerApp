using SQLite;
using System;

namespace HeatMapApp.Models
{
    // This class represents a single location entry to be stored in the SQLite database.
    public class LocationData
    {
        // Primary key for the database table, auto-incremented for each new record.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // The latitude of the user's location (e.g., 37.7749).
        public double Latitude { get; set; }

        // The longitude of the user's location (e.g., -122.4194).
        public double Longitude { get; set; }

        // The timestamp indicating when the location was recorded.
        public DateTime Timestamp { get; set; }
    }
}
