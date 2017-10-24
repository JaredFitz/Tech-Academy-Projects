/*
These instructions will create a database titled db_library and populate it with example information.  It
also will create 7 procedures to be used as examples of queries to run with the database. These 
procedures are explained below.  The entire program must be run in order to create the database and
procedures.

Drill1:Returns how many compies of the Book titled "The Lost Tribe" are owned by the Sharpstown branch
Drill2:Returns a view of how many copies of the book titled "The Lost Tribe" are owned by each branch
Drill3:Returns all Borrowers who do not have books checked out
Drill4:Returns all books from the Sharpstown branch that are due today (based on system date)
Drill5:Returns the total number of books loaned out from each branch
Drill6:Returns all Borrowers who have at least 5 books checked out
Drill7:Returns each book authored by Stephen King (and how many) that is owned by the Central library branch

-Jared Fitzpatrick, 10/2017
*/

CREATE DATABASE db_library
GO
USE db_library
GO

CREATE SCHEMA [Book] AUTHORIZATION [dbo]
GO

Create Table Publisher (
	Pub_Name VARCHAR(50) PRIMARY KEY NOT NULL,
	Pub_Address VARCHAR(100) NOT NULL,
	Pub_Phone VARCHAR(20) NOT NULL
);

INSERT INTO Publisher
	(Pub_Name, Pub_Address, Pub_Phone)
	VALUES
	('Bantam Books','1745 Broadway, New York, NY 10019', '(212)782-9000'),
	('Mariner Books','215 Park Avenue South, New York, NY 10003','(800)225-3362'),
	('Orbit','1290 6th Ave, New York, NY 10104', '(212)364-1100'),
	('Scribner','1290 6th Ave, New York, NY 10104', '(212)364-1100'),
	('Little, Brown and Company','1290 6th Ave, New York, NY 10104', '(212)364-1100'),
	('Harper Perennial','195 Broadway, New York, NY 10007','(800)242-7737'),
	('Penguin Books','80 Strand, London WC2R 0RL, UK','+44-0-20-7010-3000'),
	('Anchor','1745 Broadway, New York, NY 10019','(212)782-9000'),
	('BootCamp Programming','310 SW 4th Ave Suite 412, Portland, OR 97204','(503)206-6915'),
	('Doubleday','1745 Broadway, New York, NY 10019', '(212)782-9000');

CREATE TABLE Borrower (
	Bor_CardNo VARCHAR(20) PRIMARY KEY NOT NULL,
	Bor_Name VARCHAR (50) NOT NULL,
	Bor_Address VARCHAR(100) NOT NULL,
	Bor_Phone VARCHAR(20) NOT NULL
);

INSERT INTO Borrower
	(Bor_CardNo,Bor_Name,Bor_Address,Bor_Phone)
	VALUES
	('12632','Terry Stotts','100 Moda Center, Portland, OR 97227','(987-555-4321'),
	('74313','Jusuf Nurkic','27 Moda Center, Portland, OR 97227','937-555-1234'),
	('82742','Maurice Harkless','4 Moda Center, Portland, OR 97227','284-555-1832'),
	('20142','Damian Lillard','0 Moda Center, Portland, OR 97227','685-555-8843'),
	('38291','CJ McCollum','3 Moda Center, Portland, OR 97227','992-555-0012'),
	('98742','Evan Turner','1 Moda Center, Portland, OR 97227','722-555-8845'),
	('38494','Ed Davis','17 Moda Center, Portland, OR 97227','272-555-1112'),
	('12940','Al-Farouq Aminu','8 Moda Center, Portland, OR 97227','855-555-2822'),
	('19283','Zach Collins','33 Moda Center, Portland, OR 97227','829-555-0098'),
	('19295','Jake Layman','10 Moda Center, Portland, OR 97227','282-555-6666'),
	('18236','Meyers Leonard','11 Moda Center, Portland, OR 97227','821-555-7765'),
	('12929','Caleb Swanigan','50 Moda Center, Portland, OR 97227','554-555-6789'),
	('12377','Noah Vonleh','21 Moda Center, Portland, OR 97227','721-555-5443'),
	('18328','Shabazz Napier','6 Moda Center, Portland, OR 97227','712-555-8328');

CREATE TABLE Library_Branch (
	Branch_id VARCHAR(20) PRIMARY KEY NOT NULL,
	Branch_Name VARCHAR(30) NOT NULL,
	Branch_Address VARCHAR(100) NOT NULL
);

INSERT INTO Library_Branch
	(Branch_id,Branch_Name,Branch_Address)
	VALUES
	('LB098765','Sharpstown','8021 SW Fake Ave, Portland, OR 97219'),
	('LB739213','Central','2341 NE Not Real St, Portland, OR 97204'),
	('LB320239','Northern','2341 NE Not Real St, Portland, OR 97204'),
	('LB112437','Dulltown','2341 NE Not Real St, Portland, OR 97204');

CREATE TABLE Book.Book (
	Book_id VARCHAR(20) PRIMARY KEY NOT NULL,
	Book_Title VARCHAR(50) NOT NULL,
	Book_PublisherName VARCHAR(50) NOT NULL CONSTRAINT fk_Book_Pub_Name FOREIGN KEY REFERENCES Publisher(Pub_Name)
);

INSERT INTO Book.Book
	(Book_id,Book_Title,Book_PublisherName)
	VALUES
	('978-0553593716','A Game of Thrones','Bantam Books'),
	('978-0553579901','A Clash of Kings','Bantam Books'),
	('978-0553573428','A Storm of Swords','Bantam Books'),
	('978-0553582024','A Feast for Crows','Bantam Books'),
	('978-0553582017','A Dance with Dragons','Bantam Books'),
	('978-0547928210','The Lord of the Rings: The Fellowship of the Ring','Mariner Books'),
	('978-0547928203','The Lord of the Rings: The Two Towers','Mariner Books'),
	('978-0547928197','The Lord of the Rings: The Return of the King','Mariner Books'),
	('978-0316387316','The Blade Itself','Orbit'),
	('978-0316387354','Before They Are Hanged','Orbit'),
	('978-0316387408','Last Argument of Kings','Orbit'),
	('978-0743273565','The Great Gatsby','Scribner'),
	('978-0316769488','The Catcher in the Rye','Little, Brown and Company'),
	('978-0060935467','To Kill a Mockingbird','Harper Perennial'),
	('978-0452296299','The Magicians: A Novel','Penguin Books'),
	('978-0452298019','The Magician King: A Novel','Penguin Books'),
	('978-0147516145','The Magicians Land: A Novel','Penguin Books'),
	('978-0307743657','The Shining','Anchor'),
	('978-0307743671','Salems Lot','Anchor'),
	('111-1111111111','The Lost Tribe','BootCamp Programming'),
	('978-0385535663','The Risen: A Novel of Spartacus','Doubleday'),
	('978-0307947307','The Stand','Anchor'),
	('978-0307743664','Carrie','Anchor');

CREATE TABLE Book.Authors (
	Auth_Book_id VARCHAR(20) PRIMARY KEY NOT NULL CONSTRAINT fk_Auth_Book_id FOREIGN KEY REFERENCES Book.Book(Book_id) ON DELETE CASCADE,
	Auth_AuthorName VARCHAR(50) NOT NULL
);

INSERT INTO Book.Authors
	(Auth_Book_id,Auth_AuthorName)
	VALUES
	('978-0553593716','George R. R. Martin'),
	('978-0553579901','George R. R. Martin'),
	('978-0553573428','George R. R. Martin'),
	('978-0553582024','George R. R. Martin'),
	('978-0553582017','George R. R. Martin'),
	('978-0547928210','J.R.R. Tolkien'),
	('978-0547928203','J.R.R. Tolkien'),
	('978-0547928197','J.R.R. Tolkien'),
	('978-0316387316','Joe Abercrombie'),
	('978-0316387354','Joe Abercrombie'),
	('978-0316387408','Joe Abercrombie'),
	('978-0743273565','F. Scott Fitzgerald'),
	('978-0316769488','J.D. Salinger'),
	('978-0060935467','Harper Lee'),
	('978-0452296299','Lev Grossman'),
	('978-0452298019','Lev Grossman'),
	('978-0147516145','Lev Grossman'),
	('978-0307743657','Stephen King'),
	('978-0307743671','Stephen King'),
	('978-0307947307','Stephen King'),
	('978-0307743664','Stephen King'),
	('111-1111111111','Tech Academy'),
	('978-0385535663','David Anthony Durham');

CREATE TABLE Book.Copies (
	Cop_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Cop_Book_id VARCHAR(20) NOT NULL CONSTRAINT fk_Copies_Book_id FOREIGN KEY REFERENCES Book.Book(Book_id),
	Cop_Branch_id VARCHAR(20) NOT NULL CONSTRAINT fk_Copies_Branch_id FOREIGN KEY REFERENCES Library_Branch(Branch_id),
	Cop_No_Of_Copies INT NOT NULL
);

INSERT INTO Book.Copies
	(Cop_Book_id,Cop_Branch_id,Cop_No_Of_Copies)
	VALUES
	('978-0553593716','LB098765','2'),
	('978-0553579901','LB098765','2'),
	('978-0553573428','LB098765','2'),
	('978-0553582024','LB098765','3'),
	('978-0553582017','LB098765','6'),
	('978-0547928210','LB739213','5'),
	('978-0547928203','LB739213','3'),
	('978-0547928197','LB739213','4'),
	('978-0316387316','LB098765','2'),
	('978-0316387354','LB739213','2'),
	('978-0316387408','LB739213','2'),
	('978-0743273565','LB098765','3'),
	('978-0316769488','LB739213','5'),
	('978-0060935467','LB739213','7'),
	('978-0452296299','LB739213','3'),
	('978-0307947307','LB739213','3'),
	('978-0307743664','LB739213','2'),
	('978-0452298019','LB098765','2'),
	('978-0147516145','LB098765','2'),
	('978-0307743657','LB098765','3'),
	('978-0307743671','LB739213','4'),
	('111-1111111111','LB739213','3'),
	('978-0385535663','LB098765','2'),
	('978-0316387316','LB320239','3'),
	('978-0316387354','LB320239','3'),
	('978-0316387408','LB320239','5'),
	('978-0743273565','LB320239','4'),
	('978-0316769488','LB320239','3'),
	('978-0060935467','LB320239','3'),
	('978-0452296299','LB320239','3'),
	('978-0452298019','LB320239','2'),
	('978-0147516145','LB320239','2'),
	('978-0307743657','LB320239','2'),
	('978-0307743671','LB320239','3'),
	('111-1111111111','LB320239','4'),
	('978-0385535663','LB320239','5'),
	('978-0553579901','LB112437','2'),
	('978-0553573428','LB112437','3'),
	('978-0553582024','LB112437','3'),
	('978-0553582017','LB112437','5'),
	('978-0547928210','LB112437','4'),
	('978-0547928203','LB112437','3'),
	('978-0547928197','LB112437','3'),
	('978-0316387316','LB112437','2'),
	('978-0316387354','LB112437','3'),
	('978-0316387408','LB112437','2'),
	('978-0743273565','LB112437','2'),
	('978-0316769488','LB112437','2'),
	('978-0060935467','LB112437','5'),
	('978-0452296299','LB112437','3'),
	('111-1111111111','LB112437','2'),
	('111-1111111111','LB098765','3');

CREATE TABLE Book.Loans (
	Loan_Book_id VARCHAR(20) NOT NULL CONSTRAINT fk_Loans_Book_id FOREIGN KEY REFERENCES Book.Book(Book_id),
	Loan_Branch_id VARCHAR(20) NOT NULL CONSTRAINT fk_Loans_Branch_id FOREIGN KEY REFERENCES Library_Branch(Branch_id),
	Loan_Bor_CardNo VARCHAR(20) NOT NULL CONSTRAINT fk_Loans_Bor_CardNo FOREIGN KEY REFERENCES Borrower(Bor_CardNo),
	Loan_DateOut DATE NOT NULL,
	Loan_DueDate DATE NOT NULL
);

INSERT INTO Book.Loans
	(Loan_Book_id,Loan_Branch_id,Loan_Bor_CardNo,Loan_DateOut,Loan_DueDate)
	VALUES
	('111-1111111111','LB112437','74313','2017-10-15','2017-10-29'),
	('978-0060935467','LB112437','74313','2017-10-16','2017-10-30'),
	('978-0316387316','LB112437','74313','2017-10-17','2017-10-31'),
	('978-0316387354','LB112437','74313','2017-10-15','2017-10-29'),
	('978-0316387408','LB112437','74313','2017-10-17','2017-10-31'),
	('978-0553582017','LB098765','74313','2017-10-09','2017-10-23'),
	('111-1111111111','LB112437','82742','2017-10-18','2017-11-01'),
	('978-0316387354','LB112437','82742','2017-10-18','2017-11-01'),
	('978-0316769488','LB112437','82742','2017-10-18','2017-11-01'),
	('978-0743273565','LB112437','82742','2017-10-19','2017-11-02'),
	('978-0060935467','LB739213','82742','2017-10-09','2017-10-23'),
	('111-1111111111','LB320239','20142','2017-10-21','2017-11-04'),
	('978-0147516145','LB320239','20142','2017-10-20','2017-11-03'),
	('978-0316769488','LB320239','20142','2017-10-20','2017-11-03'),
	('978-0452296299','LB320239','20142','2017-10-21','2017-11-04'),
	('978-0307743657','LB320239','20142','2017-10-21','2017-11-04'),
	('978-0307743671','LB320239','20142','2017-10-21','2017-11-04'),
	('978-0743273565','LB320239','20142','2017-10-21','2017-11-04'),
	('978-0547928210','LB739213','38291','2017-10-21','2017-11-04'),
	('978-0547928197','LB739213','38291','2017-10-23','2017-11-06'),
	('978-0316387408','LB739213','38291','2017-10-23','2017-11-06'),
	('978-0307743671','LB739213','38291','2017-10-23','2017-11-06'),
	('978-0060935467','LB739213','98742','2017-10-23','2017-11-06'),
	('978-0316387354','LB739213','98742','2017-10-23','2017-11-06'),
	('978-0316769488','LB739213','98742','2017-10-23','2017-11-06'),
	('978-0452296299','LB739213','98742','2017-10-23','2017-11-06'),
	('978-0385535663','LB320239','38494','2017-10-22','2017-11-05'),
	('978-0316387316','LB320239','38494','2017-10-22','2017-11-05'),
	('978-0060935467','LB320239','38494','2017-10-09','2017-10-23'),
	('111-1111111111','LB320239','38494','2017-10-09','2017-10-23'),
	('978-0307743657','LB320239','38494','2017-10-12','2017-10-26'),
	('978-0147516145','LB320239','38494','2017-10-13','2017-10-27'),
	('978-0316387408','LB320239','38494','2017-10-14','2017-10-28'),
	('978-0316769488','LB320239','38494','2017-10-15','2017-10-29'),
	('978-0553582017','LB098765','38494','2017-10-18','2017-11-01'),
	('978-0553582024','LB098765','38494','2017-10-18','2017-11-01'),
	('978-0147516145','LB098765','19283','2017-10-18','2017-11-01'),
	('978-0553579901','LB098765','19283','2017-10-18','2017-11-01'),
	('978-0553582017','LB098765','19283','2017-10-19','2017-11-02'),
	('978-0553593716','LB098765','19295','2017-10-21','2017-11-04'),
	('978-0743273565','LB098765','19295','2017-10-20','2017-11-03'),
	('978-0385535663','LB098765','19295','2017-10-20','2017-11-03'),
	('978-0452298019','LB098765','19295','2017-10-21','2017-11-04'),
	('978-0547928197','LB112437','18236','2017-10-21','2017-11-04'),
	('978-0547928203','LB112437','18236','2017-10-21','2017-11-04'),
	('978-0547928210','LB112437','18236','2017-10-21','2017-11-04'),
	('978-0553582017','LB098765','12929','2017-10-21','2017-11-04'),
	('978-0553582024','LB098765','12929','2017-10-23','2017-11-06'),
	('978-0743273565','LB098765','12929','2017-10-23','2017-11-06'),
	('978-0307743657','LB098765','12929','2017-10-09','2017-10-23');

GO
CREATE PROC dbo.Drill1
AS
BEGIN
	--Returns how many compies of the Book titled "The Lost Tribe" are owned by the Sharpstown branch
	SELECT c.Book_Title AS "Book Title", b.Branch_Name AS "Library Branch", a.Cop_No_Of_Copies AS "Number of Copies"
	FROM Book.Copies a
		INNER JOIN Library_Branch b ON a.Cop_Branch_id=b.Branch_id
		INNER JOIN Book.Book c ON a.Cop_Book_id=c.Book_id
	WHERE b.Branch_Name = 'Sharpstown'
	AND c.Book_Title = 'The Lost Tribe';
END

GO

CREATE PROC dbo.Drill2
AS
BEGIN
	--Returns a view of how many copies of the book titled "The Lost Tribe" are owned by each branch
	SELECT c.Book_Title AS "Book Title", b.Branch_Name AS "Library Branch", a.Cop_No_Of_Copies AS "Number of Copies"
	FROM Book.Copies a
		INNER JOIN Library_Branch b ON a.Cop_Branch_id=b.Branch_id
		INNER JOIN Book.Book c ON a.Cop_Book_id=c.Book_id
	WHERE c.Book_Title = 'The Lost Tribe';
END

GO

CREATE PROC dbo.Drill3
AS
BEGIN
	--Returns all Borrowers who do not have books checked out
	SELECT b.Bor_Name AS "Name", COUNT(a.Loan_Bor_CardNo) AS "Books Checked out"
	FROM Book.Loans a
		FULL OUTER JOIN Borrower b ON a.Loan_Bor_CardNo=b.Bor_CardNo
	GROUP BY b.Bor_Name
	HAVING COUNT(a.Loan_Bor_CardNo) = 0;
END

GO

CREATE PROC dbo.Drill4
AS
BEGIN
	--Returns all books from the Sharpstown branch that are due today (based on system date)
	SELECT a.Loan_DueDate AS "Due Date", c.Book_Title AS "Book", e.Bor_Name AS "Name", e.Bor_Address AS "Address"
	FROM Book.Loans a 
		INNER JOIN Library_Branch b ON b.Branch_id = a.Loan_Branch_id
		INNER JOIN Book.Book c ON c.Book_id = a.Loan_Book_id
		INNER JOIN Borrower e ON e.Bor_CardNo = a.Loan_Bor_CardNo
	WHERE b.Branch_Name = 'Sharpstown'
	AND a.Loan_DueDate = CONVERT(date,GETDATE()); -- converts the GETDATE to just the date with no time
END

GO

CREATE PROC dbo.Drill5
AS
BEGIN
	--Returns the total number of books loaned out from each branch
	SELECT b.Branch_Name AS "Branch Name", Count(a.Loan_Branch_id) AS "Books Checked Out"
	FROM Book.Loans a
		FULL OUTER JOIN Library_Branch b ON b.Branch_id = a.Loan_Branch_id
	GROUP BY b.Branch_Name;
END

GO

CREATE PROC dbo.Drill6
AS
BEGIN
	--Returns all Borrowers who have at least 5 books checked out
	SELECT b.Bor_Name AS "Name", COUNT(a.Loan_Bor_CardNo) AS "Books Checked out"
	FROM Book.Loans a
		FULL OUTER JOIN Borrower b ON a.Loan_Bor_CardNo=b.Bor_CardNo
	GROUP BY b.Bor_Name
	HAVING COUNT(a.Loan_Bor_CardNo) >=5;
END

GO

CREATE PROC dbo.Drill7
AS
BEGIN
	--Returns each book authored by Stephen King (and how many) that is owned by the Central library branch
	SELECT c.Book_Title AS "Book", a.Cop_No_Of_Copies AS "Number of Copies"
	FROM Book.Copies a
		INNER JOIN Book.Authors b ON b.Auth_Book_id=a.Cop_Book_id
		INNER JOIN Book.Book c ON c.Book_id = a.Cop_Book_id
		INNER JOIN Library_Branch e ON a.Cop_Branch_id = e.Branch_id
	 WHERE e.Branch_Name = 'Central' 
	AND b.Auth_AuthorName = 'Stephen King';
END

Go