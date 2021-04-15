using Dapper;
using Infrastructure.DataModels;
using Repository.Interfaces;
using Repository.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public int AddOrUpdateCategory(CategoryDBModel categoryDBModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@id", categoryDBModel.CategoryId);
                param.Add("@name", categoryDBModel.CategoryName);
                return UnitOfWork.Connection.Execute("AddOrUpdateCategory", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CategoryDBModel> GetCategories()
        {
            try
            {
                const string storedProcedureName = "GetCategories";
                return UnitOfWork.Connection.Query<CategoryDBModel>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CategoryDBModel> GetSubCategories(int categoryId)
        {
            try
            {
                const string storedProcedureName = "GetCategories";
                return UnitOfWork.Connection.Query<CategoryDBModel>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
