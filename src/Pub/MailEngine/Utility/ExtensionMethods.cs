using System;
using System.Collections.Generic;
using System.Text;

namespace MailEngine.Utility
{
    public static class ExtensionMethods
    {
        private static Random rng = new Random();

        public static string Multiply(this string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }

            return sb.ToString();
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }

}