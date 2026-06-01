-- CSDL dùng cho SSAS Data Mining
CREATE DATABASE AIFAS_DM;
GO

USE AIFAS_DM;
GO

CREATE TABLE DATASET (
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



USE AIFAS_DM;

-- Xóa dữ liệu cũ nếu có
TRUNCATE TABLE DATASET;

-- Copy từ AIFAS_SOURCE sang AIFAS_DM
INSERT INTO DATASET
SELECT 
    ID, Age, Gender, Education, Occupation,
    AI_Familiarity, Job_Loss_Fear, Privacy_Fear,
    Safety_Fear, Social_Impact_Fear, Overall_Fear_Score,
    AI_Usage_Frequency, Country, Income_Level, FearLevel
FROM AIFAS_SOURCE.dbo.AI_FEAR_SURVEY;

-- Kiểm tra
SELECT COUNT(*) AS TongDong FROM DATASET;
SELECT TOP 5 * FROM DATASET;




USE AIFAS_DM;

ALTER TABLE DATASET ADD ID_INT INT IDENTITY(1,1);

USE AIFAS_DM;

SELECT TOP 5 ID_INT, ID, FearLevel FROM DATASET;


USE AIFAS_DM;

SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'DATASET'
ORDER BY ORDINAL_POSITION;

-- Cấp quyền cho AIFAS_DM
USE AIFAS_DM;
EXEC sp_addrolemember 'db_datareader', 'NT SERVICE\MSOLAP$SSASMD';

-- Cấp quyền cho AIFAS_SOURCE  
USE AIFAS_SOURCE;
EXEC sp_addrolemember 'db_datareader', 'NT SERVICE\MSOLAP$SSASMD';

-- Cấp quyền cho AIFAS_STAR
USE AIFAS_STAR;
EXEC sp_addrolemember 'db_datareader', 'NT SERVICE\MSOLAP$SSASMD';