using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi
{
    public class Security
    {
        public static string Token = "123456789"; //not very safe =)


        public static bool TokenIsValid(string token) => token == Token;

    }
}
