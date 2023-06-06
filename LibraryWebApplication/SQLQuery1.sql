INSERT INTO Category(categoryName) VALUES 
('Fiction'),
('Dystopian'),
('Classic'),
('Adventure'),
('Novel'),
('Historical Fiction'),
('Fantasy'),
('Thriller'),
('Modernist'),
('Epic');

INSERT INTO Book (title, author, publishedYear, isAvailable, categoryID, coverImagePath) VALUES
('To Kill a Mockingbird', 'Harper Lee', 1960, 1, 1, 'Images/image1.jpg'),
('1984', 'George Orwell', 1949, 1, 2, 'Images/image2.jpg'),
('Pride and Prejudice', 'Jane Austen', 1813, 1, 3, 'Images/image3.jpg'),
('Moby-Dick', 'Herman Melville', 1851, 1, 4, 'Images/image4.jpg'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 1, 5, 'Images/image5.jpg'),
('Taras Bulba', 'Nikolai Gogol', 1835, 1, 6, 'Images/image6.jpg'),
('Tiger hunters', 'Ivan Bagrianyi', 1929, 1, 4, 'Images/image7.jpg'),
('The Catcher in the Rye', 'J. D. Salinger', 1951, 1, 5, 'Images/image8.jpg'),
('The Hobbit', 'J. R. R. Tolkien', 1937, 1, 7, 'Images/image9.jpg'),
('The Da Vinci Code', 'Dan Brown', 2003, 1, 8, 'Images/image10.jpg'),
('Ulysses', 'James Joyce', 1922, 1, 9, 'Images/image11.jpg'),
('The Odyssey', 'Homer', -800, 1, 10, 'Images/image12.jpg'),
('Don Quixote', 'Miguel de Cervantes', 1615, 1, 3, 'Images/image13.jpg'),
('The Divine Comedy', 'Dante Alighieri', 1320, 1, 10, 'Images/image14.jpg'),
('Alice in Wonderland', 'Lewis Carroll', 1865, 1, 7, 'Images/image15.jpg');

SET IDENTITY_INSERT News ON

INSERT INTO News (newsID, title, content, publishDate) VALUES 
(1, 'New Library Opening', 'We are pleased to announce the opening of a new library branch in downtown.', '2023-06-01'),
(2, 'Book Fair Announcement', 'Join us for the annual book fair next month. Exciting new titles and guest authors will be present.', '2023-06-02'),
(3, 'Summer Reading Program', 'Sign-ups for our summer reading program are now open! Kids and adults are welcome.', '2023-06-03'),
(4, 'Author Visit', 'Bestselling author John Smith will be visiting our main branch for a book signing next week.', '2023-06-04'),
(5, 'Launch of New Book', 'We are excited to announce the launch of our new book!', '2023-06-05'),
(6, 'Book Signing Event', 'Join us for a book signing event next week.', '2023-06-06'),
(7, 'Upcoming Literature Festival', 'Mark your calendars for the upcoming Literature Festival.', '2023-06-07');

INSERT INTO Role (roleName) VALUES
('User'),
('Administrator'),
('LibraryManager');

INSERT INTO [User] ([firstName], [lastName], [phoneNumber], [email], [password], [isBlocked], [roleID]) VALUES
    ('John', 'Doe', '1234567890', 'john.doe@example.com', 'pass1234', 0, 1), -- User
    ('Jane', 'Doe', '0987654321', 'jane.doe@example.com', 'jane6789', 0, 1), -- User
    ('Bob', 'Smith', '1234567890', 'bob.smith@example.com', 'bob12XY', 0, 1), -- User
    ('Alice', 'Johnson', '0987654321', 'alice.johnson@example.com', 'alic3456', 0, 1), -- User
    ('Charlie', 'Brown', '1234567890', 'charlie.brown@example.com', 'charl789', 0, 1), -- User

    ('Admin', 'One', '1234567890', 'admin.one@example.com', 'adm1n123', 0, 2), -- Administrator
    ('Admin', 'Two', '0987654321', 'admin.two@example.com', 'adm2n456', 0, 2), -- Administrator

    ('Library', 'Manager1', '1234567890', 'library.manager1@example.com', 'libr1234', 0, 3), -- LibraryManager
    ('Library', 'Manager2', '0987654321', 'library.manager2@example.com', 'libr5678', 0, 3), -- LibraryManager
    ('Library', 'Manager3', '1234567890', 'library.manager3@example.com', 'libr90XY', 0, 3); -- LibraryManager


INSERT INTO ReaderCard (userID, bookID, borrowDate, returnDate, isBorrowed) VALUES
(1, 1, '2023-01-01', '2023-01-31', 1), -- John borrowed 'To Kill a Mockingbird' on 2023-01-01 and returned it on 2023-01-31
(2, 2, '2023-02-01', '2023-02-28', 0), -- Jane borrowed '1984' on 2023-02-01 and is still reading it
(1, 3, '2023-03-01', '2023-03-30', 1), -- John borrowed 'Pride and Prejudice' on 2023-03-01 and returned it on 2023-03-30
(3, 4, '2023-04-01', '2023-04-30', 0), -- Bob borrowed 'Moby-Dick' on 2023-04-01 and is still reading it
(2, 5, '2023-05-01', '2023-06-30', 1), -- Jane borrowed 'The Great Gatsby' on 2023-05-01 but hasn't returned it yet (set a default return date to '2023-06-30')
(3, 6, '2023-06-01', '2023-07-31', 0), -- Bob borrowed 'Taras Bulba' on 2023-06-01 but hasn't returned it yet (set a default return date to '2023-07-31')
(1, 7, '2023-07-01', '2023-07-15', 0), -- John borrowed 'Tiger hunters' on 2023-07-01 and is still reading it
(3, 8, '2023-08-01', '2023-08-30', 1), -- Bob borrowed 'The Catcher in the Rye' on 2023-08-01 and returned it on 2023-08-30
(2, 9, '2023-09-01', '2023-09-30', 0), -- Jane borrowed 'The Hobbit' on 2023-09-01 and is still reading it
(1, 10, '2023-10-01', '2023-11-30', 1); -- John borrowed 'The Da Vinci Code' on 2023-10-01 but hasn't returned it yet (set a default return date to '2023-11-30')

