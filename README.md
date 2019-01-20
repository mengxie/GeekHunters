# Geek Hunters

You are working at IT-recruiting agency "Geek Hunters". Your employer asked you to implement Geek Registration System
(GRS). 

Using GRS a recruitment agent should be able to:
  - register a new candidate:
     - first name / last name
     - select technologies candidate has experience in from the predefined list 
  - view all candidates
  - filter candidates by technology

Another developer has partially designed and implemented a
SQLite DB for this project - GeekHunters.sqlite. Feel free to modify a structure to
your needs.

Please fork the project and commit your source code (please do not archive it :) ).

You are free to use **ANY** .net web frameworks you need - aspnet / webapi / spa etc. However, if you decide to go with third
party package manager or dev tool - don't forget to mention them in the
README.md of your fork.

Good luck!

P.S: And unit tests! We love unit tests!
-------------------------------------------------------------------------------------------------------------------------------
Develop in C#, use Asp.net Mvc5 framework
dependency injection and repository patterns
Entity framework 6 code first approach
GeekHunter.sqlite is put in App_Data folder of web project
 
Packages Used:
StructureMap for resolving dependency injection
System.Data.SQLite package and dlls for EF6 SQLite DDEX provider 
Chosen.Jquery lib for skills multi-select control
AutoMapper for data transfer object mapping
moq for dependency injection in unit tests
Log4net for logging and log file location can be set in config file 
