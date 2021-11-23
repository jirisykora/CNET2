namespace TextTools
{
    public class TextTools
    {
        public static async Task<Dictionary<string, int>>  FreqAnalyze(string file, string splitby = " ")
        {
            var content = await File.ReadAllTextAsync(file);
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