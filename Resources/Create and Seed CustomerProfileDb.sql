CREATE TABLE Customer  
(  
  Id INT IDENTITY(1,1) PRIMARY KEY,  
  FirstName NVARCHAR(100) NOT NULL,  
  LastName  NVARCHAR(100) NOT NULL,  
  Phone     NVARCHAR(20)  NOT NULL,  
  Email     NVARCHAR(255) NOT NULL  
);

-- Insert sample Customer (musicians & actors)  
INSERT INTO Customer (FirstName, LastName, Phone, Email)  
VALUES  
('Freddie', 'Mercury', '555-101-0001', 'freddie.mercury@example.com'),  
('Elvis', 'Presley', '555-101-0002', 'elvis.presley@example.com'),  
('Madonna', 'Ciccone', '555-101-0003', 'madonna.ciccone@example.com'),  
('Prince', 'Nelson', '555-101-0004', 'prince.nelson@example.com'),  
('Taylor', 'Swift', '555-101-0005', 'taylor.swift@example.com'),  
('Leonardo', 'DiCaprio', '555-202-0001', 'leonardo.dicaprio@example.com'),  
('Scarlett', 'Johansson', '555-202-0002', 'scarlett.johansson@example.com'),  
('Tom', 'Hanks', '555-202-0003', 'tom.hanks@example.com')