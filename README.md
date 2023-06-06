#Library Support System Web Application
This is a web application for a library support system that allows users to lend books and administrators to manage users and books. It includes various features and functionalities as described below.

##Application Elements
###Users
Registration Form: Users can register by providing necessary information.
User Profile Edit Form: Users can edit their profile information.
Logging Control: Users can log in to access the application.
Books Viewing Form: Users can view available books and add them to the borrow cart.
Books Cart Viewing Form: Users can view the borrow cart and see the history of previously borrowed books.
###Administrators
Users Management Form: Administrators can manage user accounts by removing and blocking accounts.
Books Management Form: Administrators can manage books by viewing, adding, editing, and deleting them.
###Library Support Team
Orders and Return Accepts Form: Library support team members can manage book orders and accept returns.
###Database Integration
All information from the application is stored in a database.
Relevant tables are created to store user information, book information, borrow history, and other relevant data.
The tables are filled with sample data for testing purposes.
Data is read and written from/to the database to support the functionalities described above.
###Application Features
User Session Management: Information about the current user is stored in the session.
Main Page Visits Counter: A simple counter tracks the number of visits to the main page.
Logging Control Validation: Fields in the logging control are validated to ensure they are not blank, the login is a valid email address, and the password meets the requirements (at least 8 characters with both letters and digits).
Master Page Usage: The application uses a master page to maintain a consistent layout and design.
###Additional Features
Book Categorization: Books can be grouped into categories, which are created and managed by administrators.
Basic Book Search: Users can search for books by title and view the search results.
Advanced Book Search: Users can perform advanced book searches by title, author, and category, and view the search results.
News Management: Administrators can manage news articles that are displayed on the main page of the web application.
"Remember Me" Option: Users can select the "Remember me" option during login to enable automatic login in future visits.
###Appearance
The application has been designed with a visually appealing and user-friendly interface to enhance the user experience and provide a pleasant browsing experience.

Note: This project is a study project and may not be suitable for production environments. It was developed to demonstrate the implementation of the mentioned features and may require additional security and scalability considerations for real-world deployment.
