CREATE PROCEDURE [dbo].[LastLoginStatistics]
AS
    SELECT c.Name AS 'CountryName', Count(u.UserId) AS 'UsersCount', Max(u.LastLogin) AS 'LastLoginFromCountry'
    FROM Users u inner join Cities s on u.CityId = s.CityId inner join Countries c on s.CountryId = c.CountryId
    Group by c.Name
RETURN 0
