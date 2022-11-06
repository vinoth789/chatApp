## Table of contents
* [General info](#general-info)
* [Features](#features)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This project is a simple chat application, where the user can login using their id and the enter the chat room. The user could send a text and view the messages
of other users.
The project consists of two parts, the Backend developed using ASP.NET Core 6 and MSSQL for the database and the Frontend developed using Vue 3. 
They are then containirised using Docker and served through Docker-compose.
![](https://github.com/vinoth789/chatApp/blob/main/chatApp.gif)
## Features
- User can register to the app and login.
- User can view the list of all the users.
- User can view the list of messages from all the users.
- User can send a message. 
	
## Technologies
Project is created with:
* ASP.NET Core 6
* MSSQL
* Vue 3
* Docker
* Docker-compose
	
## Setup
To run this project, follow the below steps:

```
$ Clone the project and execute the below commands in the root directory of the project.
$ docker-compose build
$ docker-compose up
```
