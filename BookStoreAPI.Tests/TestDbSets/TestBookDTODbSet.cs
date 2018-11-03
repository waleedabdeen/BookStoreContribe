using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
