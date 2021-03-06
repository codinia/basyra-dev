﻿using Services.CustomModels;
using Services.Interfaces;
using Services.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
   public class ItemService :IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _itemRepository.UnitOfWork = unitOfWork;

        }

        public bool InsertItem(ItemRequestModel itemRequestModel)
        {
            try
            {
                _itemRepository.InsertItem(itemRequestModel);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }
    }
}
