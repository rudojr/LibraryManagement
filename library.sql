create database library

use library
go

-- Tạo bảng tblPublisher
CREATE TABLE tblPublisher (
    PublisherCode VARCHAR(100) PRIMARY KEY,
    PublisherName NVARCHAR(MAX),
    Address NVARCHAR(MAX),
    Phone NVARCHAR(20) 
);

--Tạo bảng tblBook
CREATE TABLE tblBook (
    BookCode VARCHAR(100) PRIMARY KEY,
    BookName NVARCHAR(MAX),
    PublisherCode VARCHAR(100),
    FOREIGN KEY (PublisherCode) REFERENCES tblPublisher(PublisherCode)
);

--Chèn dữ liệu vào tblPublisher
INSERT INTO tblPublisher (PublisherCode, PublisherName, Address, Phone)
VALUES 
('P020202021', 'Addison Wesley', '75 Arlington St., Suite 300, Boston, MA', '113-114-0115'),
('P020202022', 'John Wiley and Sons', '605 Third Ave., New York, NY', '113-112-0117'),
('P020202023', 'McGraw Hill', '121 Ave. of The Americas, New York, NY', '113-110-0118'),
('P020202024', 'Wrox', '10475 Crosspoint Blvd., Indianapolis, IN', '114-114-0119'),
('P020202025', 'Prentice Hall PTR', '49 Sandiego, USA', '110-115-0113');

--Chèn dữ liệu vào tblBook
INSERT INTO tblBook (BookCode,BookName,PublisherCode)
VALUES
('B032120449','Introduction to The Desgin and Analysis of Algorithms','P020202021'),
('B032120450','Operating System Concepts','P020202022'),
('B032120451','Advanced Concepts in Operating System 6th','P020202023'),
('B032120452','Beginning XML 2nd','P020202024'),
('B032124053','Core Java 2 Volumne II','P020202025'),
('B032124054','A Biography Complied','P020202021'),
('B032124055','Academic Culture','P020202021'),
('B032124056','Achieving Broad Development','P020202021'),
('B032124057','Achieving a Productive Aging Society','P020202021'),
('B032124058','Portrait of a Marching Black','P020202021'),
('B032124059','Automatically Adaptable Software','P020202022'),
('B032124060','Problems in Psychology','P020202022'),
('B032124061','Human Relations in a Factory','P020202022'),
('B032124062','Adminral Halsey Story','P020202023'),
('B032124063','Theoretical and Research Perspectives','P020202024'),
('B032124064','The Adolescent in Turmoil','P020202021'),
('B032124065','Adolphus, a Tale','P020202024'),
('B032124066','Adventures','P020202021'),
('B032124067','Aerogeology','P020202021');