namespace App.practice3;

public class UserActionStatResponse
{
    public List<UserActionStatItem> UserActionStat { get; set; }

    public UserActionStatResponse()
    {
    }

    public UserActionStatResponse(List<UserActionStatItem> userActionStat)
    {
        UserActionStat = userActionStat;
    }
}