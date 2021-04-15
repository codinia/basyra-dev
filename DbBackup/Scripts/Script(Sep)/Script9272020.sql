USE [RahaishDB]
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 9/27/2020 12:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[GetCategories]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT  *
	FROM	Category C
	ORDER BY C.Name
END


GO

CREATE OR ALTER PROCEDURE [dbo].[AddOrUpdateCategory] --1,'vip'
@id			INT = 0,
@name		NVARCHAR(100)
AS
BEGIN
	IF NOT EXISTS(SELECT 1
				FROM	Category
				WHERE Id=@id)
	BEGIN
		INSERT INTO Category(
						name)
					VALUES(
						@name
						)
	END
	ELSE
	BEGIN
	UPDATE Category
			SET name=@name
				WHERE Id=@id
	END
END
