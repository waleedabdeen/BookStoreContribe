using System.Web;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;


namespace BookStoreASPClient.Models
{
    public class RegisterAccountViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two passwords doesn't match")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]        
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AccessToken
    {
        public static string Get()
        {
            var session = HttpContext.Current.Session;
            if (string.IsNullOrEmpty((string)session["TOKEN"]))
            {
                return "";
            }
            return (string)session["TOKEN"];
        }

        public static void Set(string accessToken)
        {
            var session = HttpContext.Current.Session;
            session["TOKEN"] = accessToken;
        }

        public static bool Valid()
        {
            var session = HttpContext.Current.Session;
            if (string.IsNullOrEmpty((string)session["TOKEN"]) || ((string)session["TOKEN"]).StartsWith("ERROR"))
            {
                return false;
            }
            return true;
        }
    }
}