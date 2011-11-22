Poor Man's CQRS
===============

The aim of this project is to create a small sample application to test CQRS & DDD concepts without deal with advances topics like: asynchronous messaging, CAP theorem, Event Sourcing, etc.

Visit [http://www.serrate.es/2011/11/21/poor-man's-cqrs](http://www.serrate.es/2011/11/21/poor-man's-cqrs) for more info about that (in spanish).

Run application
---------------

* Create a new Database: "PoorMansDb"
* On web.config connectionStrings section change the connection string "PoorMansCS"
* On web.config appSettings section set "BuildSchema" to true and it will generate DB. Once the database is generated turn off "BuildSchema" property
* Press F5 on Visual Studio :)
