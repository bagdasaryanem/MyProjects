using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class Solutions
    {
        public bool IsPalindrome(string text)
        {
            text = text.ToLower();
            var counter = text.Length - 1;
            for (var i = 0; i <= text.Length - 1; i++)
            {
                if (text[i] != text[counter--])
                {
                    return false;
                }
            }
            return true;
        }

        public int MinSplit(int amount)
        {
            var coins = new[] { 1, 5, 10, 20, 50 };
            var d = new int[amount + 1];

            for (var i = 1; i <= amount; i++)
            {
                d[i] = int.MaxValue;
                foreach (var t in coins)
                {
                    if (i >= t && d[i - t] != int.MaxValue)
                    {
                        d[i] = Math.Min(d[i], 1 + d[i - t]);
                    }
                }
            }

            return d[amount] == int.MaxValue ? -1 : d[amount];
        }

        public int NotContains(int[] array)
        {
            if (array.Min() > 0)
            {
                return array.Min() - 1;
            }
            return -1;
        }

        public bool IsProperly(string s)
        {
            var parenthesesMap = new Dictionary<char, char>
            {
                ['{'] = '}',
                ['('] = ')',
                ['['] = ']',
                ['<'] = '>'
            };

            if (s.Length % 2 != 0) { return false; }

            var closedParentheses = new Stack<char>();
            foreach (var p in s)
            {
                if (parenthesesMap.ContainsKey(p))
                {
                    closedParentheses.Push(parenthesesMap[p]);
                }
                else if (parenthesesMap.ContainsValue(p))
                {
                    if (closedParentheses.Count == 0)
                    {
                        return false;
                    }

                    if (closedParentheses.Pop() != p)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return (closedParentheses.Count == 0);
        }

        public int CountVariants(int n)
        {
            if (n <= 2) return n;
            var count = new int[3];
            count[1] = 1;
            count[2] = 2;
            for (var i = 3; i <= n; i++)
            {
                count[i % 3] = count[(i + 1) % 3] + count[(i - 1) % 3];
            }
            return count[n % 3];
        }
    }
}

