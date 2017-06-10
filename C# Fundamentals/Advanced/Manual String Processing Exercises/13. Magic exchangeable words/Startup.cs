using System;
using System.Collections.Generic;

namespace _13.Magic_exchangeable_words
{
    class Startup
    {
        static void Main(string[] args)
        {
            var inputTokens = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var leftWord = inputTokens[0];
            var rightWord = inputTokens[1];
            var magicWords = new Dictionary<char, char>();
            var isMagic = true;

            if (leftWord.Length == rightWord.Length)
            {
                for (var i = 0; i < leftWord.Length; i++)
                {
                    if (!magicWords.ContainsKey(leftWord[i]))
                    {
                        magicWords.Add(leftWord[i], rightWord[i]);
                    }
                    else if (magicWords[leftWord[i]] != rightWord[i])
                    {
                        isMagic = false;
                        break;
                    }
                }
            }
            else
            {
                string bigger;
                string smaller;
                if (leftWord.Length > rightWord.Length)
                {
                    bigger = leftWord;
                    smaller = rightWord;
                }
                else
                {
                    bigger = rightWord;
                    smaller = leftWord;
                }

                for (var i = 0; i < bigger.Length; i++)
                {
                    if (i < smaller.Length)
                    {
                        if (!magicWords.ContainsKey(bigger[i]))
                        {
                            magicWords.Add(bigger[i], smaller[i]);
                        }
                        else if (magicWords[bigger[i]] != smaller[i])
                        {
                            isMagic = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!magicWords.ContainsKey(bigger[i]))
                        {
                            isMagic = false;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(isMagic.ToString().ToLower());
        }
    }
}
