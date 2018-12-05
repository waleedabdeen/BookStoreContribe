using System.Threading.Tasks;
using BookStoreWFClient.Modules.ApiModule;
using System.Windows.Forms;

namespace BookStoreWFClient.Modules.Account
{
    class UserAccountController
    {
        Form form;
        BookstoreService bookstoreService;

        public UserAccountController(Form _form)
        {
            form = _form;
            bookstoreService = new BookstoreService();
        }

        public async Task<string> Register(string email, string password)
        {
            return await bookstoreService.RegiserNewAccount(email, password);
        }

        public async Task<string> Login(string email, string password)
        {
            return await bookstoreService.GetToken(email, password);
        }
    }
}
