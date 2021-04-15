using Infrastructure.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IItemRepository : IBaseRepository
    {
        void InsertItem(ItemRequestModel itemRequestModel);
    }
}
