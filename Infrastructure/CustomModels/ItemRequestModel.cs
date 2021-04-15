using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CustomModels
{
    public class ItemRequestModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocationCoordinates { get; set; }
        public int AreaCodeId { get; set; }
        public decimal Price { get; set; }
        public int PriceTypeId { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        public List<ItemFeature> Features { get; set; }

        public List< MediaItem> MediaItems { get; set; }
    }

    public class ItemFeature
    {


        public int FeatureId { get; set; }
        public string FeatureValue { get; set; }
    }

    public class MediaItem
    {

        public string URL { get; set; }
        public int MediaType { get; set; }
    }
}
