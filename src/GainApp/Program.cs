using System;
using System.IO;
using WebCollectorLib;
using System.Collections.Generic;

namespace LinkCollectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Name of company: ");
                string keyword = Console.ReadLine();
                
                LinkCollector linkCollector = new LinkCollector();
                string[] links = linkCollector.FindLinks(keyword);

                //ContentFilter contentFilter = new ContentFilter();
                //string text = contentFilter.RemoveAuthors(paragraph);

                if (links != null && links.Length > 0)
                {        
                    List<string> allParagraphs = new List<string>();
                    ParagraphCollector paragraphCollector = new ParagraphCollector();

                    foreach (var link in links){
                        var paragraphsFromLink = paragraphCollector.ExtractParagraphsFromLinks(link);
                        allParagraphs.AddRange(paragraphsFromLink);
                    }    
                           

                    string filePathraw = "../../data/paragraphs.txt";
                    using (StreamWriter writer = new StreamWriter(filePathraw))
                    {
                        foreach (var paragraph in allParagraphs)
                        {
                            writer.WriteLine(paragraph);
                        }
                    }

                    string filteredParagraphs = string.Join(Environment.NewLine, allParagraphs);
                    string filteredText = ContentFilter.RemoveLines(filteredParagraphs);
                    filteredText = ContentFilter.ReplaceName(filteredText, keyword);

                    string filePathfilter = "../../data/filtered_paragraphs.txt";
                    File.WriteAllText(filePathfilter, filteredText);

                    Console.WriteLine("Paragraphs were saved and text was cleaned.");
                }

                else
                {
                    Console.WriteLine($"No links were found for: '{keyword}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}