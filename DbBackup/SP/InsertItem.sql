USE RahaishDB

GO

CREATE or alter PROCEDURE [DBO].[InsertItem] 

@json NVARCHAR(MAX)

AS

BEGIN

	BEGIN TRAN
		BEGIN TRY

			INSERT INTO Item (UserId, Name, Description, AreaCodeId, Price, PriceTypeId, SubCategoryId, IsDeleted, IsAvailable)
				SELECT * FROM OPENJSON (@json)
						WITH (
						UserId Nvarchar(50) '$.UserId',
						Name nvarchar(500) '$.Name',
						Description nvarchar(max) '$.Description',
						AreaCodeId int '$.AreaCodeId',
						Price numeric (18,0) '$.Price',
						PriceTypeId smallint '$.PriceTypeId',
						SubCategoryId int '$.SubCategoryId',
						IsDeleted bit '$.IsDeleted',
						IsAvailable bit '$.IsAvailable'
						)

			DECLARE @ItemId INT = (SELECT SCOPE_IDENTITY())


			INSERT INTO Item_Feature (FeatureId, FeatureValue,ItemId) 
					SELECT FeatureId,FeatureValue, @itemId FROM OpenJson (@json,'$.Features')
							WITH (
							FeatureId int '$.FeatureId',
							FeatureValue nvarchar(50) '$.FeatureValue'
							)

			INSERT INTO ItemMedia (URL , MediaType , ItemId)
					SELECT URL, MediaType, @ItemId FROM openjson (@json, '$.MediaItems')
					WITH (
						URL nvarchar (50) '$.URL',
						MediaType int '$.MediaType'
					)
			INSERT INTO ItemChangeLog (ChangeTypeId, ItemId ,  CreatedOn, CreatedBy)
				SELECT 1, Id, GETDATE(),UserId
				FROM Item WHERE Id = @ItemId

		COMMIT TRAN

		END TRY
		BEGIN CATCH
			ROLLBACK TRAN;

			    THROW;  
		END CATCH

END