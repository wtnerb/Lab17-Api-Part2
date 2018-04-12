# Honeydew API
This is a simple, locally hosted API. When running, it will allow the user to request Todo items or a Todo list. Currently, a todo item can only be associated in one todo list. There are a few prebuilt silly examples.

## Use
To use this API, you will need to download the code and set up a local sql server. In visual studio 2017, with the sql server workload included, this is as simple as opening the nu-get package console and inputing:
```
Add-Migration Initial
Update-Database
```
At this point, you should be able to check if the database exists using the sql server explorer. If it does, your API is now ready to run!


Run the code. A browser page will pop up with a default 404 not found. Because this API has no front end, that is the expected, successful result. Look in the URL at the top of that page. It should read something like ``` localhost:1234/ ``` Copy and paste that whole thing into the tool you are using to send requests to the API (tested with postman, but anything should work). At that endpoint, firing a get request, the response body should look like
```

```

### endpoints:
#### Todo
- GET ```Todo``` gets all the Todo items
- GET ```Todo/{id}``` gets the Todo item associated with that id number
- POST ```Todo``` A valid Todo item with all fields complete (except id, which will be auto generated if not provided) must be included in the body of the request. Otherwise, your will get a bad request error. This will add a Todo. NOTE: the Todolist associated must already exist.
- DELETE ```Todo/{id}``` deletes the item with a matching id
#### Todolist
- GET ```Todolist``` gets all the Todolist items
- GET ```Todolist/{id}``` gets the Todolist associated with that id number
- POST ```Todolist``` A valid Todolist item with all fields complete (except id, which will be auto generated if not provided) must be included in the body of the request. Otherwise, your will get a bad request error.
- DELETE ```Todolist/{id}``` deletes the item with a matching id