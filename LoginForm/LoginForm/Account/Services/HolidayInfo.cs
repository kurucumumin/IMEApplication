

using System;    
using System.Collections.Generic;    
using System.Text;    
//<summary>    
//Summary description for HolidayInfo    
//</summary>    
namespace LoginForm    
{    
class HolidayInfo    
{    
    private decimal _holidayId;    
    private DateTime _date;    
    private string _holidayName;    
    private string _narration;    
    
    public decimal HolidayId    
    {    
        get { return _holidayId; }    
        set { _holidayId = value; }    
    }    
    public DateTime Date    
    {    
        get { return _date; }    
        set { _date = value; }    
    }    
    public string HolidayName    
    {    
        get { return _holidayName; }    
        set { _holidayName = value; }    
    }    
    public string Narration    
    {    
        get { return _narration; }    
        set { _narration = value; }    
    }      
    
}    
}
