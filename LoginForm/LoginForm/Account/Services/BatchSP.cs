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

        public string ProductBatchBarcodeViewByBatchId(decimal decBathId)
        {
            IMEEntities db = new IMEEntities();
            string barCode = string.Empty;
            try
            {
                barCode = db.ProductBatchBarcodeViewByBatchId(decBathId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return barCode;
        }
    }
}
