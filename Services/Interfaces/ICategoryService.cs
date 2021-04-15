using Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        int AddOrUpdateCategory(CategoryDBModel categoryDBModel);
        List<CategoryModel> GetCategories();
    }
}
