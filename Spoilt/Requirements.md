# App name
Spoil the End

## Vision

The project is a live extensible collection of spoilers for films/series/books and it should answer the simple question: What are the big twists present in popular television series/books/video games?
Users can type in a show/book/game title and the app will display the spoiler if available or provide an ability to add new one. The reason behind is obvious: to convert a user into the know-it-all person who no one can tolerate. 

## Scope

The app provides an API and a user-interface to manage a collection of spoilers. A user have ability to search for existing spoilers, create new spoilers, discuss spoilers with others, associate spoilers with the related info about the topic using external resources.

The app will not provide an extended description of the subject - we are interested only in spoilers.
The app will not store user data except needed for basic user authentication and distinction.

## Functional requirements

1. User can login to the app using third-party auth providers.
2. User can search for existing spoilers by subject (movie/series) title.
3. User can add a spoiler for a chosen subject.
4. User can edit/delete spoilers added by him/her.
5. User can add comments to other spoilers. 
6. User can access Rest API to interact with spoiler storage back end.

## Non-functional requirements

1. The site should have simple, clean design.
2. The front and back end parts should have unit tests covering all endpoints (API) and controllers (UI). 

## Data Flow
Describe the flow of data in your application. This should describe what happens from the time the user hits the site, to the time the request process completes.