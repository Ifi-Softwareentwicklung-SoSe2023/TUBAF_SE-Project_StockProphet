using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCollectorLib
{
    public static class ContentFilter
    {
        public static string RemoveAuthors(string Text)
        {
            // Entfernt alle Paragraphen, die Autor/ Autoren enthalten
            string[] paragraphs = Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string filteredText = "";
            foreach (string paragraph in paragraphs)
            {
                if (!paragraph.Contains("Autor") && !paragraph.Contains("Autoren"))
                {
                    filteredText += paragraph + Environment.NewLine;
                }
            }

            return filteredText;
        }

        public static string ChangeName(string Text, string name){
            string nameChanger = Regex.Replace(Text, name, "Compu");
            
            return nameChanger;
        }

        public static string RemoveEmojis(string Text)
        {
            // Entferne alle Emojis
            string noEmojiText = Regex.Replace(Text, @"[\p{Cs}\p{Co}\p{Cf}\p{Lm}\p{Sk}\p{P}\p{S}]", "");

            return noEmojiText;
        }
    }
}
