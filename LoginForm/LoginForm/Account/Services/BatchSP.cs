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
        public DataTable BatchNamesCorrespondingToProduct(decimal decproductId)
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var Batches = IME.Batches.Where(a => a.productId == decproductId).ToList();
            dtbl.Columns.Add("batchId");
            dtbl.Columns.Add("batchNo");
            foreach (var item in Batches)
            {
                var row = dtbl.NewRow();
                row["batchId"] = item.batchId;
                row["batchNo"] = item.batchNo;
                dtbl.Rows.Add(row);
            }
            return dtbl;
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

    }
}
