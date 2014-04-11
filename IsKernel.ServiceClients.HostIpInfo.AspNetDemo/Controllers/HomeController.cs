using System;
using System.IO;
using System.Net;
using System.Web.Mvc;

using IsKernel.ServiceClients.HostIpInfo.Clients.Abstract;
using IsKernel.ServiceClients.HostIpInfo.Clients.Concrete;

namespace IsKernel.ServiceClients.HostIpInfo.AspNetDemo.Controllers
{
	public class HomeController : Controller
	{
		private IHostIpInfoService _service;
		private readonly IPAddress _testIpAddress;
		
		public HomeController()
		{
			_service = new HostIpInfoService();
			_testIpAddress = IPAddress.Parse("216.27.61.137");	
		}
		
		public ActionResult Index()
		{		
			var locationInfo = _service.GetIpLocationAsync(_testIpAddress).Result;
			return View(locationInfo);
		}
		
		public FileResult GetCountryFlag()
		{
			var countryPictureBytes = _service.GetUserCountryFlagAsync(_testIpAddress).Result;
			return this.File(countryPictureBytes, "image/gif");
		}
		
		public ContentResult GetCountryUrl()
		{
			var countryUrl = _service.GetUserCountryFlagUrl(_testIpAddress);
			return Content(countryUrl);
		}
		
	}
}
