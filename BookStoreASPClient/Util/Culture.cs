using System.Globalization;
using System.Threading;

namespace BookStoreASPClient.Util
{
    class Culture
    {
        private static string defaultCulture;

        public static string DefatultCulture
        {
            get
            {
                if(string.IsNullOrEmpty(defaultCulture))
                {
                    defaultCulture = "se";
                }
                return defaultCulture;
            }
            set { defaultCulture = value; }
        }

        public static void SetCultureInfo()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(DefatultCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(DefatultCulture);
        }

    }
}
