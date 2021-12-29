using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnagramTask
{
    public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        private readonly string txt;

        public Anagram(string sourceWord)
        {
            if (sourceWord == null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (string.IsNullOrEmpty(sourceWord))
            {
                throw new ArgumentException("source word is empty", nameof(sourceWord));
            }

            this.txt = sourceWord;
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates == null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            string[] fakeresultstring = new string[3];
            int countofmatches = 0;
            int fakearraylenght = 0;
            for (int arraySnumber = 0; arraySnumber < candidates.Length; arraySnumber++)
            {
                for (int symbloofarray = 0; symbloofarray < candidates[arraySnumber].Length; symbloofarray++)
                {
                    for (int fieldSchar = 0; fieldSchar < this.txt.Length; fieldSchar++)
                    {
                        // длинный if это сравнение чтобы индексы первого вхождние и последнего не совпадали, ибо тогда буквы повторяются и мы break и
                        // проверка на -1, ибо если -1 то в строке нету такого, извините за грязь, если буду успевать - переделаю
                        if (candidates[arraySnumber].ToUpper(CultureInfo.CurrentCulture)[symbloofarray] == this.txt.ToUpper(CultureInfo.CurrentCulture)[fieldSchar])
                        {
                            countofmatches++;
                            if (candidates[arraySnumber].ToUpper(CultureInfo.CurrentCulture).IndexOf(this.txt.ToUpper(CultureInfo.CurrentCulture)[fieldSchar], StringComparison.CurrentCulture) != -1 && candidates[arraySnumber].ToUpper(CultureInfo.CurrentCulture).LastIndexOf(this.txt.ToUpper(CultureInfo.CurrentCulture)[fieldSchar]) != -1 && (candidates[arraySnumber].ToUpper(CultureInfo.CurrentCulture).IndexOf(this.txt.ToUpper(CultureInfo.CurrentCulture)[fieldSchar], StringComparison.CurrentCulture) != candidates[arraySnumber].ToUpper(CultureInfo.CurrentCulture).LastIndexOf(this.txt.ToUpper(CultureInfo.CurrentCulture)[fieldSchar])))
                            {
                                break;
                            }
                        }
                    }

                    // Words_Are_Not_Anagrams_Of_Themselves
                    if (candidates[arraySnumber].ToUpper(CultureInfo.CurrentCulture) == this.txt.ToUpper(CultureInfo.CurrentCulture))
                    {
                        break;
                    }
                }

                if (countofmatches == candidates[arraySnumber].Length && candidates[arraySnumber].Length == this.txt.Length)
                {
                    fakeresultstring[fakearraylenght] = candidates[arraySnumber];
                    fakearraylenght++;
                }

                countofmatches = 0;
            }

            // это на проверку пустоты fakeresultstring чтобы вернуть в конце чистый массив без string.empty
            int arraylenght = 0;
            for (int i = 0; i < fakeresultstring.Length; i++)
            {
                if (!string.IsNullOrEmpty(fakeresultstring[i]))
                {
                    arraylenght++;
                }
            }

            string[] resultstring = fakeresultstring[0..arraylenght];
            return resultstring;
        }
    }
}
