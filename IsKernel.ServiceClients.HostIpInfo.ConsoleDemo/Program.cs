using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using IsKernel.ServiceClients.HostIpInfo.Clients.Abstract;
using IsKernel.ServiceClients.HostIpInfo.Clients.Concrete;
using IsKernel.ServiceClients.HostIpInfo.Contracts;

namespace IsKernel.ServiceClients.HostIpInfo.ConsoleDemo
{
	class Program
	{
		public static void SaveGif(byte[] bytes, string path)
		{
			using(var memoryStream = new MemoryStream(bytes, 0, bytes.Length))
			{
				using (var img = Image.FromStream(memoryStream)) 
				{
					img.Save(path, ImageFormat.Gif);
				}
			}
		}
		
		public static async void ApiUsageAsync()
		{
			IHostIpInfoService service = new HostIpInfoService();
		
			var ip = IPAddress.Parse("216.27.61.137");
			
			var locationTask = service.GetIpLocationAsync(ip);
			var countryFlagTask = service.GetUserCountryFlagAsync(ip);
			string countryFlagUrl = service.GetUserCountryFlagUrl(ip);
			
			LocationInfo location = await locationTask;
			byte[] countryFlagBytes = await countryFlagTask;
			
			SaveGif(countryFlagBytes, "asyncFlag.gif");
			
			Console.WriteLine("Async usage done");
		}
		
		public static void ApiUsage()
		{

			IHostIpInfoService service = new HostIpInfoService();
		
			var ip = IPAddress.Parse("22.231.113.64");
			
			LocationInfo location = service.GetIpLocationAsync(ip).Result;
			byte[] countryFlagBytes = service.GetUserCountryFlagAsync(ip).Result;
			string countryFlagUrl = service.GetUserCountryFlagUrl(ip);		
			
			SaveGif(countryFlagBytes, "normalFlag.gif");
			
			Console.WriteLine("Normal usage done");
		}
		
		public static void Main(string[] args)
		{
			ApiUsageAsync();
			ApiUsage();
			Console.WriteLine("Over");
			Console.ReadKey(true);
		}
	}
}