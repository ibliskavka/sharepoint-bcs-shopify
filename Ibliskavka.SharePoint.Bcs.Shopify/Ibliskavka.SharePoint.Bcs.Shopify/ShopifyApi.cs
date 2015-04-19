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
        private const string URL_FORMAT = "https://{0}:{1}@{2}/admin/{3}";
        
        private string _apiKey;
        private string _apiPassword;
        private string _hostName;
        
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
        
        public string Get(string query)
        {
            string url = BuildUrl(query);
            return _wc.DownloadString(url);
        }
        
        public string Put(string query, string json)
        {
            string url = BuildUrl(query);
            return _wc.UploadString(url, "PUT", json);
        }

        private string BuildUrl(string query)
        {
            return string.Format(URL_FORMAT, _apiKey, _apiPassword, _hostName, query);
        }

        public void Dispose()
        {
            _wc.Dispose();
        }
    }
}