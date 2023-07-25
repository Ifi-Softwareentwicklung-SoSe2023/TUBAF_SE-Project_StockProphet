# TUBAF_SE-Project_StockProphet
---
## Project: Predicting stock market development in regard to specific corporations by applying sentiment analysis to economic news articles


This project aims to predict the performance of stocks and funds of different companies with the help of Artificial Intelligence. For this purpose, several articles are collected independently and divided into positive and negative connotations. These articles serve as the basis for a neural network, which is to be developed with the help of ML.NET.


### Procedure

1. Data collection:
    - Independent collection of articles on various companies and their stocks/funds.
    - Classification of the articles into positive and negative connotations to capture the mood of the market.

2. Construction of the neural network:
    - Using ML.NET to develop the neural network.
    - Input the collected articles as training data for the network.
    - The network should be able to make predictions about the performance of stocks and funds based on the articles.                      

3. Implementation of a user interface:
    - Develop an interactive user interface that allows the user to enter a specific stock or fund name.        
    - The network will then provide feedback and predictions about the future performance of the stock or fund based on the data entered.                        
                                                                                
4. Further development and improvements:                                                                                
    - Additional features may be added during the development process to improve prediction accuracy.
    - Ongoing review and update of data collection to provide the network with up-to-date information.


### Installation

+ Verify you have .NET 7.0 installed
+ clone the repository
+ Check out the projects main application:
  - navigate to ```src/MainApp/```
  - call ```dotnet run```

+ For collecting new articles in order to prepare a new dataset for model training:
  - navigate to ```src/GainApp/```
  - specify what companies to search for in Program.cs 
  - call ```dotnet run```

+ For re-training the sentiment AI model on a new dataset:
  - navigate to ```src/TrainApp/```
  - (optional) adjust paths to dataset and model in Program.cs
  - call ```dotnet run``` 
