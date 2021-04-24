using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationAPI.APIModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CustomModels;
using Services.Interfaces;

namespace AccommodationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }


        [HttpPost]
        [Route("insert-item")]

        public IActionResult InsertItem (ItemRequestModel itemRequestModel)
        {

            BasicResponse basicResponse = new BasicResponse();
            basicResponse.Data = _itemService.InsertItem(itemRequestModel);
            return Ok(basicResponse);
        }
    }
}
