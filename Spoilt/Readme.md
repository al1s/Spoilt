# Spoil The End

## Description
The project is a live extensible collection of spoilers for films/series/books and it should answer the simple question: What are the big twists present in popular television series/books/video games?

## Deployment

[Azure]()

## API Documentation

[via Postman]()

## Getting started

## Tech stack

Languages and Frameworks: C#, .NET Core, MVC, Entity, Razor, HTML, CSS, Bootstrap, Javascript,  JQuery.
DB: SQL Server.
Frontend Server: IIS.
API tests and documentation: Postman.

## User stories

1. As a user, I want to add spoilers to the films/books/events/games, so that everybody could come and see what would be in the epilogue.
    - The site has an input field/fields for entering the text of the spoiler.
    - The site saves entered spoiler.
    - I can return to overlook all my spoilers.
    - I can edit any of my spoilers.
    - I can delete my spoilers.
2. As a user, I can have the ability to add posters, related to the topic of my spoiler, so that I can easily distinguish each spoiler.
    - I can search for posters by topic title (movie).
    - I can associate the poster I've found with a spoiler.
    - I can dissociate the poster with a spoiler if they don't match.
3. As a developer, I want to use MVC framework, so that I can get the working skeleton of the app.
    - API and Front-end implemented using a model-view-controller approach.
    - Dependency injection pattern exploited for controllers implementation.
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
