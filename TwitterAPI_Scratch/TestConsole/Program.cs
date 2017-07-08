using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Guid nouce = new Guid();
            string NotAllowed = "`~!@#$%^&*()_{}[]:><,.? /\" \\'|";
            string oauth_nouce = Convert.ToBase64String(nouce.ToByteArray());
            oauth_nouce = RandomString(42);
            char[] allow = oauth_nouce.ToCharArray();
            char[] notAllow = NotAllowed.ToCharArray();
            StringBuilder builder = new StringBuilder();
            Random num = new Random();
            for (int i = 0; i < allow.Length; i++)
            {
                for (int j = 0; j < notAllow.Length; j++)
                {
                    if (allow[i] == notAllow[j])
                    {
                        string swap = allow[i].ToString();
                        swap = swap.Replace(notAllow[j].ToString(), RandomString(1).ToLower());
                        allow[i] = swap.Single();
                    }
                }
                builder.Append(allow[i]);
            }
            oauth_nouce = builder.ToString();
            Console.WriteLine(oauth_nouce);
        }

        private static string RandomString(int size)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26
                    * random.NextDouble() + 64)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
