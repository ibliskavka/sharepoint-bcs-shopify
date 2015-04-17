using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliskavka.SharePoint.Bcs.Shopify.ShopifyCustomer
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class ShopifyCustomerService
    {
        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity1</returns>
        public static ShopifyCustomer ReadItem(int id)
        {
            using (var api = new ShopifyApi())
            {
                var customer = api.GetCustomer(id);
                return new ShopifyCustomer(customer["customer"]);
            }
        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<ShopifyCustomer> ReadList()
        {
            List<ShopifyCustomer> result = new List<ShopifyCustomer>();
            using (var api = new ShopifyApi())
            {
                var response = api.GetCustomers();
                foreach (var customer in response["customers"])
                {
                    var c= new ShopifyCustomer(customer);
                    result.Add(c);
                }
            }
            return result;
        }

        public static void UpdateItem(ShopifyCustomer customer)
        {
            using (var api = new ShopifyApi())
            {
                api.UpdateCustomerNote(customer.Id, customer.Note);
            }
        }
    }
}
