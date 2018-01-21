CREATE PROCEDURE [dbo].[RetriveRecords]
AS
	SELECT PhoneBook.FirstName,
			PhoneBook.LastName,
			PhoneBook.Address,
			PhoneBook.PhoneNumber,
			PhoneBook.Image
	FROM PhoneBook
	ORDER BY PhoneBook.FirstName
RETURN 0