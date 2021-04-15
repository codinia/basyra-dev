using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Cache
{
    public class AppSettings
    {

        #region Jwt (Json Web Token)
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtExpireTime { get; set; }
        #endregion

    }
}
