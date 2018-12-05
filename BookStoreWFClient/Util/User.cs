namespace BookStoreWFClient.Util
{
    class User
    {
        public static string Email { get; set; }

        public static string Token { get; set; }

        public static bool IsLoggedIn()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return false;
            }
            return true;
        }
    }
}
