using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace Ibliskavka.SharePoint.Bcs.Shopify
{
    /// <summary>
    /// Provides a very basic implementation of the Shopify API. Input and output is at the JSON level.
    /// TODO: Add POST and DELETE verbs.
    /// </summary>
    public class ShopifyApi : IDisposable
    {
        private readonly string _apiKey;
        private readonly string _apiPassword;
        private readonly string _hostName;
        
        private readonly WebClient _wc;

        
        public ShopifyApi(string apiKey, string apiPassword, string hostName)
        {
            _apiKey = apiKey;
            _apiPassword = apiPassword;
            _hostName = hostName;

            _wc = new WebClient();
            _wc.Headers.Add("Content-Type", "application/json");
            _wc.Credentials = new NetworkCredential(_apiKey, _apiPassword);
        }
        
        /// <summary>
        /// Downloads a Shopify resource using the Get verb
        /// </summary>
        public string Get(string resource)
        {
            string url = BuildResourceUrl(resource);
            return _wc.DownloadString(url);
        }
        
        /// <summary>
        /// Uploads json to a resource using the PUT verb. Used for updating.
        /// </summary>
        public string Put(string resource, string json)
        {
            string url = BuildResourceUrl(resource);
            return _wc.UploadString(url, "PUT", json);
        }

        private string BuildResourceUrl(string query)
        {
            const string urlFormat = "https://{0}:{1}@{2}/admin/{3}";
            return string.Format(urlFormat, _apiKey, _apiPassword, _hostName, query);
        }

        /// <summary>
        /// Release disposable resources
        /// </summary>
        public void Dispose()
        {
            _wc.Dispose();
        }
    }
}