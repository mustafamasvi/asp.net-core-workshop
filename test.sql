select * from sys.Databases

use cityInfoDB
SELECT * from Cities

SELECT
	COLUMN_NAME
FROM
  	INFORMATION_SCHEMA.COLUMNS
WHERE
	TABLE_NAME = 'Cities'

sp_help cityInfoDB

USE master;
GO
ALTER DATABASE cityInfoDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

Drop DATABASE cityInfoDB

Use cityInfoDB
select *
from sys.tables

SELECT * from Cities
SELECT * from PointsOfInterest
select * from __EFMigrationsHistory

