namespace Maui_Workaround13572;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
   
    private async void btnLocationToAddress_Clicked(object sender, EventArgs e)
    {
        // Create Geocoder Service
        ServiceGeocoder geocoder = new ServiceGeocoder();
        // Get Location
        Location location = new Location(double.Parse(txtLatitude.Text), double.Parse(txtLongitude.Text));
        // Get Address from Location
        var addresses = await geocoder.GetAddressesForLocationAsync(location);
        // Set Address
        txtAddress.Text = addresses.Count() == 0 ? string.Empty : addresses.First();
    }

    private async void btnAddressToLocation_Clicked(object sender, EventArgs e)
    {
        // Create Geocoder Service
        ServiceGeocoder geocoder = new ServiceGeocoder();
        // Get Address
        string address = txtAddress.Text;
        // Get Locations from Address
        var locations = await geocoder.GetLocationsForAddressAsync(address);
        // Set Latitude
        txtLatitude.Text = locations.Count() == 0 ? string.Empty : locations.First().Latitude.ToString();
        // Set Longitude
        txtLongitude.Text = locations.Count() == 0 ? string.Empty : locations.First().Longitude.ToString();
    }
}

