using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using IsKernel.ServiceClients.HostIpInfo.Contracts;

namespace IsKernel.ServiceClients.HostIpInfo.Clients.Abstract
{
    public interface IHostIpInfoService
    {
    	/// <summary>
    	/// Returns the country, country code, city name, latitude and longitude coresponding for an IP.
    	/// </summary>
    	/// <param name="ip">An IP address</param>
    	/// <returns>The location information corresonding the the IP</returns>
        Task<LocationInfo> GetIpLocationAsync(IPAddress ip);
        
        /// <summary>
        /// Returns the url hosting the country flag for the country from which the IP originates 
        /// </summary>
        /// <param name="ip">An IP address</param>
        /// <returns></returns>
        string GetUserCountryFlagUrl(IPAddress ip);
        
        /// <summary>
        /// Returns the country flag for the country from which the IP originates as bytes
        /// </summary>
        /// <param name="ip">An IP address</param>
        /// <returns>The country flag in bytes</returns>
        Task<byte[]> GetUserCountryFlagAsync(IPAddress ip);
    }
}
