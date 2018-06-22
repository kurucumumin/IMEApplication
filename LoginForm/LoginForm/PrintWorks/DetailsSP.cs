namespace PrintWorks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    internal class DetailsSP : DBConnection
    {
        public int DetailsAdd(DetailsInfo infoDetails)
        {
            int num = 0;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("DetailsAdd", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = infoDetails.MasterId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = infoDetails.Name;
                command.Parameters.Add("@text", SqlDbType.VarChar).Value = infoDetails.Text;
                command.Parameters.Add("@row", SqlDbType.Int).Value = infoDetails.Row;
                command.Parameters.Add("@columns", SqlDbType.Int).Value = infoDetails.Columns;
                command.Parameters.Add("@width", SqlDbType.Int).Value = infoDetails.Width;
                command.Parameters.Add("@dbf", SqlDbType.VarChar).Value = infoDetails.DBF;
                command.Parameters.Add("@DorH", SqlDbType.VarChar).Value = infoDetails.DorH;
                command.Parameters.Add("@repeat", SqlDbType.VarChar).Value = infoDetails.Repeat;
                command.Parameters.Add("@align", SqlDbType.VarChar).Value = infoDetails.Align;
                command.Parameters.Add("@repeatAll", SqlDbType.VarChar).Value = infoDetails.RepeatAll;
                command.Parameters.Add("@footerRepeatAll", SqlDbType.VarChar).Value = infoDetails.FooterRepeatAll;
                command.Parameters.Add("@textWrap", SqlDbType.VarChar).Value = infoDetails.TextWrap;
                command.Parameters.Add("@wrapLineCount", SqlDbType.VarChar).Value = infoDetails.WrapLineCount;
                command.Parameters.Add("@fieldsForExtra", SqlDbType.VarChar).Value = infoDetails.FieldsForExtra;
                command.Parameters.Add("@extraFieldName", SqlDbType.VarChar).Value = infoDetails.ExtraFieldName;
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "DetailsAdd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return num;
        }

        public int DetailsCopyAdd(DetailsInfo infoDetails)
        {
            int num = 0;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("DetailsCopyAdd", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = infoDetails.MasterId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = infoDetails.Name;
                command.Parameters.Add("@text", SqlDbType.VarChar).Value = infoDetails.Text;
                command.Parameters.Add("@row", SqlDbType.Int).Value = infoDetails.Row;
                command.Parameters.Add("@columns", SqlDbType.Int).Value = infoDetails.Columns;
                command.Parameters.Add("@width", SqlDbType.Int).Value = infoDetails.Width;
                command.Parameters.Add("@dbf", SqlDbType.VarChar).Value = infoDetails.DBF;
                command.Parameters.Add("@DorH", SqlDbType.VarChar).Value = infoDetails.DorH;
                command.Parameters.Add("@repeat", SqlDbType.VarChar).Value = infoDetails.Repeat;
                command.Parameters.Add("@align", SqlDbType.VarChar).Value = infoDetails.Align;
                command.Parameters.Add("@repeatAll", SqlDbType.VarChar).Value = infoDetails.RepeatAll;
                command.Parameters.Add("@footerRepeatAll", SqlDbType.VarChar).Value = infoDetails.FooterRepeatAll;
                command.Parameters.Add("@textWrap", SqlDbType.VarChar).Value = infoDetails.TextWrap;
                command.Parameters.Add("@wrapLineCount", SqlDbType.VarChar).Value = infoDetails.WrapLineCount;
                command.Parameters.Add("@fieldsForExtra", SqlDbType.VarChar).Value = infoDetails.FieldsForExtra;
                command.Parameters.Add("@extraFieldName", SqlDbType.VarChar).Value = infoDetails.ExtraFieldName;
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "DetailsCopyAdd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return num;
        }

        public void DetailsCopyDelete(int masterId)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("DetailsCopyDelete", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter parameter = new SqlParameter();
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = masterId;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "DetailsCopyDelete");
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public DataTable DetailsCopyViewAll(int MasterId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlDataAdapter adapter = new SqlDataAdapter("DetailsCopyViewAll", base.sqlcon) {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add("@masterId", SqlDbType.Int).Value = MasterId;
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "DetailsViewAll", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return dataTable;
        }

        public void DetailsDelete(int masterId)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("DetailsDelete", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter parameter = new SqlParameter();
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = masterId;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "DetailsDelete");
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public void DetailsEdit(DetailsInfo infoDetails)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("DetailsEdit", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@detailsId", SqlDbType.Int).Value = infoDetails.DetailsId;
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = infoDetails.MasterId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = infoDetails.Name;
                command.Parameters.Add("@text", SqlDbType.Bit).Value = infoDetails.Text;
                command.Parameters.Add("@row", SqlDbType.Bit).Value = infoDetails.Row;
                command.Parameters.Add("@columns", SqlDbType.Int).Value = infoDetails.Columns;
                command.Parameters.Add("@width", SqlDbType.Int).Value = infoDetails.Width;
                command.Parameters.Add("@dbf", SqlDbType.Int).Value = infoDetails.DBF;
                command.Parameters.Add("@DorH", SqlDbType.VarChar).Value = infoDetails.DorH;
                command.Parameters.Add("@repeat", SqlDbType.Int).Value = infoDetails.Repeat;
                command.Parameters.Add("@align", SqlDbType.Int).Value = infoDetails.Align;
                command.Parameters.Add("@repeatAll", SqlDbType.Int).Value = infoDetails.RepeatAll;
                command.Parameters.Add("@footerRepeatAll", SqlDbType.Int).Value = infoDetails.FooterRepeatAll;
                command.Parameters.Add("@textWrap", SqlDbType.VarChar).Value = infoDetails.TextWrap;
                command.Parameters.Add("@wrapLineCount", SqlDbType.VarChar).Value = infoDetails.WrapLineCount;
                command.Parameters.Add("@fieldsForExtra", SqlDbType.VarChar).Value = infoDetails.FieldsForExtra;
                command.Parameters.Add("@extraFieldName", SqlDbType.VarChar).Value = infoDetails.ExtraFieldName;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "DetailsEdit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public DataTable DetailsViewAll(int MasterId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlDataAdapter adapter = new SqlDataAdapter("DetailsViewAll", base.sqlcon) {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add("@masterId", SqlDbType.Int).Value = MasterId;
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "DetailsViewAll", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return dataTable;
        }
    }
}

