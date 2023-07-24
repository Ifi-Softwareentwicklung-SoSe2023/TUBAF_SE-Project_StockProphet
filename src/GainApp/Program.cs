using System;
using System.IO;
using WebCollectorLib;

namespace LinkCollectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string keyword = "AMD";
                
                LinkCollector linkCollector = new LinkCollector();
                string[] links = linkCollector.FindLinks(keyword);

                if (links != null && links.Length > 0)
                {
                    
                    ParagraphCollector paragraphCollector = new ParagraphCollector();
                    
                    var paragraphsFromLink1 = paragraphCollector.ExtractParagraphsFromLinks(links[0]);
                    

                    string filePath = "paragraphs.txt";
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        //foreach (var num in vaar){
                        writer.WriteLine("Paragraphen aus dem ersten Link:");
                            foreach (var paragraph in paragraphsFromLink1)
                            {
                                writer.WriteLine(paragraph);
                            }
                       // }
                       
                        
                    }

                    Console.WriteLine("Paragraphen gespeichert.");
                }
                else
                {
                    Console.WriteLine($"Keine Links zu '{keyword}' gefunden.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}
