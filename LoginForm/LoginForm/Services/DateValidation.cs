
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using LoginForm.Services;
using LoginForm.DataSet;
namespace LoginForm.Services
{
    class DateValidation
    {
        string format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        DateTime CurrDate;
        TextBox text;
        /// <summary>
        /// Function for date validation
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool DateValidationFunction(TextBox txt)
        {
            IMEEntities IME = new IMEEntities();
            bool isValid = true;
            string option = string.Empty;
            string[] date = new string[50];
            this.text = txt;
            try
            {
                foreach (char ch in txt.Text)
                {
                    if (ch == '.')
                    {
                        option = ".";
                    }
                    else if (ch == ',')
                    {
                        option = ",";
                    }
                    else if (ch == '-')
                    {
                        option = "-";
                    }
                    else if (ch == '+')
                    {
                        option = "+";
                    }
                    else if (ch == '*')
                    {
                        option = "*";
                    }
                    else if (ch == '/')
                    {
                        option = "/";
                    }
                    else if (ch == ' ')
                    {
                        option = " ";
                    }
                }
                if (option == "")
                {
                    string s = txt.Text + "/";
                    date = s.Split('/');
                }
                if (option == ".")
                {
                    date = txt.Text.Split('.');
                }
                else if (option == ",")
                {
                    date = txt.Text.Split(',');
                }
                else if (option == "-")
                {
                    date = txt.Text.Split('-');
                }
                else if (option == "+")
                {
                    date = txt.Text.Split('+');
                }
                else if (option == "*")
                {
                    date = txt.Text.Split('*');
                }
                else if (option == "/")
                {
                    date = txt.Text.Split('/');
                }
                else if (option == " ")
                {
                    date = txt.Text.Split(' ');
                }
                if (date.Length == 1)
                {
                    string formatoption = SystemFormat();
                    if (formatoption == "M")
                    {
                        CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                    }
                    else if (formatoption == "d")
                    {
                        CurrDate = DateTime.Parse(date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                    }
                    else if (formatoption == "y")
                    {
                        CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString());
                    }
                    isValid = isToday(isValid);
                }
                else if (date.Length == 2)
                {
                    if (date[1].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString());
                        }
                        isValid = isToday(isValid);
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        } isValid = isToday(isValid);
                    }
                }
                else if (date.Length == 3)
                {
                    if (date[2].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                        isValid = isToday(isValid);
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(date[2].ToString() + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                        isValid = isToday(isValid);
                    }
                }
                else
                {
                    isValid = false;
                    txt.Text = "";
                }
            }
            catch (Exception)
            {
                isValid = false;
                txt.Text = "";
            }
            return isValid;
        }
        /// <summary>
        /// Public to check current date format
        /// </summary>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public bool isToday(bool isValid)
        {
            IMEEntities IME = new IMEEntities();
            if (CurrDate >= Utils.getManagement().FinancialYear.fromDate && CurrDate <= Utils.getManagement().FinancialYear.toDate)
            {
                if (CurrDate == Convert.ToDateTime(IME.CurrentDate().First()).Date)
                {
                    text.ForeColor = Color.IndianRed;
                    text.Text = CurrDate.ToString("dd-MMM-yyyy");
                }
                else
                {
                    text.ForeColor = Color.Black;
                    text.Text = CurrDate.ToString("dd-MMM-yyyy");
                }
            }
            else
            {
                isValid = false;
                text.Text = "";
            }
            return isValid;
        }
        /// <summary>
        /// Date validation for manufacturing and expiry date
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool DateValidationFunctionMFDEXPD(TextBox txt)
        {
            IMEEntities IME = new IMEEntities();
            bool isValid = true;
            string option = string.Empty;
            string[] date = new string[50];
            this.text = txt;
            try
            {
                foreach (char ch in txt.Text)
                {
                    if (ch == '.')
                    {
                        option = ".";
                    }
                    else if (ch == ',')
                    {
                        option = ",";
                    }
                    else if (ch == '-')
                    {
                        option = "-";
                    }
                    else if (ch == '+')
                    {
                        option = "+";
                    }
                    else if (ch == '*')
                    {
                        option = "*";
                    }
                    else if (ch == '/')
                    {
                        option = "/";
                    }
                    else if (ch == ' ')
                    {
                        option = " ";
                    }
                }
                if (option == "")
                {
                    string s = txt.Text + "/";
                    date = s.Split('/');
                }
                if (option == ".")
                {
                    date = txt.Text.Split('.');
                }
                else if (option == ",")
                {
                    date = txt.Text.Split(',');
                }
                else if (option == "-")
                {
                    date = txt.Text.Split('-');
                }
                else if (option == "+")
                {
                    date = txt.Text.Split('+');
                }
                else if (option == "*")
                {
                    date = txt.Text.Split('*');
                }
                else if (option == "/")
                {
                    date = txt.Text.Split('/');
                }
                else if (option == " ")
                {
                    date = txt.Text.Split(' ');
                }
                if (date.Length == 1)
                {
                    string formatoption = SystemFormat();
                    if (formatoption == "M")
                    {
                        CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                    }
                    else if (formatoption == "d")
                    {
                        CurrDate = DateTime.Parse(date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                    }
                    else if (formatoption == "y")
                    {
                        CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString());
                    }
                    isValid = isTodaY(isValid);
                }
                else if (date.Length == 2)
                {
                    if (date[1].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Month + " / " + date[0].ToString());
                        }
                        isValid = isTodaY(isValid);
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        } isValid = isTodaY(isValid);
                    }
                }
                else if (date.Length == 3)
                {
                    if (date[2].ToString() == "")
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + Convert.ToDateTime(IME.CurrentDate().First()).Date.Year);
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(Convert.ToDateTime(IME.CurrentDate().First()).Date.Year + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                        isValid = isTodaY(isValid);
                    }
                    else
                    {
                        string formatoption = SystemFormat();
                        if (formatoption == "M")
                        {
                            CurrDate = DateTime.Parse(date[1].ToString() + " / " + date[0].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "d")
                        {
                            CurrDate = DateTime.Parse(date[0].ToString() + " / " + date[1].ToString() + " / " + date[2].ToString());
                        }
                        else if (formatoption == "y")
                        {
                            CurrDate = DateTime.Parse(date[2].ToString() + " / " + date[1].ToString() + " / " + date[0].ToString());
                        }
                        isValid = isTodaY(isValid);
                    }
                }
                else
                {
                    isValid = false;
                    txt.Text = "";
                }
            }
            catch (Exception)
            {
                isValid = false;
                txt.Text = "";
            }
            return isValid;
        }
        /// <summary>
        /// Function to check current date
        /// </summary>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public bool isTodaY(bool isValid)
        {
            IMEEntities IME = new IMEEntities();
            if (CurrDate == Convert.ToDateTime(IME.CurrentDate().First()).Date)
            {
                text.ForeColor = Color.IndianRed;
                text.Text = CurrDate.ToString("dd-MMM-yyyy");
            }
            else
            {
                text.ForeColor = Color.Black;
                text.Text = CurrDate.ToString("dd-MMM-yyyy");
            }
            return isValid;
        }
        /// <summary>
        /// Function for system format date
        /// </summary>
        /// <returns></returns>
        public string SystemFormat()
        {
            string formatoption = string.Empty;
            foreach (char ch in format)
            {
                if (ch == 'M')
                {
                    formatoption = "M";
                    break;
                }
                else if (ch == 'd')
                {
                    formatoption = "d";
                    break;
                }
                else if (ch == 'y')
                {
                    formatoption = "y";
                    break;
                }
            }
            return formatoption;
        }
    }
}
