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
    class PayHeadSP
    {
        public DataTable PayHeadGetSearch(string a)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Slno:", typeof(int));
            dtbl.Columns["Slno:"].AutoIncrement = true;
            dtbl.Columns["Slno:"].AutoIncrementSeed = 1;
            dtbl.Columns["Slno:"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from p in IME.PayHeads.Where(x => x.payHeadName.Contains(a))
                               select new
                               {
                                   p.payHeadId,
                                   p.payHeadName,
                                   p.type,
                                   p.narration
                               }).ToList();

                dtbl.Columns.Add("payHeadId");
                dtbl.Columns.Add("payHeadName");
                dtbl.Columns.Add("type");
                dtbl.Columns.Add("narration");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["payHeadId"] = item.payHeadId;
                    row["payHeadName"] = item.payHeadName;
                    row["type"] = item.type;
                    row["narration"] = item.narration;
                    

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }

        public DataTable PayHeadGetSearchAll(string a)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Slno:", typeof(int));
            dtbl.Columns["Slno:"].AutoIncrement = true;
            dtbl.Columns["Slno:"].AutoIncrementSeed = 1;
            dtbl.Columns["Slno:"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.PayHeads.ToList();

                dtbl.Columns.Add("payHeadId");
                dtbl.Columns.Add("payHeadName");
                dtbl.Columns.Add("type");
                dtbl.Columns.Add("narration");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["payHeadId"] = item.payHeadId;
                    row["payHeadName"] = item.payHeadName;
                    row["type"] = item.type;
                    row["narration"] = item.narration;


                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }

        public DataTable PayHeadViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.PayHeadViewAll().ToList();

                dtbl.Columns.Add("payHeadId");
                dtbl.Columns.Add("payHeadName");
                dtbl.Columns.Add("type");
                dtbl.Columns.Add("narration");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["payHeadId"] = item.payHeadId;
                    row["payHeadName"] = item.payHeadName;
                    row["type"] = item.type;
                    row["narration"] = item.narration;


                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
