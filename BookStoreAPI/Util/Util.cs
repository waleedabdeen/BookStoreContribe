using System;

namespace BookStoreAPI.Util
{
    public class Util
    {
        public static string GetNewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}