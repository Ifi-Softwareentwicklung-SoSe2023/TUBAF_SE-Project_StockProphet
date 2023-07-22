using System;
using System.Text.RegularExpressions;

namespace WebCollectorLib
{
    static class ContentFilter
    {
        public static string RemoveAuthors(string Text)
        {
            // Entfernt alle Paragraphen, die Autor/ Autorenen enthalten
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

        public static string RemoveCharacters(string Text)
        {
            // Entferne alle Emojis
            string noEmojiText = Regex.Replace(Text, @"[\p{Cs}\p{Co}\p{Cf}\p{Lm}\p{Sk}\p{P}\p{S}]", "");

            return noEmojiText;
        }
    }
}
