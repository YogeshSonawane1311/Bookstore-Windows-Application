***Bookstore Entry System***
Overview
The Bookstore Entry System is a simple Windows Forms application designed to manage administrative users and book catalogs for a bookstore. It features user registration and login functionality, along with a catalog system that allows users to view, add, edit, and delete books in the bookstore's database.

Features
User Registration: Allows new administrative users to register by providing a username, password, name, gender, and date of birth.
User Login: Authenticates existing users before granting access to the book catalog system.
Book Catalog Management:
View Books: Displays a list of all books in the catalog, including details such as title, author, genre, price, and publication date.
Add Books: Allows users to add new books to the catalog.
Edit Books: Enables users to modify existing book details.
Delete Books: Provides functionality to remove books from the catalog.
Technologies Used
C# .NET: The primary programming language used to develop the application.
Windows Forms: The graphical user interface framework used for the application.
SQL Server: The database system used to store administrative user data and book catalog information.
Database Schema
The application interacts with a SQL Server database named bookstore. Key tables include:

admininfo: Stores administrative user information.
ID (int): Primary Key
username (varchar)
passcode (varchar)
_name (varchar)
gender (varchar)
dob (date)
Books: Stores information about books in the catalog.
ID (int): Primary Key, Auto-incremented
Title (varchar)
Author (varchar)
Genre (varchar)
Price (decimal)
PublicationDate (date)

# Bookstore-Windows-Application
![image](https://github.com/user-attachments/assets/edd2d549-40e5-4340-895f-3cd052ab71bd)
![image](https://github.com/user-attachments/assets/41af78b5-8445-4816-a50d-5e01244d9275)
![image](https://github.com/user-attachments/assets/7f2a0dba-4b8e-45f4-a380-daad4f6c84ab)

