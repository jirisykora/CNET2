namespace TextTools
{
    public class TextTools
    {
        public static async Task<Dictionary<string, int>>  FreqAnalyzeFromFileAsync(string file, string splitby = " ")
        {
            var content = await File.ReadAllTextAsync(file);
            return FreqAnalyzeFromString(content, splitby);
        }

        public static async Task<Dictionary<string, int>> FreqAnalyzeFromUrlAsync(string url, string splitby = " ")
        {
            using var client = new HttpClient();

            try
            {
                string content = await client.GetStringAsync(url);
                return FreqAnalyzeFromString(content);
            }
            catch(Exception ex)
            {
                throw new Exception("Failed FreqAnalyzeFromUrlAsync " + url + ex.Message);
            }
                                              
        }

        public static Dictionary<string, int> FreqAnalyzeFromFile(string file, string splitby = " ")
        {
            var content = File.ReadAllTextAsync(file);
            return FreqAnalyzeFromString(file, splitby);
        }

        public static Dictionary<string, int> FreqAnalyzeFromString(string content, string splitby = " ")
        {
            var words = content.Split(splitby);

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            return dict;
        }

        public static Dictionary<string, int> GetTopWord(int takeTop, Dictionary<string, int> dict)
        {
            return dict
                .OrderByDescending(x => x.Value).Take(takeTop)
                .ToDictionary(x => x.Key, y => y.Value)
                ;
        }
    }
}