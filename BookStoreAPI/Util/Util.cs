using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Util
{
    public class Util
    {
        public static string GetNewId()
        {
            string id;
            id = Guid.NewGuid().ToString();
            return id;
        }
    }
}