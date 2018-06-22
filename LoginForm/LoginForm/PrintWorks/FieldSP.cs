namespace PrintWorks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    internal class FieldSP : DBConnection
    {
        public void FieldsAdd(FieldInfo infoField)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FieldsAdd", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formId", SqlDbType.VarChar).Value = infoField.FormId;
                command.Parameters.Add("@fieldName", SqlDbType.VarChar).Value = infoField.FieldName;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Purchers add", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public void FieldsDelete(int formId)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FieldsDelete", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter parameter = new SqlParameter();
                command.Parameters.Add("@formId", SqlDbType.Int).Value = formId;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public void FieldsEdit(FieldInfo infoField)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FieldsEdit", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@fieldId", SqlDbType.VarChar).Value = infoField.FieldId;
                command.Parameters.Add("@formId", SqlDbType.VarChar).Value = infoField.FormId;
                command.Parameters.Add("@fieldName", SqlDbType.VarChar).Value = infoField.FieldName;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Purchers add", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public FieldInfo FieldsView(int fieldId)
        {
            FieldInfo info = new FieldInfo();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("FieldsView", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@fieldId", SqlDbType.Int).Value = fieldId;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    info.FieldId = int.Parse(reader["FieldId"].ToString());
                    info.FormId = int.Parse(reader["FormId"].ToString());
                    info.FieldName = reader["FieldName"].ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FieldsView", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return info;
        }

        public DataTable FieldsViewAll(int FormId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlDataAdapter adapter = new SqlDataAdapter("FieldsViewAll", base.sqlcon) {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add("@formId", SqlDbType.Int).Value = FormId;
                adapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "FieldsViewAll", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return dataTable;
        }
    }
}

