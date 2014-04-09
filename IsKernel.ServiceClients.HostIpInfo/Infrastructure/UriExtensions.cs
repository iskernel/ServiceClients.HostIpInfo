using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IsKernel.ServiceClients.HostIpInfo.Infrastructure
{
    public static class UriExtensions
    {
        public static bool IsUrl(this Uri uri)
        {
            var uriResult = uri;
            bool result = Uri.TryCreate(uri.ToString(), UriKind.Absolute, out uriResult)
                          && ((uriResult.Scheme == Uri.UriSchemeHttp) || (uri.Scheme == Uri.UriSchemeHttps));
            return result;
        }

        public static Uri Append(this Uri uri, params string[] paths)
        {
            var newUri = new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) 
        	                                     => string.Format("{0}/{1}", current.TrimEnd('/'), path.TrimStart('/'))));
            return newUri;
        }

        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var uriBuilder = new UriBuilder(uri);

            // decodes urlencoded pairs from uri.Query to HttpValueCollection
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
            httpValueCollection.Add(name, value);

            // this code block is taken from httpValueCollection.ToString() method
            // and modified so it encodes strings with HttpUtility.UrlEncode
            if (httpValueCollection.Count == 0)
            {
                uriBuilder.Query = String.Empty;
            }
            else
            {
                var builder = new StringBuilder();

                for (int indexI = 0; indexI < httpValueCollection.Count; indexI++)
                {
                    string text = httpValueCollection.GetKey(indexI);
                    text = HttpUtility.UrlEncode(text);

                    string val = (text != null) ? (text + "=") : string.Empty;
                    string[] vals = httpValueCollection.GetValues(indexI);

                    if (builder.Length > 0)
                    {
                        builder.Append('&');
                    }

                    if ((vals == null) || (vals.Length == 0))
                    {
                        builder.Append(val);
                    }
                    else
                    {
                        if (vals.Length == 1)
                        {
                            builder.Append(val);
                            builder.Append(HttpUtility.UrlEncode(vals[0]));
                        }
                        else
                        {
                            for (int indexJ = 0; indexJ < vals.Length; indexJ++)
                            {
                                if (indexJ > 0)
                                {
                                    builder.Append('&');
                                }
                                builder.Append(val);
                                builder.Append(HttpUtility.UrlEncode(vals[indexJ]));
                            }
                        }
                    }
                }
                uriBuilder.Query = builder.ToString();
            }

            return uriBuilder.Uri;
        }
    }
}
