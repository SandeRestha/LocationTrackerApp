# HeatMapApp

A .NET MAUI Android application that tracks the user's location and visualizes it as a heat map using Google Maps. The app records the user's GPS position at 10-second intervals and displays the accumulated locations as pins on a map.

## Features

- Tracks the user's GPS location in real-time
- Stores locations in a local SQLite database
- Displays each location as a map pin
- Built with .NET MAUI and C#
- Uses the Google Maps API for map rendering

## Technologies Used

- .NET MAUI
- C#
- SQLite
- Google Maps SDK for Android

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR_USERNAME/HeatMapApp.git
   cd HeatMapApp
2. Open the solution in Visual Studio 2022 or later with .NET MAUI workloads installed.
3. Set up your Google Maps API key:
   - Enable Maps SDK for Android on Google Cloud Console
   - Add your key to Platforms/Android/AndroidManifest.xml:
     <meta-data android:name="com.google.android.geo.API_KEY"
           android:value="YOUR_API_KEY_HERE" />
4. Build and deploy to an Android device.

## How It Works

- Uses Geolocation.GetLocationAsync() to get current GPS data
- Saves each location to SQLite using dependency-injected service
- Pins are drawn on the map with timestamped entries

