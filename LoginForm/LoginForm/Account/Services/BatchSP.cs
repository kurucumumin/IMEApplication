﻿using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginForm.Account.Services
{
    class BatchSP
    {
        IMEEntities IME = new IMEEntities();
        //public string ProductBatchBarcodeViewByBatchId(decimal decBathId)
        //{
        //    string barCode = string.Empty;
        //    if (IME.Batches.Where(a => a.batchId == decBathId).FirstOrDefault() != null) barCode = IME.Batches.Where(a => a.batchId == decBathId).FirstOrDefault().barcode;
        //    return barCode;
        //}

        public DataTable BatchNamesCorrespondingToProduct(string decproductId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from b in IME.Batches
                           where b.productId == decproductId
                           select new
                           {
                               b.batchId,
                               b.batchNo
                           }).ToList();

            dt.Columns.Add("PurchaseOrderMasterId");
            dt.Columns.Add("InvoicedMasterId");
            dt.Columns.Add("MR_OrderMasterId");
            dt.Columns.Add("ledgerId");
            

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["PurchaseOrderMasterId"] = item.batchId;
                row["InvoicedMasterId"] = item.batchNo;
                row["MR_OrderMasterId"] = item.batchNo;
                row["ledgerId"] = item.batchNo;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable BatchViewAll()
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var Batches = IME.Batches.ToList();
            dtbl.Columns.Add("batchId");
            dtbl.Columns.Add("batchNo");
            dtbl.Columns.Add("productId");
            dtbl.Columns.Add("manufacturingDate");
            dtbl.Columns.Add("expiryDate");
            dtbl.Columns.Add("narration");
            foreach (var item in Batches)
            {
                var row = dtbl.NewRow();
                row["batchId"] = item.batchId;
                row["batchNo"] = item.batchNo;
                row["productId"] = item.batchNo;
                row["manufacturingDate"] = item.batchNo;
                row["expiryDate"] = item.batchNo;
                row["narration"] = item.batchNo;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }

        public decimal BatchIdViewByProductId(decimal decProductId)
        {
            IMEEntities db = new IMEEntities();
            decimal decBatchId = 0;
            try
            {
                decBatchId = Convert.ToDecimal(db.BatchIdViewByProductId(decProductId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decBatchId;
        }

        public decimal BatchViewByBarcode(string strBarcode)
        {
            IMEEntities IME = new IMEEntities();
            decimal decBatchId = 0;
            try
            {
                decBatchId = IME.Batches.Where(x => x.barcode == Convert.ToString(strBarcode)).FirstOrDefault().batchId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decBatchId;
        }

        public string ProductBatchBarcodeViewByBatchId(decimal decBathId)
        {
            IMEEntities db = new IMEEntities();
            string barCode = string.Empty;
            try
            {
                barCode = Convert.ToString(db.ProductBatchBarcodeViewByBatchId(decBathId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return barCode;
        }
    }
}