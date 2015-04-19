using System;
using Ibliskavka.SharePoint.Bcs.Shopify;

namespace Ibliskavka.SharePoint.Bcs.Shopify.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQuery();
            ShowNote();

            
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public static void UpdateNote(int id = 393272396, string note = "Hello Shopify JSON World")
        {
            using (var client = GetShopifyClient())
            {
                client.UpdateCustomerNote(id, note);
            }
        }

        public static void ShowNote(int id = 393272396)
        {
            using (var client = GetShopifyClient())
            {
                var data = client.GetCustomer(id);

                var cust = data["customer"];

                Console.WriteLine(cust["email"] as string);
                Console.WriteLine(cust["note"] as string);
            }
        }

        public static void TestQuery()
        {
            using (var client = GetShopifyClient())
            {
                var data = client.GetCustomers();
                foreach (var d in data["customers"])
                {
                    Console.WriteLine(d["email"]);
                }
            }
        }

        private static ShopifyClient GetShopifyClient()
        {
            string apiKey = "YOUR_API_KEY";
            string apiPassword = "YOUR_API_PASSWORD";
            string apiHostName = "caspian-theme.myshopify.com";

            return new ShopifyClient(apiKey, apiPassword, apiHostName);
        }
    }
}
