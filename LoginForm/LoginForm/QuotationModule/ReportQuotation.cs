﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LoginForm.DataSet;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace LoginForm
{
    public partial class ReportQuotation : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportQuotation()
        {
            InitializeComponent();
        }

        //static DataTable ConvertListToDataTable(List<QuotationDetail> list)
        //{
        //    // New table.
        //    DataTable table = new DataTable();

        //    // Get max columns.
        //    int columns = 0;
            

        //    // Add columns.
        //    for (int i = 0; i < columns; i++)
        //    {
        //        table.Columns.Add();
        //    }

        //    // Add rows.
        //    foreach (var array in list)
        //    {
        //        table.Rows.Add(array);
        //    }

        //    return table;
        //}


        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public void InitData(string quotationNo,string customerName, string mainContact, string cTel, string cEmail, string fax, string rFQNo, int validaty, DateTime date, string represantative, string mail, string tel,string payment, string note, List<QuotationDetail> data)
        {
            pQutationNo.Value = quotationNo;
            pCustomerName.Value = customerName;
            pMainContact.Value = mainContact;
            pTelephone.Value = cTel;
            pCustomerEmail.Value = cEmail;
            pFax.Value = fax;
            pRfqNo.Value = rFQNo;
            pValidity.Value = validaty;
            pDate.Value = date;
            pRepresantative.Value = represantative;
            pContactMail.Value = mail;
            pContactTel.Value = tel;
            pPayment.Value = payment;
            pNote.Value = note;
            if (pNote.Value.ToString() == "")
            {
                xrLabel32.Visible = false;
            }
            DataTable table = ConvertToDataTable<QuotationDetail>(data);

            foreach (QuotationDetail array in data)
            {
                if (array.UnitOfMeasure == "")
                {
                    if (array.UC == 1 && array.SSM == 1)
                    {
                        array.UnitOfMeasure = "EACH " + array.SSM * array.UC;
                    }
                    else if (array.UC > 1)
                    {
                        array.UnitOfMeasure = "PACKET OF " + array.SSM * array.UC;
                    }
                }
                else if (array.UnitOfMeasure == "REEL")
                {
                    array.UnitOfMeasure = "REEL OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "MREEL")
                {
                    array.UnitOfMeasure = "REEL OF " + array.SSM * array.UC + " M";
                }
                else if (array.UnitOfMeasure == "GREEL")
                {
                    array.UnitOfMeasure = "REEL OF " + array.SSM * array.UC + " G";
                }
                else if (array.UnitOfMeasure == "KIT")
                {
                    array.UnitOfMeasure = "KIT OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "BAG")
                {
                    array.UnitOfMeasure = "BAG OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "MBAG")
                {
                    array.UnitOfMeasure = "BAG OF " +array.SSM * array.UC +" M";
                }
                else if (array.UnitOfMeasure == "BOX")
                {
                    array.UnitOfMeasure = "BOX OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "SET")
                {
                    array.UnitOfMeasure = "SET OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "PAIR")
                {
                    array.UnitOfMeasure = "PAIR OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "LOT")
                {
                    array.UnitOfMeasure = "LOT OF " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "XXX")
                {
                    array.UnitOfMeasure = "EACH";
                }
                else if (array.UnitOfMeasure == "M")
                {
                    array.UnitOfMeasure = "METER " + array.SSM * array.UC;
                }
                else if (array.UnitOfMeasure == "TUBE")
                {
                    array.UnitOfMeasure = "TUBE OF " + array.SSM * array.UC;
                }
                array.TargetUP = array.Qty / array.SSM;
            }

            objectDataSource1.DataSource = data;
           
        }

        private void xrTable3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrTableCell2_TextChanged(object sender, EventArgs e)
        {
            if (xrTableCell2.Text != "")
            {
                double sayi = Convert.ToDouble(xrTableCell2.Text);
                double sonuc = (sayi * 5) / 100;
                xrTableCell28.Text = sonuc.ToString();
            }
        }
    }
}
