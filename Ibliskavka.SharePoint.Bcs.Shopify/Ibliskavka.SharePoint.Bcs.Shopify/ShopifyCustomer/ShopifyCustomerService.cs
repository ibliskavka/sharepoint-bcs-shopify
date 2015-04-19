using System;
using System.Collections.Generic;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.BusinessData.MetadataModel.Collections;
using Microsoft.BusinessData.Runtime;
using Microsoft.BusinessData.SystemSpecific;

namespace Ibliskavka.SharePoint.Bcs.Shopify.ShopifyCustomer
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class ShopifyCustomerService : IContextProperty
    {
        public IMethodInstance MethodInstance { get; set; }
        public ILobSystemInstance LobSystemInstance { get; set; }
        public IExecutionContext ExecutionContext { get; set; }

        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity1</returns>
        public Customer ReadItem(int id)
        {
            using (var client = GetShopifyClient())
            {
                var customer = client.GetCustomer(id);
                return new Customer(customer["customer"]);
            }
        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public IEnumerable<Customer> ReadList()
        {
            List<Customer> result = new List<Customer>();
            using (var client = GetShopifyClient())
            {
                var response = client.GetCustomers();
                foreach (var customer in response["customers"])
                {
                    var c= new Customer(customer);
                    result.Add(c);
                }
            }
            return result;
        }

        public void UpdateItem(int id, string note)
        {
            using (var client = GetShopifyClient())
            {
                client.UpdateCustomerNote(id, note);
            }
        }

        private ShopifyClient GetShopifyClient()
        {
            INamedPropertyDictionary properties = LobSystemInstance.GetProperties();

            string apiKey;
            string apiPassword;
            string apiHostName;

            if (properties.ContainsKey("ApiKey") && !string.IsNullOrWhiteSpace(properties["ApiKey"].ToString()))
                apiKey = properties["ApiKey"].ToString();
            else
                throw new ArgumentException("ApiKey property must be defined for LOB System Instance");

            if (properties.ContainsKey("ApiPassword") && !string.IsNullOrWhiteSpace(properties["ApiPassword"].ToString()))
                apiPassword = properties["ApiPassword"].ToString();
            else
                throw new ArgumentException("ApiPassword property must be defined for LOB System Instance");

            if (properties.ContainsKey("ApiHostName") && !string.IsNullOrWhiteSpace(properties["ApiHostName"].ToString()))
                apiHostName = properties["ApiHostName"].ToString();
            else
                throw new ArgumentException("ApiHostName property must be defined for LOB System Instance");

            return new ShopifyClient(apiKey, apiPassword, apiHostName);
        }

        public static void UpdateCustomer()
        {
            throw new System.NotImplementedException();
        }
    }
}
