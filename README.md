# sharepoint-bcs-shopify
A SharePoint Business Connectivity Service connector to display Shopify data on your SharePoint site.

Ivan Bliskavka

http://www.bliskavka.com

This project will connect Shopify customers into SharePoint BCS as an External Content Type.
The ECT can then be displayed as a SharePoint External List.
The ECT is mapped to a Outlook Contact and can be imported into the Outlook application. This makes the customer list portable and available outside of the intranet if needed.

Project development will include:
- Display customers as a list
- Allow customers to be imported into Outlook.
- Allow user to update customer note from Outlook or SharePoint

Project Goals:
- Demonstrate how to set up a custom BCS connector.
- Demonstrate how to interact with Shopify via .NET
- Gauge interest for a more expanded product.

How to use the SharePoint solution:  
1. Open project in Visual Studio 2013 (SharePoint features must be installed)
2. Set your target server (Project Properties -> Site URL)
3. Update ShopifyCustomer.bdcm with your ApiKey, ApiPassword, and ApiHostName. (Create private app on your Shopify site)
4. Deploy: Right-click on Project -> Deploy

How to use ShopifyClient.cs:  
1. Refer to the TestConsole project for an example.