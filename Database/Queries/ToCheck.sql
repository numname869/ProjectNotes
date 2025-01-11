

DECLARE @LoginToCheck NVARCHAR(255) = 'login'

IF EXISTS (SELECT 1 FROM Konta WHERE Login = @LoginToCheck)
    SELECT 'TRUE' AS LoginExists
ELSE
    SELECT 'FALSE' AS LoginExists;

	
DECLARE @PasswordToCheck NVARCHAR(255) = 'haslo'

IF EXISTS (SELECT 1 FROM Konta WHERE Login = @PasswordToCheck)
    SELECT 'TRUE' AS PasswordExists
ELSE
    SELECT 'FALSE' AS PasswordExists;
