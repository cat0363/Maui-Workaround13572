#if ANDROID
using Android.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using AGeocoder = Android.Locations.Geocoder;
using Location = Microsoft.Maui.Devices.Sensors.Location;

namespace Maui_Workaround13572
{
    public partial class ServiceGeocoder
    {
        /// <summary>
        /// Get Locations from Address
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Locations</returns>
        public partial async Task<IEnumerable<Location>> GetLocationsForAddressAsync(string address)
        {
            var geocoder = new AGeocoder(MainActivity.Context);
            var addresses = await geocoder.GetFromLocationNameAsync(address, 5);
            return addresses.Select(p => new Location(p.Latitude, p.Longitude));
        }

        /// <summary>
        /// Get Addresses from Location
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Addresses</returns>
        public partial async Task<IEnumerable<string>> GetAddressesForLocationAsync(Location location)
        {
            var geocoder = new AGeocoder(MainActivity.Context);
            var addresses = await geocoder.GetFromLocationAsync(location.Latitude, location.Longitude, 5);
            return addresses.Select(p =>
            {
                var lines = Enumerable.Range(0, p.MaxAddressLineIndex + 1).Select(p.GetAddressLine);
                return string.Join("\n", lines);
            });
        }
    }
}
#endif