using System;

namespace StockProphetLib
{
    class PreProcessor : IArticleHandler
    {
        void IArticleHandler.Run(object obj) 
        {
            Article article = (Article)obj;
        }

        private void Clean() {}

        private void Seperate() {}
    }
}