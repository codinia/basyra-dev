using Infrastructure.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IItemService
    {
        bool InsertItem(ItemRequestModel itemRequestModel);

    }
}
