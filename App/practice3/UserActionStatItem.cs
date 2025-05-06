namespace App.practice3;

public class UserActionStatItem
{
    public DateTime StartDate { get; set; }  
    public DateTime EndDate { get; set; }  
    public Dictionary<ActionTypes, int> ActionMetrics { get; set; }

    public UserActionStatItem()
    {
    }

    public UserActionStatItem(DateTime startDate, DateTime endDate, Dictionary<ActionTypes, int> actionMetrics)
    {
        StartDate = startDate;
        EndDate = endDate;
        ActionMetrics = actionMetrics;
    }
}