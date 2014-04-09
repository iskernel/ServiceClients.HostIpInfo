using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using IsKernel.ServiceClients.HostIpInfo.Clients.Abstract;
using IsKernel.ServiceClients.HostIpInfo.Contracts;
using IsKernel.ServiceClients.HostIpInfo.Exceptions;
using IsKernel.ServiceClients.HostIpInfo.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace IsKernel.ServiceClients.HostIpInfo.Clients.Concrete
{
    public class HostIpInfoService : IHostIpInfoService
    {
        private const string BASE_URL = "http://api.hostip.info/";
        private const string GET_INFO_URI = "get_json.php";
        private const string GET_FLAG = "flag.php";
        private IRestClient _restClient;

        public HostIpInfoService()
        {
            _restClient = new RestClient(BASE_URL);
        }

        public Task<LocationInfo> GetIpLocationAsync(IPAddress ip)
        {
            try
            {
    	        var taskCompletionSource = new TaskCompletionSource<LocationInfo>();
                var ipString = ip.MapToIPv4().ToString();
                var request = new RestRequest(GET_INFO_URI, Method.GET);
                request.AddParameter("ip", ipString);
                request.AddParameter("position", true);
                _restClient.ExecuteAsync(request, (response) => 
                                                        {
                                        	                var locationInfo = JsonConvert.DeserializeObject<LocationInfo>(response.Content);
                                                        	taskCompletionSource.SetResult(locationInfo);
                                                        });

                return taskCompletionSource.Task;
            }
            catch (Exception exception)
            {
                throw new HostIpInfoServiceException("Could not read user location using the HostIpInfo Service.", exception);
            }
        }
        
       
        public string GetUserCountryFlagUrl(IPAddress ip)
        {
            try
            {
                var ipString = ip.MapToIPv4().ToString();
                var uri = new Uri(BASE_URL);
                var retUri = uri.Append(GET_FLAG).AddQuery("ip", ipString).ToString();
                return retUri;
            }
            catch (Exception exception)
            {
                throw new HostIpInfoServiceException("Could not read user country flag URL using the HostIpInfo Service.", exception);
            }
        }
        
        public Task<byte[]> GetUserCountryFlagAsync(IPAddress ip)
        {
        	try
        	{
                var ipString = ip.MapToIPv4().ToString();
    	        var taskCompletionSource = new TaskCompletionSource<byte[]>();
        		var request = new RestRequest(GET_FLAG, Method.GET);
                request.AddParameter("ip", ipString);
        		_restClient.ExecuteAsync(request, (response) =>
                                         {
                                         	
                                         	taskCompletionSource.SetResult(response.RawBytes);                                         	                                  	
                                         });
        		return taskCompletionSource.Task;
        	}
        	catch(Exception exception)
        	{
        		throw new HostIpInfoServiceException("Could not read user country flag URL using the HostIpInfo Service.", exception);
        	}
        }
    }
}

