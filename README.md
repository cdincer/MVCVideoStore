# MVCVideoStore
A video store project where you rent movies for your customers
Its written using Visual Studio 2015. All you need to do is restore packages, type update-database in your Package Manager Console.
Use admin@videostore.com with TestInitialPass1! for password. You are good to go. All the customers and movies are created through seeding.
Take a look at "Configuration.cs" file in migrations.

Every update-database will add customers and movies.You can adjust the amount of movies and customers added with each seeding.

Https required because of social media logins. These were tried to make sure that they work. They are removed from the project though.

Technologies used: Web API2 with Basic Authentication,Entity Framework 6, Bloodhoud.JS and Typeahead.js, Bootbox.
