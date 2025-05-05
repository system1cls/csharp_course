namespace App.practice2;

public class N_gram
{
    private class contInfo
    {
        private string cont;
        private int cnt = 0;

        public contInfo(string cont, int cnt)
        {
            this.cont = cont;
            this.cnt = cnt;
        }
        
        public string getCont() => cont;
        public int getCnt() => cnt;
        
        public void intCnt() => cnt++;
    }
    
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        Dictionary<string, List<contInfo>> frequencyAnalysis = new Dictionary<string, List<contInfo>>();
        bool isAdded = false;
        
        foreach (var str in inputString.Split("."))
        {
            var words = str.Split(" ");

            words = words.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            
            for (var i = 0; i < words.Length; i++)
            {
                if (i != words.Length - 1)
                {

                    isAdded = false; 
                    if (!frequencyAnalysis.ContainsKey(words[i])) frequencyAnalysis[words[i]] = new List<contInfo>(); 
                    foreach  (var node in frequencyAnalysis[words[i]])
                    { 
                        if (node.getCont().Equals(words[i + 1])) node.intCnt(); 
                        isAdded = true; 
                        break; 
                    } 
                    if (!isAdded) frequencyAnalysis[words[i]].Add(new contInfo(words[i + 1], 1));


                    if (i != 0)
                    {
                        isAdded = false;
                        if (!frequencyAnalysis.ContainsKey(words[i - 1] + " " + words[i])) 
                            frequencyAnalysis[words[i-1] + " " + words[i]] = new List<contInfo>(); 
                        foreach  (var node in frequencyAnalysis[words[i-1] + " " + words[i]])
                        { 
                            if (node.getCont().Equals(words[i + 1])) node.intCnt(); 
                            isAdded = true; 
                            break; 
                        } 
                        
                        if (!isAdded) frequencyAnalysis[words[i-1] + " " + words[i]].Add(new contInfo(words[i + 1], 1));
                    }
                }
            }
        }


        var ans = new Dictionary<string, string>();
        foreach (var key in frequencyAnalysis.Keys)
        {
            int max = 0;
            string strAns = null;
            
            
            foreach (var node in frequencyAnalysis[key])
            {
                max = Math.Max(node.getCnt(), max);
            }

            foreach (var node in frequencyAnalysis[key])
            {
                if (node.getCnt() == max && (strAns == null) || string.CompareOrdinal(strAns, node.getCont()) > 0) strAns = node.getCont();
            }
            ans.Add(key, strAns);
        }  
        
        return ans;
    }
}