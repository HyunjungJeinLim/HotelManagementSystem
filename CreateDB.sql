-- 1. Create the database
USE master;
GO

IF DB_ID('HotelManagement') IS NOT NULL
    DROP DATABASE HotelManagement;
GO

CREATE DATABASE HotelManagement;
GO

USE HotelManagement;
GO

-- 2. Create the Rooms table
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomType NVARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Amenities NVARCHAR(MAX),
    Availability BIT NOT NULL,
    RoomNumber NVARCHAR(10) UNIQUE NOT NULL,
    CleaningStatus INT NOT NULL DEFAULT 0 -- 0: Dirty, 1: Clean, 2: Under Maintenance
);
GO

ALTER TABLE Rooms
ADD CONSTRAINT DF_Availability DEFAULT 1 FOR Availability;

ALTER TABLE Rooms
ADD CONSTRAINT DF_Amenities DEFAULT 'Wi-Fi' FOR Amenities;
GO

-- 3. Create the Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

-- 4. Create the Bookings table
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
    RoomID INT NOT NULL FOREIGN KEY REFERENCES Rooms(RoomID),
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    BookingStatus NVARCHAR(20) NOT NULL
);
GO

-- 5. Insert initial data into the Rooms table
INSERT INTO Rooms (RoomType, Price, Amenities, Availability, RoomNumber, CleaningStatus)
VALUES
    ('Single', 100.00, 'Wi-Fi, Breakfast', 1, 'R001', 1), -- Clean
    ('Double', 150.00, 'Wi-Fi, Pool', 1, 'R002', 0),      -- Dirty
    ('Suite', 300.00, 'Wi-Fi, Breakfast, Pool, Gym', 1, 'R003', 2), -- Under Maintenance
    ('Single', 120.00, 'Wi-Fi, Parking', 0, 'R004', 1),  -- Clean
    ('Double', 180.00, 'Wi-Fi, Breakfast, Pool', 1, 'R005', 0), -- Dirty
    ('Suite', 350.00, 'Wi-Fi, Breakfast, Spa', 0, 'R006', 2), -- Under Maintenance
    ('Single', 130.00, 'Wi-Fi, Breakfast, Gym', 1, 'R007', 1), -- Clean
    ('Double', 200.00, 'Wi-Fi, Pool, Spa', 1, 'R008', 0), -- Dirty
    ('Suite', 400.00, 'Wi-Fi, Breakfast, Pool, Lounge', 0, 'R009', 2), -- Under Maintenance
    ('Single', 90.00, 'Wi-Fi, Parking', 0, 'R010', 1),   -- Clean
    ('Double', 170.00, 'Wi-Fi, Breakfast', 1, 'R011', 0), -- Dirty
    ('Suite', 380.00, 'Wi-Fi, Breakfast, Gym, Spa', 0, 'R012', 2), -- Under Maintenance
	('Single', 110.00, 'Wi-Fi, TV', 1, 'R013', 1), -- Clean
    ('Double', 160.00, 'Wi-Fi, Breakfast', 1, 'R014', 0), -- Dirty
    ('Suite', 370.00, 'Wi-Fi, Pool, Gym', 1, 'R015', 2), -- Under Maintenance
    ('Single', 100.00, 'Wi-Fi, Parking', 1, 'R016', 1), -- Clean
    ('Double', 190.00, 'Wi-Fi, Breakfast, Pool', 1, 'R017', 1), -- Clean
    ('Suite', 400.00, 'Wi-Fi, Lounge, Spa', 1, 'R018', 0); -- Dirty
GO

-- 6. Insert initial data into the Customers table
INSERT INTO Customers (FirstName, LastName, Phone, Email)
VALUES
    ('John', 'Doe', '1234567890', 'john.doe@example.com'),
    ('Jane', 'Smith', '0987654321', 'jane.smith@example.com'),
    ('Alice', 'Brown', '5678901234', 'alice.brown@example.com'),
    ('Bob', 'Johnson', '4567890123', 'bob.johnson@example.com'),
    ('Charlie', 'Davis', '3456789012', 'charlie.davis@example.com'),
    ('Eve', 'Adams', '1112223333', 'eve.adams@example.com'),
    ('Grace', 'Clark', '4445556666', 'grace.clark@example.com'),
    ('Mallory', 'Taylor', '7778889999', 'mallory.taylor@example.com'),
    ('Oscar', 'Miller', '2223334444', 'oscar.miller@example.com'),
    ('Peggy', 'Wilson', '5556667777', 'peggy.wilson@example.com');
GO

-- 7. Insert initial data into the Bookings table for Jan-Dec 2024
INSERT INTO Bookings (CustomerID, RoomID, CheckInDate, CheckOutDate, TotalPrice, BookingStatus)
VALUES
    -- January 2024
    (1, 1, '2024-01-05', '2024-01-10', 500.00, 'Confirmed'),
    (2, 2, '2024-01-15', '2024-01-20', 800.00, 'Confirmed'),
    -- February 2024
    (3, 3, '2024-02-01', '2024-02-05', 1000.00, 'Canceled'),
    (4, 4, '2024-02-12', '2024-02-18', 720.00, 'Confirmed'),
    -- March 2024
    (5, 5, '2024-03-01', '2024-03-05', 600.00, 'Confirmed'),
    (6, 6, '2024-03-10', '2024-03-15', 900.00, 'Pending'),
    -- April 2024
    (7, 7, '2024-04-05', '2024-04-10', 550.00, 'Confirmed'),
    (8, 8, '2024-04-15', '2024-04-20', 850.00, 'Canceled'),
    -- May 2024
    (9, 9, '2024-05-01', '2024-05-05', 1000.00, 'Confirmed'),
    (10, 10, '2024-05-10', '2024-05-15', 720.00, 'Confirmed'),
    -- June 2024
    (1, 1, '2024-06-05', '2024-06-10', 500.00, 'Confirmed'),
    (2, 2, '2024-06-15', '2024-06-20', 800.00, 'Canceled'),
    -- July 2024
    (3, 3, '2024-07-01', '2024-07-05', 1100.00, 'Confirmed'),
    (4, 4, '2024-07-10', '2024-07-15', 650.00, 'Confirmed'),
    -- August 2024
    (5, 5, '2024-08-01', '2024-08-05', 500.00, 'Canceled'),
    (6, 6, '2024-08-15', '2024-08-20', 900.00, 'Confirmed'),
    -- September 2024
    (7, 7, '2024-09-05', '2024-09-10', 550.00, 'Confirmed'),
    (8, 8, '2024-09-12', '2024-09-18', 720.00, 'Canceled'),
    -- October 2024
    (9, 9, '2024-10-01', '2024-10-05', 1000.00, 'Confirmed'),
    (10, 10, '2024-10-12', '2024-10-16', 680.00, 'Confirmed'),
    -- November 2024
    (3, 3, '2024-11-20', '2024-11-25', 1500.00, 'Canceled'),
    (7, 8, '2024-11-28', '2024-12-02', 800.00, 'Confirmed'),
    -- December 2024
    (1, 1, '2024-12-01', '2024-12-05', 400.00, 'Confirmed'),
    (2, 2, '2024-12-10', '2024-12-15', 750.00, 'Confirmed'),
    (4, 5, '2024-12-20', '2024-12-25', 900.00, 'Confirmed'),
    (5, 6, '2024-12-30', '2025-01-03', 1400.00, 'Confirmed'),
    (6, 7, '2024-12-15', '2024-12-18', 390.00, 'Pending'),
    (8, 9, '2024-12-05', '2024-12-08', 1200.00, 'Confirmed'),
    (10, 11, '2024-12-12', '2024-12-16', 680.00, 'Confirmed');


-- Test Queries
SELECT * FROM Rooms;
SELECT * FROM Customers;
SELECT * FROM Bookings;

