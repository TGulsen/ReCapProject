using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //Oluşturduğumuz token ve süresi tutan class
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
