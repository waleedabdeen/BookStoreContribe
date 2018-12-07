# BookStoreContribe

Branch | Travis CI  
------ | ---------
master (default) |[![Build Status](https://travis-ci.com/waleedabdeen/BookStoreContribe.svg?token=qzVLhTyKrSJxgSB2QeET&branch=master)](https://travis-ci.com/waleedabdeen/BookStoreContribe)


This is a book store web applicatiom. It is built in C# using Entitiy Framework (.Net Framework).


## Projects Included

The application consists of four projects. as follow:

1- BookStoreAPI: This is the backend part of the solution. It is a web api built in C#, using Entity Framework and MVC.
#### Technologies
- Entitiy Framework
- Web API

2- BookStoreAPI.Tests: This project contains a test suit for the previous project (BookStoreAPI). It consists of unit tests. Built using Nunit test.
#### Technologies:
- Nunit

3- BookStoreASPClient : This is a frontend for the project. It is built using ASP.NET Framework, and can be deployed separatly on different servers, it is not tide to the backend api, since each one is separate project.
#### Technologies:
- ASP.NET Framework
- MVC
- JQuery

4-BookStoreWFClient: This is another frontend part of the project. It is built using Windows Forms. It follows the same concept as the previous ASP client to connect to the backend using POST and GET requests.


## Architecture:

The project built in a modular way, in each project the code is divided into modules based on the functions or interface. 
A complete separation between the frontend and backend. makes it easy to repalce the frontend.

## Tests

The tests are written for the backend only, as it is the intention is to focuse more on the backend.

## CI

The solution uses Travis CI as continues integration tool. It automatically builds the soultion everytime a new code is pushed and it runs the tests as well.

## Setup & Build

1- Get Visual Studio (Preferred 2017) 

2- In the package manageer console run the following command ```nuget restore```
in case you do not have nuget installed then follow the steps mentioned in the link below
https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

Alternatively: you could just click the restore button when promoted by visual studio when you open the project.

3- Build & Run 

Note: by detault it will run BookStoreAPI which is the backend, to use the client then you need to right click the solution and go to properites, then select multiple startup and choose the projects you want to start (e.g. BookStoreAPI and BookStoreASPClient)

