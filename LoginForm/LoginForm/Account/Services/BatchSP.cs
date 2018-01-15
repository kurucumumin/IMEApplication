using LoginForm.DataSet;
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
        public string ProductBatchBarcodeViewByBatchId(decimal decBathId)
        {
            string barCode = string.Empty;
            if (IME.Batches.Where(a => a.batchId == decBathId).FirstOrDefault() != null) barCode = IME.Batches.Where(a => a.batchId == decBathId).FirstOrDefault().barcode;
            return barCode;
        }

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

            dt.Columns.Add("batchId");
            dt.Columns.Add("batchNo");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["batchId"] = item.batchId;
                row["batchNo"] = item.batchNo;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable BatchViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from b in IME.Batches
                           select new
                           {
                               b.batchId,
                               b.batchNo,
                               b.productId,
                               b.manufacturingDate,
                               b.expiryDate,b.narration
                           }).ToList();

            dt.Columns.Add("batchId");
            dt.Columns.Add("batchNo");
            dt.Columns.Add("productId");
            dt.Columns.Add("manufacturingDate");
            dt.Columns.Add("expiryDate");
            dt.Columns.Add("narration");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["batchId"] = item.batchId;
                row["batchNo"] = item.batchNo;
                row["productId"] = item.productId;
                row["manufacturingDate"] = item.manufacturingDate;
                row["expiryDate"] = item.expiryDate;
                row["narration"] = item.narration;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
