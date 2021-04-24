using Services.DataModels;
using Services.Interfaces;
using Services.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region Private Members
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _categoryRepository.UnitOfWork = _unitOfWork;
        }
        public int AddOrUpdateCategory(CategoryDBModel categoryDBModel)
        {
            _unitOfWork.Open();
            try
            {
                return _categoryRepository.AddOrUpdateCategory(categoryDBModel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _unitOfWork.Close();
            }
            return 0;
        }
        public List<CategoryModel> GetCategories()
        {
            _unitOfWork.Open();
            try
            {
                List<CategoryModel> catModel = new List<CategoryModel>();
                var catDbModel = _categoryRepository.GetCategories();
                if (catDbModel != null)
                {
                    catModel = (from c in catDbModel
                                group c by
                                new
                                {
                                    c.CategoryId,
                                    c.CategoryName
                                } into cat
                                select new CategoryModel
                                {
                                    CategoryId = cat.Key.CategoryId,
                                    CategoryName = cat.Key.CategoryName,
                                    SubCategories = (from sb in catDbModel
                                                     where sb.CategoryId == cat.Key.CategoryId
                                                     group sb by new
                                                     {
                                                         sb.SubCategoryId,
                                                         sb.SubCategoryName
                                                     } into subCat

                                                     select new SubCategoryModel
                                                     {

                                                         SubCategoryId = subCat.Key.SubCategoryId,
                                                         SubCategoryName = subCat.Key.SubCategoryName,
                                                         Features = (from ft in catDbModel
                                                                     where ft.SubCategoryId ==subCat.Key.SubCategoryId
                                                                     group ft by new
                                                                     { 
                                                                     ft.FeatureId,
                                                                     ft.FeatureName,
                                                                     ft.ValueTypeId,
                                                                     ft.ValueTypeName
                                                                     } into feature
                                                                     select new FeatureModel
                                                                     { 
                                                                     
                                                                     FeatureId = feature.Key.FeatureId,
                                                                     FeatureName = feature.Key.FeatureName,
                                                                     ValueTypeId = feature.Key.ValueTypeId,
                                                                     ValueTypeName = feature.Key.ValueTypeName

                                                                     }).ToList()
                                                     }).ToList()
                                }).ToList();
                }

                return catModel;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _unitOfWork.Close();
            }
        }
    }
}
