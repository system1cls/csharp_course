namespace App.practice3;

public class UserActionStatRequest
{
    public DateTime StartDate { get; set; }  
    public DateTime EndDate { get; set; }  
    public DateGroupTypes DateGroupType { get; set; }  

    public UserActionStatRequest() {}

    public UserActionStatRequest(DateTime date, DateTime endData, DateGroupTypes dateGroupType) 
    {
        StartDate = date;
        EndDate = endData;
        DateGroupType = dateGroupType;
    }
}