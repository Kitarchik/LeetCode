using System.Text;

namespace ConsoleApp1;

public class Task30
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var dict = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!dict.ContainsKey(word))
            {
                dict.Add(word, 1);
            }
            else
            {
                dict[word]++;
            }
        }
        var result = new List<int>();
        var wordLength = words[0].Length;
        var length = wordLength * words.Length;
        if (s.Length < length)
        {
            return result;
        }
        for (var i = 0; i <= s.Length - length; i++)
        {
            if (IsValidSubstring(s.Substring(i, length), dict, wordLength))
            {
                result.Add(i);
            }
        }

        return result;
    }

    private bool IsValidSubstring(string s, Dictionary<string, int> dict, int wordLength)
    {
        var set = new HashSet<int>();
        foreach (var word in dict.Keys)
        {
            var startIndex = 0;
            for (int i = 0; i < dict[word]; i++)
            {
                var found = false;
                while (startIndex <= s.Length - wordLength && !found)
                {
                    var index = s.IndexOf(word, startIndex);
                    if (index < 0)
                    {
                        startIndex = s.Length;
                    }
                    else if(index % wordLength != 0 || !set.Add(index))
                    {
                        startIndex += wordLength;
                    }
                    else
                    {
                        found = true;
                        startIndex = index + wordLength;
                    }
                }
                if (!found)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public IList<int> FindSubstring2(string s, string[] words)
    {
        var result = new List<int>();
        if (s == null || words == null || words.Length == 0) return result;

        int wordLength = words[0].Length;
        int windowSize = wordLength * words.Length;
        if (s.Length < windowSize) return result;

        var wordCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount.Add(word, 1);
            }
        }

        for (int i = 0; i < wordLength; i++)
        {
            int left = i;
            var wordsFound = new Dictionary<string, int>();
            int count = 0;

            for (int right = i; right <= s.Length - wordLength; right += wordLength)
            {
                string word = s.Substring(right, wordLength);

                if (wordCount.ContainsKey(word))
                {
                    if (wordsFound.ContainsKey(word))
                    {
                        wordsFound[word]++;
                    }
                    else
                    {
                        wordsFound.Add(word, 1);
                    }

                    count++;

                    while (wordsFound[word] > wordCount[word])
                    {
                        string leftWord = s.Substring(left, wordLength);
                        wordsFound[leftWord]--;
                        count--;
                        left += wordLength;
                    }

                    if (count == words.Length)
                    {
                        result.Add(left);
                    }
                }
                else
                {
                    wordsFound.Clear();
                    count = 0;
                    left = right + wordLength;
                }
            }
        }

        return result;
    }
}
