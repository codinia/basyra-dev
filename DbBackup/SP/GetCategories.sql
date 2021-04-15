USE RahaishDB
GO

CREATE  PROCEDURE [DBO].[GetCategories]
AS
BEGIN

		SELECT	C.Id AS CategoryId,
				c.Name AS  CategoryName,
				sb.Id AS SubCategoryId,
				SB.Name as SubCategoryName,
				F.Id AS FeatureId,
				f.Name AS FeatureName,
				FVT.Id as ValueTypeId,
				FVT.Name as ValueTypeName
		FROM	Category C
		LEFT JOIN SubCategory SB ON SB.CategoryId = C.Id
		LEFT JOIN SubCategory_Feature sf on sf.SubCategoryId = sb.Id
		INNER JOIN Feature F ON SF.FeatureId = F.Id
		INNER JOIN FeatureValueType FVT ON FVT.Id = F.ValueTypeId

END