# TUBAF_SE-Project_StockProphet

Predicting stock market development in regard to specific corporations by applying sentiment analysis to economic news articles


@startuml

skin rose

title Stock Prophet

class User{
  +searchArtricles(keyword: string): void
  +predictStockprice(company: string)
}
note left
    Here the user searches for a Stock on which he wants predictions:
    Exp:
    *'https://www.deraktionaer.de/suchen?page=1&q=" + CompanyName'
    * ...
    * ...

end note
class LinkExtractor{
  -title: name
  -content: all 
}
class ParagraphExtractor{
  -content: all <p> of html
}

LinkExtractor <|-- User 
ParagraphExtractor <|-- LinkExtractor

class predictStockprice{
}

@enduml
