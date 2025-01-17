

SELECT *
FROM Konta

USE AnimalCareDB
GO



EXEC sp_rename 'Konta.[Has�o]', 'Haslo', COLUMN;


EXEC sp_rename 'dbo.Konta.[Has�o]', 'Haslo', 'COLUMN';

ALTER TABLE Konta CHANGE [COLUMN] [Has�o] Hasło


EXEC sp_rename 'dbo.Konta.Has�o', 'Haslo', 'COLUMN';