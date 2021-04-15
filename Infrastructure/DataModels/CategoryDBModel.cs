using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataModels
{
    public class CategoryDBModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int FeatureId { get; set; }

        public string FeatureName { get; set; }
        public int ValueTypeId { get; set; }
        public string ValueTypeName { get; set; }
    }

    public class CategoryModel

    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<SubCategoryModel> SubCategories { get; set; }

    }

    public class SubCategoryModel
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public List<FeatureModel> Features { get; set; }
    }

    public class FeatureModel
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }

        public int ValueTypeId { get; set; }
        public string ValueTypeName { get; set; }
    }
}
