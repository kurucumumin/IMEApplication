namespace PrintWorks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    internal class MasterSP : DBConnection
    {
        public DataTable FieldsViewAll(int fieldId)
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
                adapter.SelectCommand.Parameters.Add("@formId", SqlDbType.Int).Value = fieldId;
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

        public DataTable FormViewAll()
        {
            DataTable dataTable = new DataTable();
            try
            {
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

        public int MasterAdd(MasterInfo infoMaster)
        {
            int num = 0;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterAdd", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formName", SqlDbType.Int).Value = infoMaster.FormName;
                command.Parameters.Add("@isTwoLineForHedder", SqlDbType.Bit).Value = infoMaster.IsTwoLineForHedder;
                command.Parameters.Add("@isTwoLineForDetails", SqlDbType.Bit).Value = infoMaster.IsTwoLineForDetails;
                command.Parameters.Add("@pageSize1", SqlDbType.Int).Value = infoMaster.PageSize1;
                command.Parameters.Add("@pageSizeOther", SqlDbType.Int).Value = infoMaster.PageSizeOther;
                command.Parameters.Add("@blankLneForFooter", SqlDbType.Int).Value = infoMaster.BlankLneForFooter;
                command.Parameters.Add("@footerLocation", SqlDbType.VarChar).Value = infoMaster.FooterLocation;
                command.Parameters.Add("@lineCountBetweenTwo", SqlDbType.Int).Value = infoMaster.LineCountBetweenTwo;
                command.Parameters.Add("@pitch", SqlDbType.VarChar).Value = infoMaster.Pitch;
                command.Parameters.Add("@condensed", SqlDbType.VarChar).Value = infoMaster.Condensed;
                command.Parameters.Add("@lineCountAfterPrint", SqlDbType.VarChar).Value = infoMaster.LineCountAfterPrint;
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterAdd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return num;
        }

        public void MasterCopyAdd(MasterInfo infoMaster)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterCopyAdd", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = infoMaster.MasterId;
                command.Parameters.Add("@formName", SqlDbType.Int).Value = infoMaster.FormName;
                command.Parameters.Add("@isTwoLineForHedder", SqlDbType.Bit).Value = infoMaster.IsTwoLineForHedder;
                command.Parameters.Add("@isTwoLineForDetails", SqlDbType.Bit).Value = infoMaster.IsTwoLineForDetails;
                command.Parameters.Add("@pageSize1", SqlDbType.Int).Value = infoMaster.PageSize1;
                command.Parameters.Add("@pageSizeOther", SqlDbType.Int).Value = infoMaster.PageSizeOther;
                command.Parameters.Add("@blankLneForFooter", SqlDbType.Int).Value = infoMaster.BlankLneForFooter;
                command.Parameters.Add("@footerLocation", SqlDbType.VarChar).Value = infoMaster.FooterLocation;
                command.Parameters.Add("@lineCountBetweenTwo", SqlDbType.Int).Value = infoMaster.LineCountBetweenTwo;
                command.Parameters.Add("@pitch", SqlDbType.VarChar).Value = infoMaster.Pitch;
                command.Parameters.Add("@condensed", SqlDbType.VarChar).Value = infoMaster.Condensed;
                command.Parameters.Add("@lineCountAfterPrint", SqlDbType.VarChar).Value = infoMaster.LineCountAfterPrint;
                command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterCopyAdd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public void MasterCopyEdit(MasterInfo infoMaster)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterCopyEdit", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = infoMaster.MasterId;
                command.Parameters.Add("@formName", SqlDbType.Int).Value = infoMaster.FormName;
                command.Parameters.Add("@isTwoLineForHedder", SqlDbType.Bit).Value = infoMaster.IsTwoLineForHedder;
                command.Parameters.Add("@isTwoLineForDetails", SqlDbType.Bit).Value = infoMaster.IsTwoLineForDetails;
                command.Parameters.Add("@pageSize1", SqlDbType.Int).Value = infoMaster.PageSize1;
                command.Parameters.Add("@pageSizeOther", SqlDbType.Int).Value = infoMaster.PageSizeOther;
                command.Parameters.Add("@blankLneForFooter", SqlDbType.Int).Value = infoMaster.BlankLneForFooter;
                command.Parameters.Add("@footerLocation", SqlDbType.VarChar).Value = infoMaster.FooterLocation;
                command.Parameters.Add("@lineCountBetweenTwo", SqlDbType.Int).Value = infoMaster.LineCountBetweenTwo;
                command.Parameters.Add("@pitch", SqlDbType.VarChar).Value = infoMaster.Pitch;
                command.Parameters.Add("@condensed", SqlDbType.VarChar).Value = infoMaster.Condensed;
                command.Parameters.Add("@lineCountAfterPrint", SqlDbType.VarChar).Value = infoMaster.LineCountAfterPrint;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterCopyEdit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public bool MasterCopyExistCheck(int masterId)
        {
            bool flag = false;
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterCopyExistCheck", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = masterId;
                object obj2 = command.ExecuteScalar();
                if (obj2 != null)
                {
                    flag = bool.Parse(obj2.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterCopyExistCheck", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return flag;
        }

        public MasterInfo MasterCopyViewByFormName(int formName)
        {
            MasterInfo info = new MasterInfo();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterCopyViewByFormName", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formName", SqlDbType.Int).Value = formName;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    info.MasterId = int.Parse(reader["masterId"].ToString());
                    info.FormName = int.Parse(reader["formName"].ToString());
                    info.IsTwoLineForHedder = bool.Parse(reader["isTwoLineForHedder"].ToString());
                    info.IsTwoLineForDetails = bool.Parse(reader["isTwoLineForDetails"].ToString());
                    info.PageSize1 = int.Parse(reader["pageSize1"].ToString());
                    info.PageSizeOther = int.Parse(reader["pageSizeOther"].ToString());
                    info.BlankLneForFooter = int.Parse(reader["blankLneForFooter"].ToString());
                    info.FooterLocation = reader["footerLocation"].ToString();
                    info.LineCountBetweenTwo = int.Parse(reader["lineCountBetweenTwo"].ToString());
                    info.Pitch = reader["pitch"].ToString();
                    info.Condensed = reader["condensed"].ToString();
                    info.LineCountAfterPrint = int.Parse(reader["lineCountAfterPrint"].ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterViewByFormName", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return info;
        }

        public void MasterDelate(decimal MasterId)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterDelete", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = MasterId;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterDelate");
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public void MasterEdit(MasterInfo infoMaster)
        {
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterEdit", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@masterId", SqlDbType.Int).Value = infoMaster.MasterId;
                command.Parameters.Add("@formName", SqlDbType.Int).Value = infoMaster.FormName;
                command.Parameters.Add("@isTwoLineForHedder", SqlDbType.Bit).Value = infoMaster.IsTwoLineForHedder;
                command.Parameters.Add("@isTwoLineForDetails", SqlDbType.Bit).Value = infoMaster.IsTwoLineForDetails;
                command.Parameters.Add("@pageSize1", SqlDbType.Int).Value = infoMaster.PageSize1;
                command.Parameters.Add("@pageSizeOther", SqlDbType.Int).Value = infoMaster.PageSizeOther;
                command.Parameters.Add("@blankLneForFooter", SqlDbType.Int).Value = infoMaster.BlankLneForFooter;
                command.Parameters.Add("@footerLocation", SqlDbType.VarChar).Value = infoMaster.FooterLocation;
                command.Parameters.Add("@lineCountBetweenTwo", SqlDbType.Int).Value = infoMaster.LineCountBetweenTwo;
                command.Parameters.Add("@pitch", SqlDbType.VarChar).Value = infoMaster.Pitch;
                command.Parameters.Add("@condensed", SqlDbType.VarChar).Value = infoMaster.Condensed;
                command.Parameters.Add("@lineCountAfterPrint", SqlDbType.VarChar).Value = infoMaster.LineCountAfterPrint;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterEdit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
        }

        public MasterInfo MasterViewByFormName(int formName)
        {
            MasterInfo info = new MasterInfo();
            try
            {
                if (base.sqlcon.State == ConnectionState.Closed)
                {
                    base.sqlcon.Open();
                }
                SqlCommand command = new SqlCommand("MasterViewByFormName", base.sqlcon) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@formName", SqlDbType.Int).Value = formName;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    info.MasterId = int.Parse(reader["masterId"].ToString());
                    info.FormName = int.Parse(reader["formName"].ToString());
                    info.IsTwoLineForHedder = bool.Parse(reader["isTwoLineForHedder"].ToString());
                    info.IsTwoLineForDetails = bool.Parse(reader["isTwoLineForDetails"].ToString());
                    info.PageSize1 = int.Parse(reader["pageSize1"].ToString());
                    info.PageSizeOther = int.Parse(reader["pageSizeOther"].ToString());
                    info.BlankLneForFooter = int.Parse(reader["blankLneForFooter"].ToString());
                    info.FooterLocation = reader["footerLocation"].ToString();
                    info.LineCountBetweenTwo = int.Parse(reader["lineCountBetweenTwo"].ToString());
                    info.Pitch = reader["pitch"].ToString();
                    info.Condensed = reader["condensed"].ToString();
                    info.LineCountAfterPrint = int.Parse(reader["lineCountAfterPrint"].ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "MasterViewByFormName", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                base.sqlcon.Close();
            }
            return info;
        }
    }
}

