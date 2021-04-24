using Dapper;
using Newtonsoft.Json;
using Services.CustomModels;
using Services.Interfaces;
using Services.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ItemRepository : IItemRepository
    {

        public IUnitOfWork UnitOfWork { get; set; }

        public void InsertItem(ItemRequestModel itemRequestModel)
        {
            try
            {
                string sp = "InsertItem";
                string json = JsonConvert.SerializeObject(itemRequestModel);
                var param = new DynamicParameters();
                param.Add("@json", json);
                UnitOfWork.Connection.Execute(sp, param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
