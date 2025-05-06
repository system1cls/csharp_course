namespace App.practice3;

public class UserSatProvider
{
    public UserActionStatResponse GetUserActionStat(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        if (request == null) return null;
        return request.DateGroupType switch
        {
            DateGroupTypes.Daily => ByDays(request, userActionItems),
            DateGroupTypes.Monthly => ByMonth(request, userActionItems),
            _ => null
        };
    }


    private UserActionStatResponse ByDays(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        var response = new UserActionStatResponse();
        response.UserActionStat = new List<UserActionStatItem>();
        for (var i = 0; i < userActionItems.Count; i++)
        {
            var item = userActionItems[i];
            
            if (IsFitDate(request, item))
            {
                var it = FindByDay(item, response);
                AddByDay(it, response, item);
            }
        }
        return response;
    }
    private bool IsFitDate(UserActionStatRequest request, UserActionItem userActionItem)
    {
        return userActionItem.Date < request.EndDate && userActionItem.Date >= request.StartDate;
    }

    private int FindByDay(UserActionItem item, UserActionStatResponse response)
    {
        for (var i = 0; i < response.UserActionStat.Count; i++)
        {
            if (response.UserActionStat[i].StartDate == item.Date)
            {
                return i;
            }
        }

        return -1;
    }

    private void AddByDay(int it, UserActionStatResponse response, UserActionItem item)
    {
        if (it == -1)
        {
            var newStat = new UserActionStatItem();
            newStat.StartDate = newStat.EndDate = item.Date;
            newStat.ActionMetrics = new Dictionary<ActionTypes, int>();
            newStat.ActionMetrics.Add(item.Action, item.Count);
            response.UserActionStat.Add(newStat);
        }
        else
        {
            var stat = response.UserActionStat[it];

            if (stat.ActionMetrics.ContainsKey(item.Action))
            {
                stat.ActionMetrics[item.Action] += item.Count;
            }
            else
            {
                stat.ActionMetrics.Add(item.Action, item.Count);
            }
        }
    }

    private UserActionStatResponse ByMonth(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        UserActionStatResponse response = new UserActionStatResponse();
        response.UserActionStat = new List<UserActionStatItem>();
        for (var i = 0; i < userActionItems.Count; i++)
        {
            var item = userActionItems[i];
            if (IsFitDate(request, item))
            {
                int it = FindByMon(item, response);
                AddByMon(it, response, item, request);
            }
        }
        return response;
    }


    private int FindByMon(UserActionItem item, UserActionStatResponse response)
    {
        for (var i = 0; i < response.UserActionStat.Count; i++)
        {
            if (response.UserActionStat[i].StartDate.Year == item.Date.Year &&
                response.UserActionStat[i].StartDate.Month == item.Date.Month)
            {
                return i;
            }
        }
        
        return -1;
    }

    private void AddByMon(int it, UserActionStatResponse response, UserActionItem item, UserActionStatRequest request)
    {
        if (it == -1)
        {
            var newStat = new UserActionStatItem();

            var startDay = 0;
            if (item.Date.Year == request.StartDate.Year && item.Date.Month == request.StartDate.Month)
                startDay = request.StartDate.Day;
            else startDay = 1;
            
            var endDay = 0;
            if (item.Date.Year == request.EndDate.Year && item.Date.Month == request.EndDate.Month)
                endDay = request.EndDate.Day;
            else endDay = GetDays(item.Date.Month, item.Date.Year);
            
            newStat.StartDate = new DateTime(item.Date.Year, item.Date.Month, startDay);
            newStat.EndDate = new DateTime(item.Date.Year, item.Date.Month,endDay);
            newStat.ActionMetrics = new Dictionary<ActionTypes, int>();
            newStat.ActionMetrics.Add(item.Action, item.Count);
            response.UserActionStat.Add(newStat);
        }
        else
        {
            UserActionStatItem stat = response.UserActionStat[it];
            if (stat.ActionMetrics.ContainsKey(item.Action))
            {
                stat.ActionMetrics[item.Action] += item.Count;
            }
            else stat.ActionMetrics.Add(item.Action, item.Count);
        }
    }

    private int GetDays(int it, int year)
    {
        switch (it) 
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 2:
                if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) return 29;
                else return 28;
            default:
                return 30;
        }
    }
}