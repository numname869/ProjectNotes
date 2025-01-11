DECLARE @LoginToCheck NVARCHAR(255) = 'test_user';
DECLARE @PasswordToCheck NVARCHAR(255) = 'test_password';

-- Sprawdzanie, czy login istnieje
IF EXISTS (SELECT 1 FROM Konta WHERE Login = @LoginToCheck)
    SELECT 'TRUE' AS LoginExists
ELSE
    SELECT 'FALSE' AS LoginExists;

-- Sprawdzanie, czy login i hasło pasują
IF EXISTS (SELECT 1 FROM Konta WHERE Login = @LoginToCheck AND [Hasło] = @PasswordToCheck)
    SELECT 'TRUE' AS LoginPasswordMatch
ELSE
    SELECT 'FALSE' AS LoginPasswordMatch;
