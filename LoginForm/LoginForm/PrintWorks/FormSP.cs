namespace PrintWorks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    internal class FormSP : DBConnection
    {
        public int FormAdd(FormInfo infoForm)
        {
            int num = 0;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FormAdd", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formName", SqlDbType.VarChar).Value = infoForm.FormName;
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FormAdd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return num;
        }

        public bool FormDelete(int formId)
        {
            bool flag = false;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FormDelete", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter parameter = new SqlParameter();
                command.Parameters.Add("@formId", SqlDbType.Int).Value = formId;
                flag = bool.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "FormDelete");
            }
            finally
            {
                base.sqlcon.Close();
            }
            return flag;
        }

        public bool FormEdit(FormInfo infoForm)
        {
            bool flag = false;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FormEdit", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formId", SqlDbType.VarChar).Value = infoForm.FormId;
                command.Parameters.Add("@formName", SqlDbType.VarChar).Value = infoForm.FormName;
                flag = bool.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FormEdit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return flag;
        }

        public void FormEditFull(FormInfo infoForm)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FormEditFull", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formId", SqlDbType.VarChar).Value = infoForm.FormId;
                command.Parameters.Add("@formName", SqlDbType.VarChar).Value = infoForm.FormName;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FormEditFull", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public FormInfo FormView(int formId)
        {
            FormInfo info = new FormInfo();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FormView", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formId", SqlDbType.Int).Value = formId;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    info.FormId = int.Parse(reader["formId"].ToString());
                    info.FormName = reader["formName"].ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FormView", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return info;
        }

        public DataTable FormViewAll()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable.Columns.Add("slNo", typeof(int));
                dataTable.Columns["slNo"].AutoIncrement = true;
                dataTable.Columns["slNo"].AutoIncrementSeed = 1L;
                dataTable.Columns["slNo"].AutoIncrementStep = 1L;
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                new SqlDataAdapter("FormViewAll", base.sqlcon) { SelectCommand = { CommandType = CommandType.StoredProcedure } }.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FormViewAll", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return dataTable;
        }
    }
}

