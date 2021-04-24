using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICategoryRepository : IBaseRepository
    {
        List<CategoryDBModel> GetCategories();
        int AddOrUpdateCategory(CategoryDBModel categoryDBModel);
    }
}
