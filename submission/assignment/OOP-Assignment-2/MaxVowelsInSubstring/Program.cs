namespace MaxVowelsInSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static int MaxVowels(string s, int k)
        {
            int current = 0;

            for(int i =0; i < k; i++)
            {
                if (IsVowel(s[i]))
                    current++;
            }

            int max = current;

            for(int right = k; right < s.Length; right++)
            {
                int left = right - k;

                if (IsVowel(s[left]))
                    current--;

                if (IsVowel(s[right]))
                    current++;

                if (current > max)
                    max = current;
            }
            return max;
        }

        private static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'; 
        }
    }
}
