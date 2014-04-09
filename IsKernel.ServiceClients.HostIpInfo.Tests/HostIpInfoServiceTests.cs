using System;
using System.Net;
using IsKernel.ServiceClients.HostIpInfo.Clients.Abstract;
using IsKernel.ServiceClients.HostIpInfo.Clients.Concrete;
using IsKernel.ServiceClients.HostIpInfo.Infrastructure;
using NUnit.Framework;

namespace IsKernel.ServiceClients.HostIpInfo.Tests
{
	[TestFixture]   
    public class HostIpInfoServiceTests
    {
        private IHostIpInfoService _hostIpInfoServiceClient;

        [SetUp]
        public void Setup()
        {
            _hostIpInfoServiceClient = new HostIpInfoService();
        }

        [Test]
        public void GetIpLocationAsync_SpecifiedIp_InformationIsReturned()
        {
            var ip = IPAddress.Parse("12.215.42.19");
            var location = _hostIpInfoServiceClient.GetIpLocationAsync(ip).Result;
            Assert.IsNotNull(location);
        }
        
        [Test]
        public void GetUserCountryFlagUrl_SpecifiedIp_UrlIsReturned()
        {
            var ip = IPAddress.Parse("12.215.42.19");
            var countryFlagUrl = _hostIpInfoServiceClient.GetUserCountryFlagUrl(ip);
            bool condition = (string.IsNullOrWhiteSpace(countryFlagUrl) == false) && (new Uri(countryFlagUrl).IsUrl() == true);
            Assert.IsTrue(condition);
        }
        
        [Test]
        public void GetUserCountryFlag_SpecifiedIp_InformationIsReturned()
        {
        	var ip = IPAddress.Parse("12.215.42.19");
            var countryFlagUrl = _hostIpInfoServiceClient.GetUserCountryFlagAsync(ip).Result;
            Assert.IsNotNull(countryFlagUrl);
        }
    }
}
