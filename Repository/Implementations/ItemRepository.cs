using Dapper;
using Infrastructure.CustomModels;
using Newtonsoft.Json;
using Repository.Interfaces;
using Repository.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
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
