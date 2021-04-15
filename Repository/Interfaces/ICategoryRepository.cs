using Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICategoryRepository : IBaseRepository
    {
        List<CategoryDBModel> GetCategories();
        int AddOrUpdateCategory(CategoryDBModel categoryDBModel);
    }
}
