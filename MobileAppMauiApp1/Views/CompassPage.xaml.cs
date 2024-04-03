
using System.Runtime.InteropServices;

namespace MobileAppMauiApp1.Views;

public partial class CompassPage : ContentPage
{
    private Location _deviceLocation;
    private Location _wallOfTears = new Location(31.7767166, 35.2344924);


    public CompassPage()
	{
		InitializeComponent();
        ToggleCompass();
        UpdateLocationAsync();
    }

    private async void UpdateLocationAsync()
    {
        _deviceLocation = await GetCurrentLocation();
        //LabelDebug.Text = $"Latitude: {_deviceLocation.Latitude}, Longitude: {_deviceLocation.Longitude}, Altitude: {_deviceLocation.Altitude}";
    }

    private void ToggleCompass()
    {
        if (Compass.Default.IsSupported)
        {
            if (!Compass.Default.IsMonitoring)
            {
                // Turn on compass
                Compass.Default.ReadingChanged += Compass_ReadingChanged;
                Compass.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                Compass.Default.Stop();
                Compass.Default.ReadingChanged -= Compass_ReadingChanged;
            }
        }
    }

    // Действия, которые происходят, когда изменяется значение угла компаса
    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        // Вычисление угла между текущим местоположением и целевыми координатами
        double angle = CalculateAngle( DegreesToRadians(/*_deviceLocation.Latitude*/ 32.801304),  DegreesToRadians(/*_deviceLocation.Longitude*/  36.333685),
            DegreesToRadians(_wallOfTears.Latitude), DegreesToRadians(_wallOfTears.Longitude));

        // Обновление угла поворота компаса
        //LabelDebug1.Text = (angle + e.Reading.HeadingMagneticNorth * (-1)).ToString();
        ImageArrow.Rotation = angle + e.Reading.HeadingMagneticNorth * (-1);
    }


    private double CalculateAngle(double lat1, double lon1, double lat2, double lon2)
    {
        double dLon = (lon2 - lon1);

        double y = Math.Sin(dLon) * Math.Cos(lat2);
        double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);

        double brng = Math.Atan2(y, x);

        brng = RadiansToDegrees(brng);
        brng = (brng + 360) % 360;
        //brng = 360 - brng; // count degrees counter-clockwise - remove to make clockwise

        return brng;
    }

    private double RadiansToDegrees(double radians)
    {
        return radians * (180 / Math.PI);
    }

    private double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public async Task<Location> GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            // Get cached location, else get real location.
            Location location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
            }

            if (location != null)
                return location;
                    //$"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
            
        }

        return null;
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }
}