-- Tạo CSDL đích
CREATE DATABASE AIFAS_STAR;
GO

USE AIFAS_STAR;
GO

-- Bảng chiều: DimPerson
CREATE TABLE DimPerson (
    PersonID int PRIMARY KEY,
    Age float,
    Gender nvarchar(255),
    Education nvarchar(255),
    Occupation nvarchar(255)
);

-- Bảng chiều: DimContext
CREATE TABLE DimContext (
    ContextID int PRIMARY KEY,
    AI_Familiarity nvarchar(255),
    AI_Usage_Frequency nvarchar(255),
    Country nvarchar(255),
    Income_Level nvarchar(255)
);

-- Bảng chiều: DimTime
CREATE TABLE DimTime (
    TimeID int PRIMARY KEY,
    SurveyYear int,
    SurveyQuarter int,
    SurveyMonth int
);

-- Bảng sự kiện: FactAIFear
CREATE TABLE FactAIFear (
    RowID int PRIMARY KEY IDENTITY(1,1),
    PersonID int,
    ContextID int,
    TimeID int,
    Job_Loss_Fear float,
    Privacy_Fear float,
    Safety_Fear float,
    Social_Impact_Fear float,
    Overall_Fear_Score float,
    FearLevel nvarchar(50),
    FOREIGN KEY (PersonID) REFERENCES DimPerson(PersonID),
    FOREIGN KEY (ContextID) REFERENCES DimContext(ContextID),
    FOREIGN KEY (TimeID) REFERENCES DimTime(TimeID)
);
GO



USE AIFAS_STAR;

-- Kiểm tra số dòng từng bảng
SELECT 'DimPerson'  AS Bang, COUNT(*) AS SoDong FROM DimPerson
UNION ALL
SELECT 'DimContext' AS Bang, COUNT(*) AS SoDong FROM DimContext
UNION ALL
SELECT 'DimTime'    AS Bang, COUNT(*) AS SoDong FROM DimTime
UNION ALL
SELECT 'FactAIFear' AS Bang, COUNT(*) AS SoDong FROM FactAIFear;

-- Xem thử 5 dòng FactAIFear
SELECT TOP 5 * FROM FactAIFear;