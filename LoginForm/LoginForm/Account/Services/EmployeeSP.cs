using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
namespace LoginForm.Account.Services
{
    class EmployeeSP
    {

        public DataTable SalesmanSearch(String strEmployeeCode, String strEmployeeName, String strPhoneNumber, String strMobileNumber, String strIsActive)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl.No", typeof(decimal));
            dtbl.Columns["Sl.No"].AutoIncrement = true;
            dtbl.Columns["Sl.No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl.No"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.SalesmanSearch(strEmployeeCode, strEmployeeName, strMobileNumber, strPhoneNumber, strIsActive);

                dtbl.Columns.Add("WorkerID");
                dtbl.Columns.Add("UserName");
                dtbl.Columns.Add("NameLastName");
                dtbl.Columns.Add("Phone");
                dtbl.Columns.Add("mobileNumber");
                dtbl.Columns.Add("isActive");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["WorkerID"] = item.WorkerID;
                    row["UserName"] = item.UserName;
                    row["NameLastName"] = item.NameLastName;
                    row["Phone"] = item.Phone;
                    row["mobileNumber"] = item.mobileNumber;
                    row["isActive"] = item.isActive;


                    dtbl.Rows.Add(row);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public Worker SalesmanViewSpecificFeilds(decimal employeeId)
        {
            Worker infoemployee = new Worker();
            IMEEntities IME = new IMEEntities();
            try
            {
               var a= IME.SalesmanViewSpecificFeilds(employeeId).FirstOrDefault();

                infoemployee.WorkerID = a.WorkerID;
                infoemployee.UserName = a.UserName;
                infoemployee.NameLastName = a.NameLastName;
                infoemployee.Email = a.email;
                infoemployee.Phone = a.Phone;
                infoemployee.mobileNumber = a.mobileNumber;
                infoemployee.address= a.address;
                infoemployee.narration = a.narration;
                infoemployee.isActive = a.isActive;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return infoemployee;
        }

        public string SalesmanGetDesignationId()
        {
            IMEEntities IME = new IMEEntities();
            string strdesignationId = string.Empty;
            try
            {
                strdesignationId=IME.SalesManGetDesignationId().ToString();
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return strdesignationId;
        }

        public bool SalesmanEdit(Worker employeeinfo)
        {
            IMEEntities IME = new IMEEntities();
            bool isEdit = false;
            decimal count = 0;
            try
            {
                var obj = IME.SalesmanEdit(
                    employeeinfo.WorkerID,
                    employeeinfo.UserName,
                    employeeinfo.NameLastName,
                    employeeinfo.Email,
                    employeeinfo.Phone,
                    employeeinfo.mobileNumber,
                    employeeinfo.address,
                    employeeinfo.narration,
                    Convert.ToBoolean(employeeinfo.isActive)).ToString();
                if (obj != null)
                {
                    count = obj.Count();
                    if (count > 0)
                    {
                        isEdit = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return isEdit;
        }

        public decimal SalesmanCheckReferenceAndDelete(decimal decEmployeeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decReturnValue = 0;
            try
            {
                decReturnValue= IME.SalesmanCheckReferenceAndDelete(decEmployeeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReturnValue;
        }

        public void EmployeeDeleteCheck(decimal EmployeeId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.EmployeeDelete(EmployeeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool EmployeeCodeCheckExistance(String strEmployeeCode, decimal decEmployeeId)
        {
            IMEEntities IME = new IMEEntities();
            bool isActive = false;
            decimal count = 0;
            try
            {
               var obj= IME.EmployeeCodeCheckExistance(strEmployeeCode, decEmployeeId).ToList();

                if (obj != null)
                {
                    count = obj.Count();
                    if (count > 0)
                    {
                        isActive = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }

            return isActive;
        }

        public decimal EmployeeAddWithReturnIdentity(Worker a)
        {
            IMEEntities IME = new IMEEntities();
            decimal decEmployee = -1;
            decimal count = 0;
            try
            {
                var obj=IME.EmployeeForTakingEmployeeId(
                    a.designationId,
                    a.NameLastName,
                    a.UserName,
                    a.dob,
                    a.maritalStatus,
                    a.gender,
                    a.qualification,
                    a.address,
                    a.Phone,
                    a.mobileNumber,
                    a.Email,
                    a.joiningDate,
                    a.terminationDate,
                    a.isActive,
                    a.narration,
                    a.bloodGroup,
                    a.passportNo,
                    a.passportExpiryDate,
                    a.labourCardNumber,
                    a.labourCardExpiryDate,
                    a.visaNumber,
                    a.visaExpiryDate,
                    a.salaryType,
                    a.dailyWage,
                    a.bankName,
                    a.branchName,
                    a.bankAccountNumber,
                    a.branchCode,
                    a.panNumber,
                    a.pfNumber,
                    a.esiNumber,
                    a.defaultPackageId).ToList();

                if (obj != null)
                {
                    count = obj.Count();
                    if (count > 0)
                    {
                        decEmployee = 1;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decEmployee;
        }

        public DataTable EmployeeViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();

            dtbl.Columns.Add("WorkerID");
            dtbl.Columns.Add("designationId");
            dtbl.Columns.Add("NameLastName");
            dtbl.Columns.Add("dob");
            dtbl.Columns.Add("maritalStatus");
            dtbl.Columns.Add("gender");
            dtbl.Columns.Add("qualification");
            dtbl.Columns.Add("address");
            dtbl.Columns.Add("mobileNumber");
            dtbl.Columns.Add("email");
            dtbl.Columns.Add("terminationDate");
            dtbl.Columns.Add("isActive");
            dtbl.Columns.Add("narration");
            dtbl.Columns.Add("passportNo");
            dtbl.Columns.Add("bloodGroup");
            dtbl.Columns.Add("passportExpiryDate");
            dtbl.Columns.Add("labourCardNumber");
            dtbl.Columns.Add("labourCardExpiryDate");
            dtbl.Columns.Add("visaNumber");
            dtbl.Columns.Add("visaExpiryDate");
            dtbl.Columns.Add("salaryType");
            dtbl.Columns.Add("dailyWage");
            dtbl.Columns.Add("bankName");
            dtbl.Columns.Add("branchName");
            dtbl.Columns.Add("bankAccountNumber");
            dtbl.Columns.Add("branchCode");
            dtbl.Columns.Add("panNumber");
            dtbl.Columns.Add("pfNumber");
            dtbl.Columns.Add("esiNumber");
            dtbl.Columns.Add("defaultPackageId");
            dtbl.Columns.Add("dailyWage");
            foreach (var item in IME.EmployeeViewAll())
            {
                var row = dtbl.NewRow();

                row["WorkerID"] = item.WorkerID;
                row["designationId"] = item.designationId;
                row["NameLastName"] = item.NameLastName;
                row["dob"] = item.dob;
                row["maritalStatus"] = item.maritalStatus;
                row["gender"] = item.gender;
                row["qualification"] = item.qualification;
                row["address"] = item.address;
                row["mobileNumber"] = item.mobileNumber;
                row["email"] = item.email;
                row["terminationDate"] = item.terminationDate;
                row["isActive"] = item.isActive;
                row["narration"] = item.narration;
                row["passportNo"] = item.passportNo;
                row["bloodGroup"] = item.bloodGroup;
                row["passportExpiryDate"] = item.passportExpiryDate;
                row["labourCardNumber"] = item.labourCardNumber;
                row["labourCardExpiryDate"] = item.labourCardExpiryDate;
                row["visaNumber"] = item.visaNumber;
                row["visaExpiryDate"] = item.visaExpiryDate;
                row["salaryType"] = item.salaryType;
                row["dailyWage"] = item.dailyWage;
                row["bankName"] = item.bankName;
                row["branchName"] = item.branchName;
                row["bankAccountNumber"] = item.bankAccountNumber;
                row["branchCode"] = item.branchCode;
                row["panNumber"] = item.panNumber;
                row["pfNumber"] = item.pfNumber;
                row["esiNumber"] = item.esiNumber;
                row["dailyWage"] = item.dailyWage;


                dtbl.Rows.Add(row);
            }


            return dtbl;
        }

        public void EmployeePackageEdit(decimal decEmployeeId, decimal decPackageId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.EmployeePackageEdit(decEmployeeId, decPackageId);            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          }
          public DataTable EmployeeViewForPaySlip()
          {
              DataTable dtbl = new DataTable();
              IMEEntities IME = new IMEEntities();
              try
              {
                  var adaptor = IME.EmployeeViewForPaySlip();

                  dtbl.Columns.Add("WorkerID");
                  dtbl.Columns.Add("NameLastName");

                  foreach (var item in adaptor)
                  {
                      var row = dtbl.NewRow();

                      row["WorkerID"] = item.WorkerID;
                      row["NameLastName"] = item.NameLastName;

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
