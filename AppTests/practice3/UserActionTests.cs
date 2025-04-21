using System.Runtime.Intrinsics.X86;
using App.practice3;
using NUnit.Framework.Internal;

namespace AppTests.practice3;

public static class UserActionTests
{
    

    private static List<UserActionItem> initList(int var) 
    {
        
        List<UserActionItem> list;
        switch (var)
        {
            case 1:
                list = new List<UserActionItem>();
                list.Add(new UserActionItem(new DateTime(2024, 12, 9), ActionTypes.Login,  1));
                list.Add(new UserActionItem(new DateTime(2024, 12, 10), ActionTypes.SearchProducts,  3));
                list.Add(new UserActionItem(new DateTime(2024, 12, 10), ActionTypes.GetProductDetails,  12));
                list.Add(new UserActionItem(new DateTime(2024, 12, 10), ActionTypes.AddProductToCart, 2));
                list.Add(new UserActionItem(new DateTime(2025, 1, 1), ActionTypes.PayOrder, 1));
                list.Add(new UserActionItem(new DateTime(2025, 1, 15), ActionTypes.RecieveOrder, 1));
                break;
            default:
                list = null;
                break;
        }
        return list;
    }

    private static List<UserActionStatItem> ans1()
    {
        List<UserActionStatItem> list = new List<UserActionStatItem>();
        Dictionary<ActionTypes, int> dict1 = new Dictionary<ActionTypes, int>();
        dict1.Add(ActionTypes.SearchProducts, 3);
        dict1.Add(ActionTypes.GetProductDetails, 12);
        dict1.Add(ActionTypes.AddProductToCart, 2);
        list.Add(new UserActionStatItem(new DateTime(2024, 12, 10), new DateTime(2024, 12, 10), dict1));
        Dictionary<ActionTypes, int> dict2 = new Dictionary<ActionTypes, int>();
        dict2.Add(ActionTypes.PayOrder, 1);
        list.Add(new UserActionStatItem(new DateTime(2025, 1, 1), new DateTime(2025, 1, 1), dict2));
        Dictionary<ActionTypes, int> dict3 = new Dictionary<ActionTypes, int>();
        dict3.Add(ActionTypes.RecieveOrder, 1);
        list.Add(new UserActionStatItem(new DateTime(2025, 1, 15), new DateTime(2025, 1, 15), dict3));
        return list;
    }

    private static List<UserActionStatItem> ans2()
    {
        List<UserActionStatItem> list = new List<UserActionStatItem>();
        Dictionary<ActionTypes, int> dict1 = new Dictionary<ActionTypes, int>();
        dict1.Add(ActionTypes.Login, 1);
        dict1.Add(ActionTypes.SearchProducts, 3);
        dict1.Add(ActionTypes.GetProductDetails, 12);
        dict1.Add(ActionTypes.AddProductToCart, 2);
        list.Add(new UserActionStatItem(new DateTime(2024, 12, 9), new DateTime(2024, 12, 31), dict1));
        Dictionary<ActionTypes, int> dict2 = new Dictionary<ActionTypes, int>();
        dict2.Add(ActionTypes.PayOrder, 1);
        list.Add(new UserActionStatItem(new DateTime(2025, 1, 1), new DateTime(2025, 1, 14), dict2));
        return list;
    }

    private static UserActionStatRequest request1 =
        new UserActionStatRequest(new DateTime(2024, 12, 10), 
            new DateTime(2025, 1, 30), DateGroupTypes.Daily);
    private static UserActionStatResponse response1 = new UserActionStatResponse( ans1());

    private static UserActionStatRequest request2 =
        new UserActionStatRequest(new DateTime(2024, 12, 9), new DateTime(2025, 1, 14), DateGroupTypes.Monthly);
    private static UserActionStatResponse response2 = new UserActionStatResponse(ans2());
    
    [Test]    
    public static void Run1()
    {
        UserSatProvider satProvider = new UserSatProvider();
        UserActionStatResponse myResponse = satProvider.GetUserActionStat(request1, initList(1));
        
        test(response1, myResponse);
    }

    [Test]
    public static void Run2()
    {
        UserSatProvider satProvider = new UserSatProvider();
        UserActionStatResponse myResponse = satProvider.GetUserActionStat(request2, initList(1));
        
        test(response2, myResponse);
    }

    private static void test(UserActionStatResponse response, UserActionStatResponse myResponse)
    {
        Assert.That(myResponse.UserActionStat.Count == response.UserActionStat.Count);
        for (int i = 0; i < response.UserActionStat.Count; i++)
        {
            Assert.That(response.UserActionStat[i].StartDate == myResponse.UserActionStat[i].StartDate);
            Assert.That(response.UserActionStat[i].EndDate == myResponse.UserActionStat[i].EndDate);
            Assert.That(response.UserActionStat[i].ActionMetrics.Count == myResponse.UserActionStat[i].ActionMetrics.Count);
            foreach (var type in response.UserActionStat[i].ActionMetrics.Keys) 
            {
                Assert.That(myResponse.UserActionStat[i].ActionMetrics.ContainsKey(type));
                Assert.That(myResponse.UserActionStat[i].ActionMetrics[type] == response.UserActionStat[i].ActionMetrics[type]);
            }
        }
    }
}