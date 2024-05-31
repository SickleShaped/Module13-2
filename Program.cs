using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Module13_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Sickle-shaped\Desktop\text1.txt";
            Dictionary<string, int> words = new Dictionary<string, int>();
            var text = ReadText(filePath);
            string[] wordsArray = new string(text.Where(c => !char.IsPunctuation(c)).ToArray()).Split(' ');
            

            AddWords(words, wordsArray);
            Write10MaxCount(words);

        }

        static string ReadText(string path)
        {
            string text = "";

            if (File.Exists(path))
            {
               
                using (StreamReader sr = File.OpenText(path))
                {
                    text=sr.ReadToEnd();
                }
            }

            return text;
        }

        static void AddWords(Dictionary<string, int> words, string[] wordsArray)
        {
            foreach (var word in wordsArray)
            {
                if (words.ContainsKey(word))
                {
                    words[word]++;
                }
                else
                {
                    words.Add(word, 1);
                }
            }
            words.Remove("");
        }

        static void Write10MaxCount(Dictionary<string, int> words)
        {
            int i = 0;
            foreach (KeyValuePair<string, int> pair in words.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("Слово " + pair.Key + " в количестве " + pair.Value);
                i++;
                if (i == 10) break;
            }
        }
    }
}