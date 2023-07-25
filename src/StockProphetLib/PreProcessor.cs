using System;
using WebCollectorLib;

namespace StockProphetLib
{
    class PreProcessor : IArticleHandler
    {
        void IArticleHandler.Run(object obj) 
        {
            Article article = (Article)obj;

            for (int i = 0; i < article.Paragraphs.Count; i++)
            {
                article.Paragraphs[i] = ContentFilter.RemoveLines(article.Paragraphs[i]);
                article.Paragraphs[i] = ContentFilter.ReplaceName(article.Paragraphs[i], article.Keyword);
            }
            article.Paragraphs.RemoveAll(par => string.IsNullOrWhiteSpace(par));
        }
    }
}