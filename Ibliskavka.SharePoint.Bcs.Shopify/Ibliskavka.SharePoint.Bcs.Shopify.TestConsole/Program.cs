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
            string apiKey = "d7d9b9084f6872aebdc008fde69b0178";
            string apiPassword = "fffc2f9adf29c0540fb6b46833d447c4";
            string apiHostName = "volk-leather.myshopify.com";

            return new ShopifyClient(apiKey, apiPassword, apiHostName);
        }
    }
}
