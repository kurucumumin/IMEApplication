using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LoginForm.Services
{
    class XmlToQuotation
    {
        XDocument doc;

        public XmlToQuotation(string fileName)
        {
            this.doc = XDocument.Load(fileName);
        }

        public dynamic XmlGetCustomerData()
        {
            dynamic customer = (from cust in doc.Descendants("Customer")
                                    //doc.Descendants("Customer").Elements().Where(x => x.Name == "Id").FirstOrDefault().Value
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
            return customer;
        }

        public dynamic XmlGetSupplierAddress()
        {
            dynamic SuppAddress = (from cust in doc.Descendants("Customer").Elements("Supplier").FirstOrDefault().Elements("Address")
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
            return SuppAddress;
        }

        public dynamic XmlGetDeliveryAddress()
        {
            dynamic DeliveryAddress = (from cust in doc.Descendants("Customer").Elements("Delivery").FirstOrDefault().Elements("Address")
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
            return DeliveryAddress;
        }

        public dynamic XmlGetInvoiceAddress()
        {
            dynamic InvoiceAddress = (from cust in doc.Descendants("Customer").Elements("Invoice").FirstOrDefault().Elements("Address")
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
            return InvoiceAddress;
        }

        public dynamic XmlGetOrderData()
        {
            dynamic order = (from ord in doc.Descendants("Order")
                                 //doc.Descendants("Customer").Elements().Where(x => x.Name == "Id").FirstOrDefault().Value
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
    }
    public class XmlAddress
    {

    }
}
