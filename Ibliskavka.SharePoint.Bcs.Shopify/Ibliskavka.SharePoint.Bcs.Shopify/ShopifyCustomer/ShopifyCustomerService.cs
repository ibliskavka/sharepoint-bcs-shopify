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
    /// This class implements IContextProperty to be able to read parameters from the BDCM.
    /// </summary>
    public class ShopifyCustomerService : IContextProperty
    {
        public IMethodInstance MethodInstance { get; set; }
        public ILobSystemInstance LobSystemInstance { get; set; }
        public IExecutionContext ExecutionContext { get; set; }

        /// <summary>
        /// This is a sample specific finder method for Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer</returns>
        public Customer ReadItem(int id)
        {
            using (var client = GetShopifyClient())
            {
                var customer = client.GetCustomer(id);
                return new Customer(customer["customer"]);
            }
        }
        /// <summary>
        /// This is a sample finder method for Customer.
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

        /// <summary>
        /// This method updates a customer. Currently it only updates the customer note but can be expanded pretty easily.
        /// Notice that the method takes flat parameters, not an object.
        /// </summary>
        public void UpdateItem(int id, string note)
        {
            using (var client = GetShopifyClient())
            {
                client.UpdateCustomerNote(id, note);
            }
        }

        /// <summary>
        /// Reads configuration parameters from BDCM and instantiates the ShopifyClient.
        /// </summary>
        /// <returns></returns>
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
    }
}
