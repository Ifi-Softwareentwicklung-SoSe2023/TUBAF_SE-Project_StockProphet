using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebCollectorLib
{
    public static class ContentFilter
    {
        public static string RemoveLines(string Text)
        {
            // Entfernt alle Paragraphen, die Autor/ Autoren und unnötiges Content enthalten
            string[] paragraphs = Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string filteredText = "";
            foreach (string paragraph in paragraphs)
            {
                if (!paragraph.Contains("Autor") && !paragraph.Contains("Autoren")&& !paragraph.Contains("978"))
                {
                    filteredText += paragraph + Environment.NewLine;
                }
            }

            return filteredText;
        }

        public static string ReplaceName(string Text, string Name)
        {
            string newName = Regex.Replace(Text, Name, "Compu");
            return newName;
        }
    }
}
