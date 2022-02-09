CREATE PROCEDURE [dbo].[LastLoginStatistics]
AS
	SELECT Countries.Name AS 'CountryName', COUNT (Users.UserId) AS 'UsersCount', Max(Users.LastLogin) AS 'LastLoginFromCountry' FROM Countries, Cities, Users
	WHERE Users.CItyId = Cities.CityId AND Cities.CountryId = Countries.CountryId
	GROUP BY Countries.Name;
RETURN 0
