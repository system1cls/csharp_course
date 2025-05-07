namespace App.practice2;

public class N_gram
{
    private class ContInfo
    {
        private string cont;
        private int cnt = 0;

        public ContInfo(string cont, int cnt)
        {
            this.cont = cont;
            this.cnt = cnt;
        }
        
        public string GetCont() => cont;
        public int GetCnt() => cnt;
        
        public void IntCnt() => cnt++;
    }
    
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        inputString = inputString.ToLower();
        
        var frequencyAnalysis = new Dictionary<string, List<ContInfo>>();
        var isAdded = false;
        
        foreach (var str in inputString.Split('.', '!', '?'))
        {
            var words = str.Split(' ', ',', ':', ';');

            words = words.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            
            for (var i = 0; i < words.Length; i++)
            {
                if (i != words.Length - 1)
                {

                    isAdded = false; 
                    if (!frequencyAnalysis.ContainsKey(words[i])) frequencyAnalysis[words[i]] = new List<ContInfo>(); 
                    foreach  (var node in frequencyAnalysis[words[i]])
                    { 
                        if (node.GetCont().Equals(words[i + 1])) node.IntCnt(); 
                        isAdded = true; 
                        break; 
                    } 
                    if (!isAdded) frequencyAnalysis[words[i]].Add(new ContInfo(words[i + 1], 1));


                    if (i != 0)
                    {
                        isAdded = false;
                        if (!frequencyAnalysis.ContainsKey(words[i - 1] + " " + words[i])) 
                            frequencyAnalysis[words[i-1] + " " + words[i]] = new List<ContInfo>(); 
                        foreach  (var node in frequencyAnalysis[words[i-1] + " " + words[i]])
                        { 
                            if (node.GetCont().Equals(words[i + 1])) node.IntCnt(); 
                            isAdded = true; 
                            break; 
                        } 
                        
                        if (!isAdded) frequencyAnalysis[words[i-1] + " " + words[i]].Add(new ContInfo(words[i + 1], 1));
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
                max = Math.Max(node.GetCnt(), max);
            }

            foreach (var node in frequencyAnalysis[key])
            {
                if (node.GetCnt() == max && (strAns == null) || string.CompareOrdinal(strAns, node.GetCont()) > 0) strAns = node.GetCont();
            }
            ans.Add(key, strAns);
        }  
        
        return ans;
    }
}