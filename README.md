# Project info
Repository has been created for purposes of .NET coding class and contains two projects first is simple and common coding-interview task which is "[FizzBuzz](https://en.wikipedia.org/wiki/Fizz_buzz)".
Second project is Currency Rates App which is window application implemented in C# using [WPF](https://en.wikipedia.org/wiki/Windows_Presentation_Foundation) graphical subsystem.
Application allows you to get actual EUR, USD, GBP currency rates and current Gold price, in PLN terms, from web API, display them and persist in local database. More specific functions are (will be):
- Generate user friendly GUI which allows to perform certain tasks and present data in readable manner. **(accomplished)**
- Sending GET HTTP requests to [NBP Web API](http://api.nbp.pl/) in order to fetch data about actual and previous EUR, USD, GBP currency rates and also fetching data about gold price. **(accomplished)**
- Mapping JSON objects into C# objects with [Json.NET](https://www.newtonsoft.com/json) external library. **(accomplished)**
- Persisting data in the local database, and reading data from local database. **(pending)**
- Displaying a chart presenting exchange rates over time based on data from the database. **(pending)**
- Reliable set of automated tests which guarantee proper application workflow. **(pending)**

# Project insight
![App](/misc/App-stage1.png)
