namespace App.practice3;

public class UserActionItem
{
    public DateTime Date { get; set; }  
    public ActionTypes Action { get; set; }  
    public int Count { get; set; }

    public UserActionItem()
    {
    }

    public UserActionItem(DateTime date, ActionTypes action, int count)
    {
        Date = date;
        Action = action;
        Count = count;
    }
    
}