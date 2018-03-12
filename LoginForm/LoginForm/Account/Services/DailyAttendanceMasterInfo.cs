using System;    
using System.Collections.Generic;    
using System.Text;    
 
namespace LoginForm    
{    
class DailyAttendanceMasterInfo    
{    
    private decimal _dailyAttendanceMasterId;    
    private DateTime _date;    
    private string _narration;    
    
    public decimal DailyAttendanceMasterId    
    {    
        get { return _dailyAttendanceMasterId; }    
        set { _dailyAttendanceMasterId = value; }    
    }    
    public DateTime Date    
    {    
        get { return _date; }    
        set { _date = value; }    
    }    
    public string Narration    
    {    
        get { return _narration; }    
        set { _narration = value; }    
    }    
    
}    
}
