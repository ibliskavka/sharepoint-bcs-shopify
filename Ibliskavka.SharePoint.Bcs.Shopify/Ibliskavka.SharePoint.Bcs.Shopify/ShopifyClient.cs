using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Ibliskavka.SharePoint.Bcs.Shopify
{
    /// <summary>
    /// This is a slightly higher level implementation of the API. It provides specific actionable methonds and does some deserialization.
    /// If you want strongly typed access to the API this would be the class to update.
    /// </summary>
    public class ShopifyClient : IDisposable
    {
        private readonly ShopifyApi _api;
        private readonly JavaScriptSerializer _serializer;

        public ShopifyClient(string apiKey, string apiPassword, string hostName)
        {
            _serializer = new JavaScriptSerializer();
            _api = new ShopifyApi(apiKey, apiPassword, hostName);
        }
        
        /// <summary>
        /// Get a list of all customers.
        /// </summary>
        public dynamic GetCustomers()
        {
            var json = _api.Get("customers.json");
            var obj = _serializer.Deserialize<dynamic>(json);
            return obj;
        }

        /// <summary>
        /// Gets a certain customer by Id.
        /// </summary>
        public dynamic GetCustomer(int id)
        {
            var json = _api.Get(string.Format("customers/{0}.json", id));
            var obj = _serializer.Deserialize<dynamic>(json);
            return obj;
        }

        /// <summary>
        /// Sets the note on a customer record. TODO: This can easily be expanded for other fields.
        /// </summary>
        public void UpdateCustomerNote(int id, string note)
        {
            var customer = new Dictionary<string, object>();
            customer["id"] = id;
            customer["note"] = note;

            var request = new Dictionary<string, object>();
            request["customer"] = customer;

            string json = _serializer.Serialize(request);
            var response = _api.Put(string.Format("customers/{0}.json", id), json);
        }

        /// <summary>
        /// Release disposable resources
        /// </summary>
        public void Dispose()
        {
            _api.Dispose();
        }
    }
}