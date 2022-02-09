CREATE PROCEDURE [dbo].[CountStatistics]
	@UsersCount int = 0 output,
	@CountriesCount int = 0 output ,
	@CitiesCount int = 0 output 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT @UsersCount = COUNT (UserId) FROM Users;
	SELECT @CountriesCount = COUNT (CountryId) FROM Countries;
	SELECT @CitiesCount = COUNT (CityId) FROM Cities;

	SELECT @UsersCount as UsersCount, @CountriesCount as CountriesCount, @CitiesCount as CitiesCount
RETURN
END
GO
