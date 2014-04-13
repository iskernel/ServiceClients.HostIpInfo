using System;
using System.Linq;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.HostIpInfo.Contracts
{
    public class LocationInfo
    {
		/// <summary>
		/// Name of the country
		/// </summary>
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
	
		/// <summary>
		/// Code of the country
		/// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

		/// <summary>
		/// Analyzed IP
		/// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

		/// <summary>
		/// Name of the city
		/// </summary>
        [JsonProperty("city")]
        public string Name { get; set; }

		/// <summary>
		/// IP origin latitude
		/// </summary>
        [JsonProperty("lat")]
        public double? Latitude { get; set; }

		/// <summary>
		/// IP origin longitude
		/// </summary>
        [JsonProperty("lng")]
        public double? Longitude { get; set; }
    }
}
