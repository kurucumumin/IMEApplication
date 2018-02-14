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
    }
}
