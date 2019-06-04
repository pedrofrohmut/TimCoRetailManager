
CREATE TABLE dbo.[User]
(
  Id INT NOT NULL PRIMARY KEY IDENTITY,
  AspNetUserId NVARCHAR(128) NOT NULL DEFAULT 'No authenticated user',
  FirstName NVARCHAR(50) NOT NULL DEFAULT 'No first name',
  LastName NVARCHAR(50) NOT NULL DEFAULT 'No last name',
  EmailAddress NVARCHAR(256) NOT NULL DEFAULT 'No e-mail',
  CreatedAt DATETIME2 NOT NULL DEFAULT getutcdate()
)