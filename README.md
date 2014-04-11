ServiceClients.HostIpInfo
=========================

A simple C# wrapper for the IP lookup and geotargeting service present at http://www.hostip.info/

The service allows the user to:
 - Retrieve the city, country, country code and geolocation coordinates (latitude, longitude) of an IP
 - Retrieve the flag of the country from where the IP comes.

Version
----

1.0

Example
-----

```cs
IHostIpInfoService service = new HostIpInfoService();
    	
var ip = IPAddress.Parse("216.27.61.137");

var locationTask = service.GetIpLocationAsync(ip);
var countryFlagTask = service.GetUserCountryFlagAsync(ip);
string countryFlagUrl = service.GetUserCountryFlagUrl(ip);

LocationInfo location = await locationTask;
byte[] countryFlagBytes = await countryFlagTask;

Console.WriteLine("The IP {0} is from {1}, {2}, {3}, coordinates : ( {4}, {5} ).",
                  location.Ip, 
                  location.Name,
                  location.CountryName,
                  location.CountryCode,
                  location.Latitude,
                  location.Longitude);
Console.Read();
```


License
----

MIT
