using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class StockPostingSP
    {

        public decimal StockCheckForProductSale(string decProductId, decimal decBatchId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decStock = 0;
            try
            {

                decStock = Convert.ToDecimal(IME.StockCheckForProductSale(decProductId, decBatchId));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decStock;
        }

        public void StockPostingDeleteByVoucherTypeAndVoucherNo(string strVoucherNo, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.StockPostingDeleteByVoucherTypeAndVoucherNo(strVoucherNo, decVoucherTypeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal StockPostingAdd(StockPosting stockpostinginfo)
        {
            IMEEntities IME = new IMEEntities();
            StockPosting sp = stockpostinginfo;
            decimal decProductId = 0;
            try
            {
                IME.StockPostings.Add(sp);
                IME.SaveChanges();
                decProductId = sp.stockPostingId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decProductId;
        }

        public decimal StockPostingDeleteByagainstVoucherTypeIdAndagainstVoucherNoAndVoucherNoAndVoucherType(decimal decAgainstVoucherTypeId, string strAgainstVoucherNo, string strVoucherNo, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decResult = 0;
            try
            {
                decResult = IME.StockPostingDeleteByagainstVoucherTypeIdAndagainstVoucherNoAndVoucherNoAndVoucherType(decAgainstVoucherTypeId,strAgainstVoucherNo,strVoucherNo,decVoucherTypeId);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decResult;
        }

        public decimal BatchViewByProductId(string decProductId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decStock = 0;
            try
            {
                decStock= Convert.ToDecimal(IME.BatchViewByProductId(decProductId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decStock;
        }
    }
}
