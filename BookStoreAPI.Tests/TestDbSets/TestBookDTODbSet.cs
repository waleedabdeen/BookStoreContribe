using System.Linq;
using BookStoreAPI.Models;

namespace BookStoreAPI.Tests.TestDbSets
{
    class TestBookDTODbSet : TestDbSet<BookDTO>
    {
        public override BookDTO Find(params object[] keyValues)
        {
            return this.SingleOrDefault(book => book.Id == (string)keyValues.Single());
        }
    }
}
