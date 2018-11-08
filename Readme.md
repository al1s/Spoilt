# Spoil The End

## Description
The project is a live extensible collection of spoilers for movies and it should answer the simple question: What are the big twists present in popular films?

## Deployment

[Azure]()

## API Documentation

[via Swagger](http://spoiltapi.azurewebsites.net)

## Getting started

## Data Flow

[via Draw.io](https://drive.google.com/file/d/1IFFtjAH4dUni1PaxVeMAQhD2gnpLQGjW/view?usp=sharing)

## DB Schema

[via Draw.io](https://drive.google.com/file/d/1eHAOgXhjIG1nHJZCODZFJXvgQngcCMjT/view?usp=sharing)

## Front-End Wireframes

[View Front End Wireframes Here!](https://drive.google.com/file/d/1xYxxaKeHhpdsocGPuocCbg6nVn7sNYcc/view)

## Tech stack

Languages and Frameworks: C#, .NET Core, MVC, Entity, Razor, HTML, CSS, Bootstrap, Javascript,  JQuery, SASS
DB: SQL Server.
Frontend Server: IIS.
API tests and documentation: Postman.

## User stories

1. As a user, I want to search the site's database to see if a movie has any spoilers so I know if the spoiler I want to add has already been documented.
    - I can search the site for movies in the database. If a movie is already included, I can click on that movie and see all of the spoilers users have submitted for that movie.
    - If a movie is not already in the database, I will get information provided by the OMDB API. 
2. As a user, I want to add spoilers to movies so that everybody can come and find out about the movie's ending and/or twists in the plot.
    - I can enter a spoiler into a text field and save it so that it will be displayed with all of the other user-submitted spoilers for that particular movie.
    - If the movie was not already saved into the database, certain OMDB data will be saved, inlucding the movie title, plot synopsis, IMDB id, and poster. 
3. As a developer, I want to use MVC framework, so that I can get the working skeleton of the app.
    - API and Front-end implemented using a model-view-controller approach.
    - Dependency injection pattern exploited for controller implementation.
4. As a developer, I want to use EF code first approach, so the framework would deal with DB stuff.
    - SQL server setup implemented through models.
    - CRUD operations work from the box in scaffolded controllers/view.
5. As an instructor, I want to see the full stack MVC app digesting a custom API implemented in C#, so that I can grade the project using my rubric.
    - FE - Models
        - At least 2 Models
        - Dependency Injection with the Repository Design Pattern:
            - At least 1 “Service”.
            - At least 1 Interface.
    - FE - Views
        - .cshtml pages
        - You may use any CSS/JS front-end technologies you wish, as long as they work well with all of the requirements.
    - FE - Controllers
        - At least 2 Controllers.
    - Documentation
        - Provide documentation for your web app. Include the work-flow, screenshots of the front end for an app, DB Schema, and basic functionality directions on how to use the site;
        - Endpoint description using Swagger;
    - API
        - Have at least 2 Controllers
        - Have at least 2 Models
        - No Views Required
        - At least 2 Endpoints in each Controller
    - Commented code
        - What does this code do?
        - Why do you have it?
        - Where is the request being sent?
        - What is the request expected response?
        - Use Summary Comments!
    - Database
        - At least 2 tables
        - Digital DB Schema (should be present in your Readme)
    - Tests:
        - Getters/Setters
        - API Endpoints (for API Team)
        - CRUD operations
    - Deployment
        - Azure Web App
        - Azure SQL server
