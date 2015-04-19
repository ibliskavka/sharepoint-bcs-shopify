using System;

namespace Ibliskavka.SharePoint.Bcs.Shopify.ShopifyCustomer
{
    /// <summary>
    /// This class contains the properties for Entity1. The properties keep the data for Entity1.
    /// If you want to rename the class, don't forget to rename the entity in the model xml as well.
    /// </summary>
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string FileAs { get; set; }

        public string Email { get; set; }
        public bool VerifiedEmail { get; set; }
        public bool AcceptsMarketing { get; set; }
        public string CreatedAt { get; set; }
        
        public string MultipassIdentifier { get; set; }
        public string Note { get; set; }
        
        public string State { get; set; }
        public decimal TotalSpent { get; set; }
        public string UpdatedAt { get; set; }
        
        public string Tags { get; set; }

        public string LastOrderId { get; set; }
        public string LastOrderName { get; set; }
        public int OrdersCount { get; set; }

        public string AddressId { get; set; }
        public string AddressName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressCompany { get; set; }
        public string AddressCountry { get; set; }
        public string AddressFirstName { get; set; }
        public string AddressLastName { get; set; }
        public string AddressPhone { get; set; }
        public string AddressProvince { get; set; }
        public string AddressProvinceCode { get; set; }
        public string AddressZip { get; set; }
        public string AddressCountryCode { get; set; }
        public string AddressCountryName { get; set; }

        public Customer()
        {
        }

        public Customer(dynamic customer)
        {
            Id = (int)customer["id"];
            Email = customer["email"] as string;
            FirstName = customer["first_name"] as string;
            LastName = customer["last_name"] as string;
            AcceptsMarketing = (bool)customer["accepts_marketing"];
            CreatedAt = customer["created_at"] as string;
            LastOrderId = customer["last_order_id"] as string;
            MultipassIdentifier = customer["multipass_identifier"] as string;
            Note = customer["note"] as string;
            OrdersCount = (int)customer["orders_count"];
            State = customer["state"] as string;
            TotalSpent = decimal.Parse(customer["total_spent"]);
            UpdatedAt = customer["updated_at"] as string;
            VerifiedEmail = (bool)customer["verified_email"];
            Tags = customer["tags"] as string;
            LastOrderName = customer["last_order_name"] as string;

            var defaultAddress = customer["default_address"];

            AddressId = defaultAddress["id"] as string;
            AddressLine1 = defaultAddress["address1"] as string;
            AddressLine2 = defaultAddress["address2"] as string;
            AddressCity = defaultAddress["city"] as string;
            AddressCompany = defaultAddress["company"] as string;
            AddressCountry = defaultAddress["country"] as string;
            AddressFirstName = defaultAddress["first_name"] as string;
            AddressLastName = defaultAddress["last_name"] as string;
            AddressPhone = defaultAddress["phone"] as string;
            AddressProvince = defaultAddress["province"] as string;
            AddressZip = defaultAddress["zip"] as string;
            AddressName = defaultAddress["name"] as string;
            AddressProvinceCode = defaultAddress["province_code"] as string;
            AddressCountryCode = defaultAddress["country_code"] as string;
            AddressCountryName = defaultAddress["country_name"] as string;

            //Set additional fields for better Outlook integration
            AddressStreet = AddressLine1 ?? String.Empty;
            if (!string.IsNullOrWhiteSpace(AddressLine2))
            {
                AddressStreet += Environment.NewLine + AddressLine2;
            }

            FullName = LastName ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                if (!string.IsNullOrWhiteSpace(FullName))
                {
                    FullName += ", ";
                }
                FullName += FirstName;
            }
            FileAs = FullName;
        }
    }
}
