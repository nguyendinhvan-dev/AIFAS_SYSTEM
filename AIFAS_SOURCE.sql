-- Tạo CSDL nguồn
CREATE DATABASE AIFAS_SOURCE;
GO

USE AIFAS_SOURCE;
GO

-- Bảng dữ liệu khảo sát gốc
CREATE TABLE AI_FEAR_SURVEY (
    ID float,
    Age float,
    Gender nvarchar(255),
    Education nvarchar(255),
    Occupation nvarchar(255),
    AI_Familiarity nvarchar(255),
    Job_Loss_Fear float,
    Privacy_Fear float,
    Safety_Fear float,
    Social_Impact_Fear float,
    Overall_Fear_Score float,
    AI_Usage_Frequency nvarchar(255),
    Country nvarchar(255),
    Income_Level nvarchar(255),
    FearLevel nvarchar(255)
);
GO



USE AIFAS_SOURCE;

CREATE USER [NT SERVICE\MSOLAP$SSASMD] 
FOR LOGIN [NT SERVICE\MSOLAP$SSASMD];

EXEC sp_addrolemember 'db_datareader', 
     [NT SERVICE\MSOLAP$SSASMD];








