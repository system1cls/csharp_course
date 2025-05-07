using App.practice2;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


namespace AppTests.practice2;

public class N_GramTests
{
        
    [Test]
    public void run()
    {
        string str = "a b c d. b c d. e b c a d.";
        Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            ["a"] = "b",
            ["b"] = "c",
            ["c"] = "d",
            ["e"] = "b",
            ["a b"] = "c",
            ["b c"] = "d",
            ["e b"] = "c",
            ["c a"] = "d"
        };
        
        var myDict = N_gram.FrequencyAnalysis(str);
        
        foreach (var node in dict)
        {
            Assert.That(myDict.ContainsKey(node.Key));
            Assert.That(node.Value.Equals(myDict[node.Key]));
        }
    }
}