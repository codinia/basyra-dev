using Services.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IItemRepository : IBaseRepository
    {
        void InsertItem(ItemRequestModel itemRequestModel);
    }
}
