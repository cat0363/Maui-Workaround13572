#if IOS
using AddressBookUI;
using CoreLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Workaround13572
{
    public partial class ServiceGeocoder 
    {
        /// <summary>
        /// Get Locations from Address
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Locations</returns>
        public partial Task<IEnumerable<Location>> GetLocationsForAddressAsync(string address)
        {
            var geocoder = new CLGeocoder();
            var source = new TaskCompletionSource<IEnumerable<Location>>();
            geocoder.GeocodeAddress(address, (placemarks, error) =>
            {
                if (placemarks == null)
                    placemarks = new CLPlacemark[0];
                IEnumerable<Location> positions = placemarks.Select(p => new Location(p.Location.Coordinate.Latitude, p.Location.Coordinate.Longitude));
                source.SetResult(positions);
            });
            return source.Task;
        }

        /// <summary>
        /// Get Addresses from Location
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Addresses</returns>
        public partial Task<IEnumerable<string>> GetAddressesForLocationAsync(Location location)
        {
            var clocation = new CLLocation(location.Latitude, location.Longitude);
            var geocoder = new CLGeocoder();
            var source = new TaskCompletionSource<IEnumerable<string>>();
            geocoder.ReverseGeocodeLocation(clocation, (placemarks, error) =>
            {
                if (placemarks == null)
                    placemarks = new CLPlacemark[0];
                IEnumerable<string> addresses = placemarks.Select(p => ABAddressFormatting.ToString(p.AddressDictionary, false));
                source.SetResult(addresses);
            });
            return source.Task;
        }
    }
}
#endif