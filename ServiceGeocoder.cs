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
        public partial Task<IEnumerable<Location>> GetLocationsForAddressAsync(string address);

        /// <summary>
        /// Get Addresses from Location
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Addresses</returns>
        public partial Task<IEnumerable<string>> GetAddressesForLocationAsync(Location location);
    }
}
