using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationAPI.APIRequestModels.User
{
    public class AddRoleRequest
    {
        [Required]
        public string RoleName { get; set; }
    }
}
