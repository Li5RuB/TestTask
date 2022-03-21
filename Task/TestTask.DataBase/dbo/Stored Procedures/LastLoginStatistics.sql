CREATE PROCEDURE [dbo].[LastLoginStatistics]
AS
    SELECT c.Name AS 'CountryName', COUNT(u.UserId) AS 'UsersCount', MAX(u.LastLogin) AS 'LastLoginFromCountry'
    FROM Users u 
    INNER JOIN Cities s ON u.CityId = s.CityId 
    INNER JOIN Countries c ON s.CountryId = c.CountryId
    GROUP BY c.Name
RETURN 0
