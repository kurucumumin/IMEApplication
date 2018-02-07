using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LoginForm.Services
{
    class XmlObject
    {
        public const string SupplierAddress = "Supplier";
        public const string DeliveryAddress = "Delivery";
        public const string InvoiceAddress = "Invoice";

        XDocument doc;

        public XmlObject(string fileName)
        {
            this.doc = XDocument.Load(fileName);
        }

        public XmlCustomer XmlGetCustomerData()
        {
            XmlCustomer customer = new XmlCustomer();
            var c = (from cust in doc.Descendants("Customer")
                                select new
                                {
                                    Id = cust.Elements()
                                             .Where(x => x.Name == "Id")
                                             .First().Value,
                                    Name = cust.Elements()
                                             .Where(x => x.Name == "Name")
                                             .First().Value,
                                    Surname = cust.Elements()
                                             .Where(x => x.Name == "Surname")
                                             .First().Value,
                                    Telephone = cust.Elements()
                                             .Where(x => x.Name == "Telephone")
                                             .First().Value,
                                    Email = cust.Elements()
                                             .Where(x => x.Name == "Email")
                                             .First().Value,
                                }).FirstOrDefault();
            customer.ID = c.Id;
            customer.Name = c.Name;
            customer.Surname = c.Surname;
            customer.Telephone = c.Telephone;
            customer.Email = c.Email;
            customer.SupplierAddress = XmlGetAddressFromCustomer(SupplierAddress);
            customer.DeliveryAddress = XmlGetAddressFromCustomer(DeliveryAddress);
            customer.InvoiceAddress = XmlGetAddressFromCustomer(InvoiceAddress);

            return customer;
        }

        public dynamic XmlGetOrderData()
        {
            dynamic order = (from ord in doc.Descendants("Order")
                             select new
                             {
                                 Currency = ord.Elements("Currency")
                                          .First().Value,
                                 DatePlaced = ord.Elements("DatePlaced")
                                          .First().Value,
                                 CustomerOrderRef = ord.Elements("CustomerOrderRef")
                                          .First().Value,
                                 CustomerOrderName = ord.Elements("CustomerOrderName")
                                          .First().Value,
                                 OrderNumber = ord.Elements("OrderNumber")
                                          .First().Value,
                                 PaymentMethodId = ord.Elements("PaymentMethod").Elements("Id")
                                          .First().Value,
                                 PaymentMethodName = ord.Elements("PaymentMethod").Elements("Name")
                                          .First().Value,
                                 DeliveryMethodId = ord.Elements("DeliveryMethod").Elements("Id")
                                          .First().Value,
                                 DeliveryMethodName = ord.Elements("DeliveryMethod").Elements("Name")
                                          .First().Value
                             }).FirstOrDefault();
            return order;
        }

        public List<XmlProduct> XmlGetProductInfo()
        {
            var products = (from ord in doc.Descendants("Order").Elements("Products").First().Elements()
                                select new
                                {
                                    StockCode = ord.Elements("StockCode")
                                             .First().Value,
                                    CustomerInternalStockNumber = ord.Elements("CustomerInternalStockNumber")
                                             .First().Value,
                                    Quantity = ord.Elements("Quantity")
                                             .First().Value,
                                    Description = ord.Elements("Description")
                                             .First().Value,
                                    ListUnitPrice = ord.Elements("ListUnitPrice")
                                             .First().Value,
                                    YouPay = ord.Elements("YouPay")
                                             .First().Value,
                                    Price = ord.Elements("Price")
                                             .First().Value,
                                }).ToList();

            List<XmlProduct> productList = new List<XmlProduct>();
            foreach (var item in products)
            {
                XmlProduct p = new XmlProduct();
                p.StockCode = item.StockCode;
                p.CustomerInternalStockNumber = item.CustomerInternalStockNumber;
                p.Quantity = item.Quantity;
                p.Description = item.Description;
                p.ListUnitPrice = item.ListUnitPrice;
                p.YouPay = item.YouPay;
                p.Price = item.Price;

                productList.Add(p);
            }
            return productList;
        }

        private XmlAddress XmlGetAddressFromCustomer(String AddressType)
        {
            XmlAddress address = new XmlAddress();

            var a = (from cust in doc.Descendants("Customer").Elements(AddressType).FirstOrDefault().Elements("Address")
                                       //doc.Descendants("Customer").Elements().Where(x => x.Name == "Id").FirstOrDefault().Value
                                   select new
                                   {
                                       Company = cust.Elements()
                                                .Where(x => x.Name == "Company")
                                                .First().Value,
                                       Department = cust.Elements()
                                                .Where(x => x.Name == "Department")
                                                .First().Value,
                                       Address1 = cust.Elements()
                                                .Where(x => x.Name == "Address1")
                                                .First().Value,
                                       Address2 = cust.Elements()
                                                .Where(x => x.Name == "Address2")
                                                .First().Value,
                                       Address3 = cust.Elements()
                                                .Where(x => x.Name == "Address3")
                                                .First().Value,
                                       Address4 = cust.Elements()
                                                .Where(x => x.Name == "Address4")
                                                .First().Value,
                                       PostCode = cust.Elements()
                                                .Where(x => x.Name == "PostCode")
                                                .First().Value,
                                       Country = cust.Elements()
                                                .Where(x => x.Name == "Country")
                                                .First().Value,
                                   }).FirstOrDefault();
            address.CompanyName = a.Company;
            address.Department = a.Department;
            address.Address1 = a.Address1;
            address.Address2 = a.Address2;
            address.Address3 = a.Address3;
            address.Address4 = a.Address4;
            address.PostCode = a.PostCode;
            address.Country = a.Company;

            return address;
        }
    }

    public class XmlProduct
    {
        public string StockCode { get; set; }
        public string CustomerInternalStockNumber { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
        public string ListUnitPrice { get; set; }
        public string YouPay { get; set; }
        public string Price { get; set; }
    }
    public class XmlCustomer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public XmlAddress SupplierAddress { get; set; }
        public XmlAddress DeliveryAddress { get; set; }
        public XmlAddress InvoiceAddress { get; set; }
    }
    public class XmlAddress
    {
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
