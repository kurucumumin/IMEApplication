using System;    
using System.Collections.Generic;    
using System.Text;    

namespace LoginForm
{    
class DailyAttendanceDetailsInfo    
{    
    private decimal _dailyAttendanceDetailsId;    
    private decimal _dailyAttendanceMasterId;    
    private int _WorkerID;    
    private string _status;    
    private string _narration;       
    
    public decimal DailyAttendanceDetailsId    
    {    
        get { return _dailyAttendanceDetailsId; }    
        set { _dailyAttendanceDetailsId = value; }    
    }    
    public decimal DailyAttendanceMasterId    
    {    
        get { return _dailyAttendanceMasterId; }    
        set { _dailyAttendanceMasterId = value; }    
    }    
    public int WorkerID    
    {    
        get { return _WorkerID; }    
        set { _WorkerID= value; }    
    }    
    public string Status    
    {    
        get { return _status; }    
        set { _status = value; }    
    }    
    public string Narration    
    {    
        get { return _narration; }    
        set { _narration = value; }    
    }    
   
    
}    
}
